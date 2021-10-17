using System;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public interface IRepositorioGanado{
        //Agregar un objeto
        Ganado AgregarGanado(Ganado Ganado);

        //Obtener todos los objetos
        IEnumerable<Ganado> ObtenerTodosGanados();

        //Actualizar los objetos 
        Ganado ActualizarGanado(Ganado Ganado);
       
        //Eliminar un objeto basado en un ID
        void BorrarGanado(int idGanado);

        //Borrar registro retornando
        Boolean BorrarGanadoConMensaje(int idGanado);

        //Obtener uno especifico
        Ganado ObtenerGanado(int idGanado);
    }
}