using System;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public interface IRepositorioSolicitudVisita{
        //Agregar un objeto
        SolicitudVisita AgregarSolicitudVisita(SolicitudVisita Solicitud);

        //Obtener todos los objetos
        IEnumerable<SolicitudVisita> ObtenerTodasSolicitudVisita();

        //Actualizar los objetos 
        SolicitudVisita ActualizarSolicitudVisita(SolicitudVisita Solicitud);
        
        //Eliminar un objeto basado en un ID
        void BorrarSolicitudVisita(int Ticketid);

        //Borrar registro retornando
        Boolean BorrarSolicitudVisitaConMensaje(int Ticketid);

        //Obtener uno especifico
        SolicitudVisita ObtenerSolicitudVisita(int Ticketid);
    }
}