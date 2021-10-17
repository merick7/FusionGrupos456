using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public class RepositorioGanadero: IRepositorioGanadero{
        private readonly AppContext _appContext;

        public RepositorioGanadero(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        Ganadero IRepositorioGanadero.AgregarGanadero(Ganadero ganadero){
            var ganaderoAgregado = _appContext.Ganaderos.Add(ganadero);
            _appContext.SaveChanges();
            return ganaderoAgregado.Entity;
        }

        //Listarlos
        IEnumerable<Ganadero> IRepositorioGanadero.ObtenerTodosGanaderos(){
            return _appContext.Ganaderos;
        }

        //Actualizar datos
        Ganadero IRepositorioGanadero.ActualizarGanadero(Ganadero ganadero) {
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.NumDoc == ganadero.NumDoc);

            if (ganaderoEncontrado != null){
                ganaderoEncontrado.Nombres = ganadero.Nombres;
                ganaderoEncontrado.Apellidos = ganadero.Apellidos;
                ganaderoEncontrado.NumeroTel = ganadero.NumeroTel;
                ganaderoEncontrado.Direccion = ganadero.Direccion;
                ganaderoEncontrado.Correo = ganadero.Correo;
                ganaderoEncontrado.Pass = ganadero.Pass;
                ganaderoEncontrado.Ubicacion = ganadero.Ubicacion;
                ganaderoEncontrado.GanadoP = ganadero.GanadoP;
                ganaderoEncontrado.solicitud = ganadero.solicitud;

                _appContext.SaveChanges();
            }
            return ganaderoEncontrado;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioGanadero.BorrarGanadero(string NumDocumento){
            //Se busca el Id primero
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.NumDoc == NumDocumento);

            if (ganaderoEncontrado != null){
                _appContext.Ganaderos.Remove(ganaderoEncontrado);
                _appContext.SaveChanges(); //Guardar el cambio siempre que se hace un cambio en la BD
            }else{
                Console.WriteLine("No se ha encontrado al usuario asociado al ID");}
            
        }
        
        //Obtener un objeto de acuerdo al ID
        Ganadero IRepositorioGanadero.ObtenerGanadero(string NumDocumento) 
        {
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.NumDoc == NumDocumento);
            return ganaderoEncontrado;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioGanadero.BorrarGanaderoConMensaje(string NumDocumento) {
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.NumDoc == NumDocumento);
            if (ganaderoEncontrado != null)
            {
                _appContext.Ganaderos.Remove(ganaderoEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
    }
}