using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public class RepositorioVacuna: IRepositorioVacuna{
        private readonly AppContext _appContext;

        public RepositorioVacuna(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        Vacuna IRepositorioVacuna.AgregarVacuna(Vacuna vacuna){
            var VacunaAgregado = _appContext.vacuna.Add(vacuna);
            _appContext.SaveChanges();
            return VacunaAgregado.Entity;
        }

        //Listarlos
        IEnumerable<Vacuna> IRepositorioVacuna.ObtenerTodasVacunas(){
            return _appContext.vacuna;
        }

        //Actualizar datos
        Vacuna IRepositorioVacuna.ActualizarVacuna(Vacuna vacuna) {
            var VacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == vacuna.Id);

            if (VacunaEncontrada != null){
                VacunaEncontrada.Nombre = vacuna.Nombre;
                VacunaEncontrada.Descripcion = vacuna.Descripcion;
                VacunaEncontrada.Lote = vacuna.Lote;
                VacunaEncontrada.FechaVen = vacuna.FechaVen;
                VacunaEncontrada.Labo = vacuna.Labo;

                _appContext.SaveChanges();
            }
            return VacunaEncontrada;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioVacuna.BorrarVacuna(int idvacuna){
            //Se busca el Id primero
            var VacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == idvacuna);

            if (VacunaEncontrada != null){
                _appContext.vacuna.Remove(VacunaEncontrada);
                _appContext.SaveChanges();
            }else{
                Console.WriteLine("No se ha encontrado la vacuna asociada al ID");}
        }
        
        //Obtener un objeto de acuerdo al ID
        Vacuna IRepositorioVacuna.ObtenerVacuna(int idvacuna) 
        {
            var VacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == idvacuna);
            return VacunaEncontrada;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioVacuna.BorrarVacunaConMensaje(int idvacuna) {
            var VacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == idvacuna);
            if (VacunaEncontrada != null){
                _appContext.vacuna.Remove(VacunaEncontrada);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
    }
}