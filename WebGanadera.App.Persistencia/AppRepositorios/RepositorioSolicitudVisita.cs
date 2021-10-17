using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public class RepositorioSolicitudVisita:IRepositorioSolicitudVisita{
        private readonly AppContext _appContext;

        public RepositorioSolicitudVisita(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        SolicitudVisita IRepositorioSolicitudVisita.AgregarSolicitudVisita(SolicitudVisita Solicitud){
            var SolicitudAgregado = _appContext.Solicitud.Add(Solicitud);
            _appContext.SaveChanges();
            return SolicitudAgregado.Entity;
        }

        //Listarlos
        IEnumerable<SolicitudVisita> IRepositorioSolicitudVisita.ObtenerTodasSolicitudVisita(){
            return _appContext.Solicitud;
        }

        //Actualizar datos
        SolicitudVisita IRepositorioSolicitudVisita.ActualizarSolicitudVisita(SolicitudVisita Solicitud) {
            var SolicitudEncontrado = _appContext.Solicitud.FirstOrDefault(g => g.Id == Solicitud.Id);

            if (SolicitudEncontrado != null){
                SolicitudEncontrado.EstadoVisita = Solicitud.EstadoVisita;
                SolicitudEncontrado.EstadoEjemplar = Solicitud.EstadoEjemplar;
                SolicitudEncontrado.FechaSolicitud = Solicitud.FechaSolicitud;
                SolicitudEncontrado.FechaVisita = Solicitud.FechaVisita;

                _appContext.SaveChanges();
            }
            return SolicitudEncontrado;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioSolicitudVisita.BorrarSolicitudVisita(int Ticketid){
            //Se busca el Id primero
            var SolicitudEncontrado = _appContext.Solicitud.FirstOrDefault(g => g.Id == Ticketid);

            if (SolicitudEncontrado != null){
                _appContext.Solicitud.Remove(SolicitudEncontrado);
                _appContext.SaveChanges();
            }else{
                Console.WriteLine("No se ha encontrado al usuario asociado al ID");}
            
        }
        
        //Obtener un objeto de acuerdo al ID
        SolicitudVisita IRepositorioSolicitudVisita.ObtenerSolicitudVisita(int Ticketid) 
        {
            var SolicitudEncontrado = _appContext.Solicitud.FirstOrDefault(g => g.Id == Ticketid);
            return SolicitudEncontrado;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioSolicitudVisita.BorrarSolicitudVisitaConMensaje(int Ticketid) {
            var SolicitudEncontrado = _appContext.Solicitud.FirstOrDefault(g => g.Id == Ticketid);
            if (SolicitudEncontrado != null){
                _appContext.Solicitud.Remove(SolicitudEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
    }
}