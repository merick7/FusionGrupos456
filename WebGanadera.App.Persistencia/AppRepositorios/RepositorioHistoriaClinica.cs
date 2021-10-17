using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public class RepositorioHistoriaClinica:IRepositorioHistoriaClinica{
        private readonly AppContext _appContext;

        public RepositorioHistoriaClinica(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        HistoriaClinica IRepositorioHistoriaClinica.AgregarHistoriaClinica(HistoriaClinica Historia){
            var HistoriaAgregado = _appContext.Historia.Add(Historia);
            _appContext.SaveChanges();
            return HistoriaAgregado.Entity;
        }

        //Listarlos
        IEnumerable<HistoriaClinica> IRepositorioHistoriaClinica.ObtenerTodasHistoriaClinica(){
            return _appContext.Historia;
        }

        //Actualizar datos
        HistoriaClinica IRepositorioHistoriaClinica.ActualizarHistoriaClinica(HistoriaClinica Historia) {
            var HistoriaEncontrado = _appContext.Historia.FirstOrDefault(g => g.Id == Historia.Id);

            if (HistoriaEncontrado != null){
                HistoriaEncontrado.HistorialId = Historia.HistorialId;
                HistoriaEncontrado.VacunaApli = Historia.VacunaApli;
                HistoriaEncontrado.FechaAplicacion = Historia.FechaAplicacion;
                HistoriaEncontrado.VeterinarioAplicante = Historia.VeterinarioAplicante;
                HistoriaEncontrado.NumDosis = Historia.NumDosis;
                HistoriaEncontrado.Periodicidad = Historia.Periodicidad;

                _appContext.SaveChanges();
            }
            return HistoriaEncontrado;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioHistoriaClinica.BorrarHistoriaClinica(int HistorialId){
            //Se busca el Id primero
            var HistoriaEncontrado = _appContext.Historia.FirstOrDefault(g => g.HistorialId == HistorialId);

            if (HistoriaEncontrado != null){
                _appContext.Historia.Remove(HistoriaEncontrado);
                _appContext.SaveChanges();
            }else{
                Console.WriteLine("No se ha encontrado al usuario asociado al ID");}
            
        }
        
        //Obtener un objeto de acuerdo al ID
        HistoriaClinica IRepositorioHistoriaClinica.ObtenerHistoriaClinica(int HistorialId) 
        {
            var HistoriaEncontrado = _appContext.Historia.FirstOrDefault(g => g.HistorialId == HistorialId);
            return HistoriaEncontrado;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioHistoriaClinica.BorrarHistoriaClinicaConMensaje(int HistorialId) {
            var HistoriaEncontrado = _appContext.Historia.FirstOrDefault(g => g.HistorialId == HistorialId);
            if (HistoriaEncontrado != null){
                _appContext.Historia.Remove(HistoriaEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
    }
}