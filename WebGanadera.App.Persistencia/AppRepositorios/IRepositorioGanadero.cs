using System;
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
        
        //Eliminar un objeto basado en un ID
        void BorrarGanadero(string NumDocumento);

        //Retornar un objeto especifico
        Ganadero ObtenerGanadero(string NumDocumento);
        
        //Eliminar con retorno
        Boolean BorrarGanaderoConMensaje(string NumDocumento);
    }
}