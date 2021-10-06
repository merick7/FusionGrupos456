namespace WebGanadera.App.Dominio{
    public class HistoriaClinica{
        public int Id{ get; set; }
        public string VacunaApli{ get; set; }
        public string FechaAplicacion{ get; set; }
        public string MedAplicante { get; set; }
        public int NumDosis { get; set; }
        public string Periodicidad { get; set; }
    }
}