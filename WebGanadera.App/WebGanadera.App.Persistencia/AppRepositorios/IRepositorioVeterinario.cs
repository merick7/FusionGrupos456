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
        /*
        //Borrar uno de los registros
        Boolean BorrarVeterinario(int idVeterinario);

        Veterinario ObtenerVeterinario(int idveterinario);
        */
    }
}