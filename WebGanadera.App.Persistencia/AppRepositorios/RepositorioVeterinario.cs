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

        //Actualizar datos
        Veterinario IRepositorioVeterinario.ActualizarVeterinario(Veterinario veterinario) {
            var veterinarioEncontrado = _appContext.veterinario.FirstOrDefault(g => g.NumLicencia == veterinario.NumLicencia);

            if (veterinarioEncontrado != null){
                veterinarioEncontrado.NumDoc = veterinario.NumDoc;
                veterinarioEncontrado.Nombres = veterinario.Nombres;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.NumeroTel = veterinario.NumeroTel;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.Correo = veterinario.Correo;
                veterinarioEncontrado.Pass = veterinario.Pass;
                veterinarioEncontrado.veterinaria = veterinario.veterinaria;
                //veterinarioEncontrado.NumLicencia = veterinario.NumLicencia;
                veterinarioEncontrado.Especialidad = veterinario.Especialidad;
                veterinarioEncontrado.Vacunas = veterinario.Vacunas;
                veterinarioEncontrado.solicitud = veterinario.solicitud;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioVeterinario.BorrarVeterinario(string NumLicencia){
            //Se busca el Id primero
            var veterinarioEncontrado = _appContext.veterinario.FirstOrDefault(g => g.NumLicencia == NumLicencia);

            if (veterinarioEncontrado != null){
                _appContext.veterinario.Remove(veterinarioEncontrado);
                _appContext.SaveChanges();
            }else{
                Console.WriteLine("No se ha encontrado al usuario asociado al ID");}
            
        }
        
        //Obtener un objeto de acuerdo al ID
        Veterinario IRepositorioVeterinario.ObtenerVeterinario(string NumLicencia) 
        {
            var veterinarioEncontrado = _appContext.veterinario.FirstOrDefault(g => g.NumLicencia == NumLicencia);
            return veterinarioEncontrado;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioVeterinario.BorrarVeterinarioConMensaje(string NumLicencia) {
            var veterinarioEncontrado = _appContext.veterinario.FirstOrDefault(g => g.NumLicencia == NumLicencia);
            if (veterinarioEncontrado != null){
                _appContext.veterinario.Remove(veterinarioEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
    }
}