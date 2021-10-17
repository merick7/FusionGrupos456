using System;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public interface IRepositorioVeterinario {
        //Agregar un objeto
        Veterinario AgregarVeterinario(Veterinario veterinario);

        //Obtener todos los objetos
        IEnumerable<Veterinario> ObtenerTodosVeterinarios();

        //Actualizar los objetos 
        Veterinario ActualizarVeterinario(Veterinario veterinario);
        
        //Eliminar un objeto basado en un ID
        void BorrarVeterinario(string NumLicencia);

        //Borrar registro retornando
        Boolean BorrarVeterinarioConMensaje(string NumLicencia);

        //Obtener uno especifico
        Veterinario ObtenerVeterinario(string NumLicencia);
        
    }
}