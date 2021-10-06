using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public interface IRepositorioGanadero {
        //Agregar un objeto
        Ganadero AgregarGanadero(Ganadero ganadero);

        //Obtener todos los objetos
        IEnumerable<Ganadero> ObtenerTodosGanaderos();

        //Actualizar los objetos 
        Ganadero ActualizarGanadero(Ganadero ganadero);
        /*
        //Borrar uno de los registros
        Boolean BorrarGanadero(int idGanadero);

        Ganadero ObtenerGanadero(int idGanadero);
        */
    }
}