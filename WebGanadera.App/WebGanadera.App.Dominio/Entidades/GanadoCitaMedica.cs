namespace WebGanadera.App.Dominio{

    public class GanadoCitaMedica : Ganado{
        public string FechaControl { get; set; }
        public int NumEjemplar { get; set; }
        public string ModConsulta { get; set; }
        public Vacuna vacuna { get; set; }
    }
}