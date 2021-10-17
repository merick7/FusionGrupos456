using System;
using System.Security.Cryptography;
using WebGanadera.App.Dominio;
using WebGanadera.App.Persistencia;

namespace WebGanadera.App.Consola
{
    class Program
    {
        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());

        public static string cifrarPass(string pass){
            MD5CryptoServiceProvider varmed = new MD5CryptoServiceProvider();
            byte[] varbin = System.Text.Encoding.UTF8.GetBytes(pass);
            varbin = varmed.ComputeHash(varbin);
            System.Text.StringBuilder varstr = new System.Text.StringBuilder();
            foreach (byte valbyte in varbin){
                varstr.Append(valbyte.ToString("x2").ToLower());
            }
            string passC = varstr.ToString();
            return passC; //retorna variable passC
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            AgregarGanadero();
            //ObtenerTodosGanaderos();
            //ActualizarGanadero();
            //BorrarGanadero();
            //ObtenerGanadero();
        }

        private static void AgregarGanadero(){
            var ganadero = new Ganadero{
                //Id=123,
                TipoId="Cedula",
                Nombres="Carlos Javier",
                Apellidos="Rengifo Mendez",
                NumeroTel = "3155667478",
                Direccion = "Casa campo 1234",
                Correo = "javier_6085@hotmail.com",
                Pass = cifrarPass("1234"),
                Ubicacion = "Valle del Cauca"
                //GanadoP = null
            };
            _repoGanadero.AgregarGanadero(ganadero);
            }

            private static void ObtenerTodosGanaderos(){
                var ganaderos = _repoGanadero.ObtenerTodosGanaderos();
                foreach (Ganadero item in ganaderos)
                {
                    Console.WriteLine(item.Nombres);
                }
        }

        private static void ActualizarGanadero()
        {
            var ganadero = new Ganadero
            {
                Id=1144077123,
                TipoId="Cedula",
                Nombres="Carlos Javier",
                Apellidos="Rengifo Mendez",
                NumeroTel = "3184980371",
                Direccion = "Casa campo 5478",
                Correo = "javier_6085@hotmail.com",
                Pass = cifrarPass("1234"),
                Ubicacion = "Cauca"
            };
            _repoGanadero.ActualizarGanadero(ganadero);
        }

        /*
        private static void BorrarGanadero(int idGanadero)
        {
            //var response = _repoGanadero.BorrarGanadero(idGanadero);
            string message = _repoGanadero.BorrarGanadero(idGanadero) ? "El ganadero se ha eliminado correctamemte" : "El ganadero no ha sido encontrado";
            Console.WriteLine(message);
            // if (response) 
            // {
            //     Console.WriteLine("El ganadero se ha eliminado correctamemte");
            // } else
            // {
            //     Console.WriteLine("El ganadero no ha sido encontrado");
            // }
        }

        private static void ObtenerGanadero(int idGanadero)
        {
            var ganadero = _repoGanadero.ObtenerGanadero(idGanadero);
            Console.WriteLine("El nombre del ganadero es: " + ganadero.Nombres);
        }
        */
    }
}
