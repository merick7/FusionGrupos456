using System;

namespace WebGanadera.App.Dominio{
    public class SolicitudVisita{
        public int Id { get; set; }
        public string EstadoVisita { get; set; }
        public string EstadoEjemplar { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaVisita { get; set; }
    }
}