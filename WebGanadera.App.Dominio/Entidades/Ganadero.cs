namespace WebGanadera.App.Dominio{
    public class Ganadero : Persona{
        public string Ubicacion { get; set; }
        public virtual Ganado GanadoP { get; set; }
        public virtual SolicitudVisita solicitud { get; set; } 
    }
}