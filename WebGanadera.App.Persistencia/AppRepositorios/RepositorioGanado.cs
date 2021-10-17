using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public class RepositorioGanado:IRepositorioGanado{
        private readonly AppContext _appContext;

        public RepositorioGanado(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        Ganado IRepositorioGanado.AgregarGanado(Ganado Ganado){
            var GanadoAgregado = _appContext.Ganado.Add(Ganado);
            _appContext.SaveChanges();
            return GanadoAgregado.Entity;
        }

        //Listarlos
        IEnumerable<Ganado> IRepositorioGanado.ObtenerTodosGanados(){
            return _appContext.Ganado;
        }

        //Actualizar datos
        Ganado IRepositorioGanado.ActualizarGanado(Ganado Ganado) {
            var GanadoEncontrado = _appContext.Ganado.FirstOrDefault(g => g.NumInv == Ganado.NumInv);

            if (GanadoEncontrado != null){
                GanadoEncontrado.Genero = Ganado.Genero;
                GanadoEncontrado.Edad = Ganado.Edad;
                GanadoEncontrado.Peso = Ganado.Peso;
                GanadoEncontrado.Raza = Ganado.Raza;

                _appContext.SaveChanges();
            }
            return GanadoEncontrado;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioGanado.BorrarGanado(int idGanado){
            //Se busca el Id primero
            var GanadoEncontrado = _appContext.Ganado.FirstOrDefault(g => g.NumInv == idGanado);

            if (GanadoEncontrado != null){
                _appContext.Ganado.Remove(GanadoEncontrado);
                _appContext.SaveChanges();
            }else{
                Console.WriteLine("No se ha encontrado el ganado asociado al ID");}
        }
        
        //Obtener un objeto de acuerdo al ID
        Ganado IRepositorioGanado.ObtenerGanado(int idGanado) 
        {
            var GanadoEncontrado = _appContext.Ganado.FirstOrDefault(g => g.NumInv == idGanado);
            return GanadoEncontrado;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioGanado.BorrarGanadoConMensaje(int idGanado) {
            var GanadoEncontrado = _appContext.Ganado.FirstOrDefault(g => g.NumInv == idGanado);
            if (GanadoEncontrado != null)
            {
                _appContext.Ganado.Remove(GanadoEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
        
    }
}