namespace WebGanadera.App.Dominio{
    public class Veterinario : Persona{
        public string veterinaria { get; set; }
        public string NumLicencia { get; set; }
        public string Especialidad { get; set; }
        public virtual Vacuna Vacunas { get; set; }
        public virtual SolicitudVisita solicitud { get; set; }
    }
}