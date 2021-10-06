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

        //Listar a uno en especifico
        Vacuna IRepositorioVacuna.ActualizarVacuna(Vacuna vacuna) {
            var VacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == vacuna.Id);

            if (VacunaEncontrada != null){
                VacunaEncontrada.Nombre = vacuna.Nombre;
                //VacunaEncontrada.Descripcion = vacuna.Descripcion;

                _appContext.SaveChanges();
            }
            return VacunaEncontrada;
        }
        /*
        //Borrar alguno
        Boolean IRepositorioVacuna.BorrarVacuna(int idVacuna) {
            var VacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == idVacuna);
            if (VacunaEncontrada != null)
            {
                _appContext.vacuna.Remove(VacunaEncontrada);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }

        Vacuna IRepositorioVacuna.ObtenerVacuna(int idVacuna) 
        {
            var vacunaEncontrada = _appContext.vacuna.FirstOrDefault(g => g.Id == idVacuna);
            return vacunaEncontrado;
        }
    */

    }
}