using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public class RepositorioVeterinario: IRepositorioVeterinario{
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        Veterinario IRepositorioVeterinario.AgregarVeterinario(Veterinario veterinario){
            var veterinarioAgregado = _appContext.veterinario.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAgregado.Entity;
        }

        //Listarlos
        IEnumerable<Veterinario> IRepositorioVeterinario.ObtenerTodosVeterinarios(){
            return _appContext.veterinario;
        }

        //Listar a uno en especifico
        Veterinario IRepositorioVeterinario.ActualizarVeterinario(Veterinario veterinario) {
            var veterinarioEncontrado = _appContext.veterinario.FirstOrDefault(g => g.Id == veterinario.Id);

            if (veterinarioEncontrado != null){
                veterinarioEncontrado.Nombres = veterinario.Nombres;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }
        /*
        //Borrar alguno
        Boolean IRepositorioVeterinario.BorrarVeterinario(int idVeterinario) {
            var VeterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(g => g.Id == idVeterinario);
            if (VeterinarioEncontrado != null)
            {
                _appContext.Veterinarios.Remove(veterinarioEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }

        Ganadero IRepositorioVeterinario.GetVeterinario(int idVeterinario) 
        {
            var veterinarioEncontrado = _appContext.veterinario.FirstOrDefault(g => g.Id == idVeterinario);
            return veterinarioEncontrado;
        }
    */

    }
}