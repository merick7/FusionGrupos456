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

        //Listar a uno en especifico
        Ganadero IRepositorioGanadero.ActualizarGanadero(Ganadero ganadero) {
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.Id == ganadero.Id);

            if (ganaderoEncontrado != null){
                ganaderoEncontrado.Nombres = ganadero.Nombres;
                ganaderoEncontrado.Apellidos = ganadero.Apellidos;

                _appContext.SaveChanges();
            }
            return ganaderoEncontrado;
        }
        /*
        //Borrar alguno
        Boolean IRepositorioGanadero.BorrarGanadero(int idGanadero) {
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.Id == idGanadero);
            if (ganaderoEncontrado != null)
            {
                _appContext.Ganaderos.Remove(ganaderoEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }

        Ganadero IRepositorioGanadero.GetGanadero(int idGanadero) 
        {
            var ganaderoEncontrado = _appContext.Ganaderos.FirstOrDefault(g => g.Id == idGanadero);
            return ganaderoEncontrado;
        }
    */

    }
}