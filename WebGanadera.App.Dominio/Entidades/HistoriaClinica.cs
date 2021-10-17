using System;

namespace WebGanadera.App.Dominio{
    public class HistoriaClinica:SolicitudVisita{
        public int HistorialId{ get; set; }
        public string VacunaApli{ get; set; }
        public DateTime FechaAplicacion{ get; set; }
        public string VeterinarioAplicante { get; set; }
        public int NumDosis { get; set; }
        public string Periodicidad { get; set; }
    }
}