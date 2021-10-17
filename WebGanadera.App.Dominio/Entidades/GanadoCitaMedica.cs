using System;
using System.Collections.Generic;

namespace WebGanadera.App.Dominio{

    public class GanadoCitaMedica : Ganado{
        public DateTime FechaControl { get; set; }
        public int NumEjemplar { get; set; }
        public string ModConsulta { get; set; }
        public virtual List<Vacuna> Vacunas { get; set; }
        public virtual Veterinario Medico { get; set; }
        public virtual HistoriaClinica historia { get; set; }
    }
}