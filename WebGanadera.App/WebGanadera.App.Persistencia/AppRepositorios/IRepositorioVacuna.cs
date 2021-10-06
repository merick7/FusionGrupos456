using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public interface IRepositorioVacuna {
        //Agregar un objeto
        Vacuna AgregarVacuna(Vacuna vacuna);

        //Obtener todos los objetos
        IEnumerable<Vacuna> ObtenerTodasVacunas();

        //Actualizar los objetos 
        Vacuna ActualizarVacuna(Vacuna vacuna);
        /*
        //Borrar uno de los registros
        Boolean BorrarVacuna(int idVacuna);

        Vacuna ObtenerVacuna(int idvacuna);
        */
    }
}