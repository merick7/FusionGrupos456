using System;

namespace WebGanadera.App.Dominio{
    public class Vacuna{
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string RegistroSan { get; set; }
        public string Lote {get; set; }
        public DateTime FechaVen { get; set; }
        public string Labo { get; set; }
    }
}