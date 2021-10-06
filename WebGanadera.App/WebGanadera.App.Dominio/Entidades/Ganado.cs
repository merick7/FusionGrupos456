namespace WebGanadera.App.Dominio{
    public class Ganado{
        public int Id { get; set; }
        public char Genero { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string raza { get; set; }
        public Veterinario Medico { get; set; }
    }
}