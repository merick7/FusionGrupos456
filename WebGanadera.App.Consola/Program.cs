using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using WebGanadera.App.Dominio;
using WebGanadera.App.Persistencia;

namespace WebGanadera.App.Consola{
    class Program{
        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioGanadoCitaMedica _repoGanadoControl = new RepositorioGanadoCitaMedica(new Persistencia.AppContext());
        private static IRepositorioGanado _repoGanado = new RepositorioGanado(new Persistencia.AppContext());
        private static IRepositorioSolicitudVisita _repoSolicitudVisita = new RepositorioSolicitudVisita(new Persistencia.AppContext());
        private static IRepositorioHistoriaClinica _repoHistoriaClinica = new RepositorioHistoriaClinica(new Persistencia.AppContext());
        private static IRepositorioVacuna _repoVacuna = new RepositorioVacuna(new Persistencia.AppContext());

        public static string cifrarPass(string pass){
            MD5CryptoServiceProvider varmed = new MD5CryptoServiceProvider();
            byte[] varbin = System.Text.Encoding.UTF8.GetBytes(pass);
            varbin = varmed.ComputeHash(varbin);
            System.Text.StringBuilder varstr = new System.Text.StringBuilder();
            foreach (byte valbyte in varbin){
                varstr.Append(valbyte.ToString("x2").ToLower());
            }
            string passC = varstr.ToString();
            return passC;
        }

        //Validacion de tamaño cadena, numero y mayuscula
        public static Boolean valpass(string prueba){
            if (prueba.Length >= 8){  //La cadena tiene el tamaño mínimo
            bool validText = prueba.Any(c => char.IsUpper(c)); //Mayuscula
            bool validNum = prueba.Any(c => char.IsDigit(c)); //Es numero
            if (validNum == true && validText == true){
                Console.WriteLine("La cadena es correcta");
                return true;
            }else{
                Console.WriteLine("La cadena debe contener al menos una letra mayuscula y un numero");
                return false;
            }
            }else{
                Console.WriteLine("El mínimo de caracteres para la contraseña es de 8");
                return false;
            }
        }

        static void Main(string[] args){
            Console.WriteLine("Probando resultado de funciones");
            string text_in;
            Console.WriteLine("Introduzca una contraseña");
            text_in=Console.ReadLine();
            bool val=valpass(text_in);
            while(val==false){
                Console.WriteLine("Introduzca una contraseña correcta");
                text_in=Console.ReadLine();
                val=valpass(text_in);
            }
            Console.WriteLine("La contraseña ha cumplido con los estandares. Fue digitado: "+text_in);
            

            /*string prueba = "Javier";
            string texto = cifrarPass(prueba);
            Console.WriteLine(texto);*/

            //AgregarGanadero();            //Agregarlo a Local
            //ObtenerTodosGanaderos();      //Obtener todos de Local
            //ActualizarGanadero();         //Actualizar datos en Local
            //BorrarGanadero("1180232496");             //Borrar de Local
            //BorrarGanaderoConMensaje();   //Borrar de Local
            //ObtenerGanadero();            //Traerlo de Local

            //AgregarVeterinario();
            //ObtenerTodosVeterinarios();
            //ActualizarVeterinario();
            //BorrarVeterinarioConMensaje(5);
            //ObtenerVeterinario();

            //AgregarGanado();
            //ObtenerTodosGanados();
            //ActualizarGanado();
            //ObtenerGanado();
            //BorrarGanado();

            //AgregarGanadoControl();
            //ObtenerTodosGanadoControl();
            //ActualizarGanadoControl();
            //ObtenerGanadoControl();
            //BorrarGanadoControl();

            //AgregarVacuna();
            //ObtenerTodasVacuna();
            //ActualizarVacuna();
            //ObtenerVacuna();
            //BorrarVacuna();

            //AgregarSolicitudVisita();
            //ObtenerTodasSolicitudVisita();
            //ActualizarSolicitudVisita();
            //ObtenerSolicitudVisita();
            //BorrarSolicitudVisita();

            //AgregarHistoriaClinica();
            //ObtenerTodasHistoriaClinica();
            //ActualizarHistoriaClinica();
            //ObtenerHistoriaClinica();
            //BorrarHistoriaClinica();

            //***************Operaciones varias********************
            //AgregarVeterinarioAGanado("8720163",3);
            //ObtenerVeterinariodeGanado(2);

            //AgregarGanadoControlDesdeGanado(892);
            //AgregarHistoriaDesdeSolicitud(2,3,"8720163");

            //AgregarGanadoaGanadero(1430,"1144077123");
            //AgregarGanadoaGanadero(892,"1180232496");
            //AgregarSolicitudaGanadero(2,"1180232496");
            //AgregarSolicitudaVeterinario(2,"8720163");
            //AgregarHistoriaAEjemplar(560,3);
            
            //AgregarVacunasaVeterinario(3,"8720163");
            //AgregarVacunasaGanado(3);
            
        }
        //*****************************Agregar objetos*************
        private static void AgregarGanadero(){
            var ganadero = new Ganadero{

                TipoDocumento = "Cedula",
                NumDoc = "1144077123",
                Nombres = "Carlos Javier",
                Apellidos = "Rengifo Mendez",
                NumeroTel = "3155667478",
                Direccion = "Casa campo 1234",
                Correo = "javier_6085@hotmail.com",
                Pass = cifrarPass("CJ8056m?"),
                Ubicacion = "Cali, Valle del Cauca"
            };
            _repoGanadero.AgregarGanadero(ganadero);
        }

        private static void AgregarVeterinario(){
            var veterinario = new Veterinario{

                TipoDocumento = "Cedula",
                NumDoc = "1104792631",
                Nombres = "Juan Sebastian",
                Apellidos = "Acosta Rendon",
                NumeroTel = "3115758642",
                Direccion = "Calle 4A # 45-23",
                Correo = "campo25@hotmail.com", 
                Pass = cifrarPass("Klm4Rd0"),
                veterinaria = "Maskotas",
                NumLicencia = "7854513",
                Especialidad = "Tratamientos y suturas",
                Vacunas = null,
                solicitud = null
            };
            _repoVeterinario.AgregarVeterinario(veterinario);
        }

        private static void AgregarGanado(){
            var ganado = new Ganado{

                NumInv = 892,
                Genero = 'F',
                Edad = 2,
                Peso = 50.3f,
                Raza = "Holstein",
            };
            _repoGanado.AgregarGanado(ganado);
        }

        private static void AgregarGanadoControl(){
            var ganadocontrol = new GanadoCitaMedica{

                NumInv = 1542,
                Genero = 'M',
                Edad = 2,
                Peso = 70.2f,
                Raza = "Angus",
                FechaControl = new DateTime(2021,08,05),
                NumEjemplar = 2,
                ModConsulta = "Control",
                Vacunas = null,
                Medico = null,
                historia = null
            };
            _repoGanadoControl.AgregarGanadoControl(ganadocontrol);
        }

        private static void AgregarVacuna(){
            var vacuna = new Vacuna{

                Nombre = "Clostrigen 9+T",
                Descripcion = "Inmunización contra Gangrena o edemas malignos",
                RegistroSan = "Qd45v",
                Lote = "L8952",
                FechaVen = new DateTime(2022,10,01),
                Labo = "Virbac",
            };
            _repoVacuna.AgregarVacuna(vacuna);
        }

        private static void AgregarSolicitudVisita(){
            var solicitud = new SolicitudVisita{

                EstadoVisita="Atendiendo",
                EstadoEjemplar="En Revisión",
                FechaSolicitud = new DateTime(2021,10,14,8,10,05), //AAAA/MM/DD HH/MM/SS
                FechaVisita = DateTime.Now
            };
            _repoSolicitudVisita.AgregarSolicitudVisita(solicitud);
        }

        private static void AgregarHistoriaClinica(){
            var historia = new HistoriaClinica{

                EstadoVisita="Finalizado",
                EstadoEjemplar="Atendido",
                FechaSolicitud = new DateTime(2021,9,5,15,10,20),
                FechaVisita = new DateTime(2021,9,7,8,10,05),
                VacunaApli = null,
                FechaAplicacion = new DateTime(2021,9,7,8,45,10),
                VeterinarioAplicante = null,
                NumDosis = 1,
                Periodicidad = "1 vez cada 2 meses"
            };
            _repoHistoriaClinica.AgregarHistoriaClinica(historia);
        }

        public static void AgregarGanadoControlDesdeGanado(int NumInv){
            var GanadoEncontrado= _repoGanado.ObtenerGanado(NumInv);
            var ganadoControl = new GanadoCitaMedica{

                NumInv = GanadoEncontrado.NumInv,
                Genero = GanadoEncontrado.Genero,
                Edad = GanadoEncontrado.Edad,
                Peso = GanadoEncontrado.Peso,
                Raza = GanadoEncontrado.Raza,
                FechaControl = DateTime.Now,
                NumEjemplar = 3,
                ModConsulta = "Enfermedad",
                Vacunas = null,
                Medico = null,
                historia = null
            };
            _repoGanadoControl.AgregarGanadoControl(ganadoControl);
        }

        public static void AgregarHistoriaDesdeSolicitud(int solicitudid, int vacunaid, string NumLicencia){
            var solicitudEncontrada = _repoSolicitudVisita.ObtenerSolicitudVisita(solicitudid);
            var vacunaEncontrada = _repoVacuna.ObtenerVacuna(vacunaid);
            var VeterinarioEncontrado = _repoVeterinario.ObtenerVeterinario(NumLicencia);

            var historia = new HistoriaClinica{
                HistorialId = 560,
                EstadoVisita="Finalizado",
                EstadoEjemplar="Atendido",
                FechaSolicitud = solicitudEncontrada.FechaSolicitud,
                FechaVisita = solicitudEncontrada.FechaVisita,
                VacunaApli = vacunaEncontrada.Nombre,
                FechaAplicacion = solicitudEncontrada.FechaVisita,
                VeterinarioAplicante = VeterinarioEncontrado.Nombres,
                NumDosis = 1,
                Periodicidad = "1 vez cada 2 meses"
            };
            _repoHistoriaClinica.AgregarHistoriaClinica(historia);
        }

        //*****************************Obtener objetos*************
        //Obtener todos los objetos posibles en BD
        private static void ObtenerTodosGanaderos(){
            var ganaderos = _repoGanadero.ObtenerTodosGanaderos();
            foreach (Ganadero item in ganaderos){
                Console.WriteLine(item.Nombres);
            }
        }

        private static void ObtenerTodosVeterinarios(){
            var veterinarios = _repoVeterinario.ObtenerTodosVeterinarios();
            foreach (Veterinario item in veterinarios){
                Console.WriteLine(item.Nombres);
            }
        }

        private static void ObtenerTodosGanados(){
            var ganados = _repoGanado.ObtenerTodosGanados();
            foreach (Ganado item in ganados){
                Console.WriteLine(item.NumInv);
            }
        }

        private static void ObtenerTodosGanadoControl(){
            var ganadoControl = _repoGanadoControl.ObtenerTodosGanadoControl();
            foreach (GanadoCitaMedica item in ganadoControl){
                Console.WriteLine(item.NumEjemplar);
            }
        }

        private static void ObtenerTodasVacunas(){
            var vacuna = _repoVacuna.ObtenerTodasVacunas();
            foreach (Vacuna item in vacuna){
                Console.WriteLine(item.Nombre);
            }
        }

        private static void ObtenerTodasSolicitudVisita(){
            var solicitud = _repoSolicitudVisita.ObtenerTodasSolicitudVisita();
            foreach (SolicitudVisita item in solicitud){
                Console.WriteLine(item.Id);
            }
        }

        private static void ObtenerTodasHistoriaClinica(){
            var historia = _repoHistoriaClinica.ObtenerTodasHistoriaClinica();
            foreach (HistoriaClinica item in historia){
                Console.WriteLine(item.HistorialId);
            }
        }
        //Obtener un objeto en particular
        private static void ObtenerGanadero(string NumDoc){
            var ganadero = _repoGanadero.ObtenerGanadero(NumDoc);
            Console.WriteLine("El nombre del ganadero es: " + ganadero.Nombres);
        }

        private static void ObtenerVeterinario(string NumLicencia){
            var veterinario = _repoVeterinario.ObtenerVeterinario(NumLicencia);
            Console.WriteLine("El nombre del veterinario es: " + veterinario.Nombres);
        }

        private static void ObtenerGanado(int NumInv){
            var ganado = _repoGanado.ObtenerGanado(NumInv);
            Console.WriteLine("El ID de inventario asociado es: " + ganado.NumInv);
        }

        private static void ObtenerGanadoControl(int NumEjemplar){
            var ganadoControl = _repoGanadoControl.ObtenerGanadoControl(NumEjemplar);
            Console.WriteLine("El ID para el ejemplar bajo estudio es: " + ganadoControl.NumEjemplar);
        }

        private static void ObtenerVacuna(int idvacuna){
            var vacuna = _repoVacuna.ObtenerVacuna(idvacuna);
            Console.WriteLine("El nombre de la vacuna asociada ese ID es: " + vacuna.Nombre);
        }

        private static void ObtenerSolicitudVisita(int Ticketid){
            var solicitud = _repoSolicitudVisita.ObtenerSolicitudVisita(Ticketid);
            Console.WriteLine("El ID de la visita programada es: " + solicitud.Id);
        }

        private static void ObtenerHistoriaClinica(int HistorialId){
            var historia = _repoHistoriaClinica.ObtenerHistoriaClinica(HistorialId);
            Console.WriteLine("El ID de la historia clinica asociada es: " + historia.HistorialId);
        }

        public static void ObtenerVeterinariodeGanado(int idGanado){
            var ganadocontrolencontrado = _repoGanadoControl.ObtenerGanadoControl(idGanado);
            Console.WriteLine("La raza del ganado es: " + ganadocontrolencontrado.Raza);
            Console.WriteLine("El peso del ganado es: " + ganadocontrolencontrado.Peso);
            Console.WriteLine("El genero del ganado es: " + ganadocontrolencontrado.Genero);
            Console.WriteLine("El veterinario asignado es: " + ganadocontrolencontrado.Medico.Nombres);
            /*
            if (ganadocontrolencontrado.Vacunas != null) {
                Console.WriteLine("Veterinario asignado");
                Console.WriteLine("Especialidad: " + ganadoEncontrado.Medico.Especialidad);
            } else {
                Console.WriteLine("No se ha asignado un veterinario");   
            }
            */
        }

        //*****************************Añadir objetos a otras clases*************
        //Añadir veterinario a un ganado en particular
        public static void AgregarVeterinarioAGanado(string NumLicencia, int NumEjemplar){
            var VeterinarioEncontrado = _repoVeterinario.ObtenerVeterinario(NumLicencia);
            var GanadoControlEncontrado = _repoGanadoControl.ObtenerGanadoControl(NumEjemplar);
            //Console.WriteLine("El nombre del veterinario encargado es: " + VeterinarioEncontrado.Nombres);
            GanadoControlEncontrado.Medico = VeterinarioEncontrado;
            _repoGanadoControl.ActualizarGanadoControl(GanadoControlEncontrado);
        }

        //Añadir ganado a Ganadero
        public static void AgregarGanadoaGanadero(int NumInv, string NumDoc){
            var GanadoEncontrado = _repoGanado.ObtenerGanado(NumInv);
            var GanaderoEncontrado = _repoGanadero.ObtenerGanadero(NumDoc);
            // Console.WriteLine("El nombre del ganadero es: " + GanaderoEncontrado.Nombres);
            // Console.WriteLine("El ID del ganado agregado es: " + GanadoEncontrado.NumInv);
            GanaderoEncontrado.GanadoP = GanadoEncontrado;
            _repoGanadero.ActualizarGanadero(GanaderoEncontrado);
        }

        public static void AgregarSolicitudaGanadero(int solicitudid, string NumDoc){
            var SolicitudEncontrada = _repoSolicitudVisita.ObtenerSolicitudVisita(solicitudid);
            var GanaderoEncontrado = _repoGanadero.ObtenerGanadero(NumDoc);
            GanaderoEncontrado.solicitud = SolicitudEncontrada;
            _repoGanadero.ActualizarGanadero(GanaderoEncontrado);
        }

        public static void AgregarSolicitudaVeterinario(int solicitudid, string NumLicencia){
            var SolicitudEncontrada = _repoSolicitudVisita.ObtenerSolicitudVisita(solicitudid);
            var VeterinarioEncontrado = _repoVeterinario.ObtenerVeterinario(NumLicencia);
            VeterinarioEncontrado.solicitud = SolicitudEncontrada;
            _repoVeterinario.ActualizarVeterinario(VeterinarioEncontrado);
            }

        //Añadir vacunas a GanadoCitaMedica PENDIENTE!!!
        public static void AgregarVacunasaGanado(int NumEjemplar){
            var GanadoControlEncontrado = _repoGanadoControl.ObtenerGanadoControl(NumEjemplar);
            List<Vacuna> vacunas = new List<Vacuna>(); //Crear lista en blanco

            Vacuna vacuna1 = _repoVacuna.ObtenerVacuna(1);
            Vacuna vacuna2 = _repoVacuna.ObtenerVacuna(3);
            //Vacuna vacuna3 = _repoVacuna.ObtenerVacuna();
            vacunas.Add(vacuna1);
            vacunas.Add(vacuna2);
            /*
            Console.WriteLine("La raza del ejemplar al que se van a asociar las vacunas es: "+ GanadoControlEncontrado.Raza);
            Console.WriteLine("La primera vacuna hallada fue: "+ vacuna1.Nombre);
            Console.WriteLine("La segunda vacuna hallada fue: "+ vacuna2.Nombre);
            */
            //Console.WriteLine("Uno de los valores de la lista dentro del objeto es "+ GanadoControlEncontrado.Vacunas[0].Nombre);
            //vacunas[0].Nombre
            //GanadoControlEncontrado.Vacunas = vacunas;
        }

        public static void AgregarVacunasaVeterinario(int vacunaid, string NumLicencia){
            var VacunaEncontrada = _repoVacuna.ObtenerVacuna(vacunaid);
            var VeterinarioEncontrado = _repoVeterinario.ObtenerVeterinario(NumLicencia);
            VeterinarioEncontrado.Vacunas = VacunaEncontrada;
            _repoVeterinario.ActualizarVeterinario(VeterinarioEncontrado);
        }

        public static void AgregarHistoriaAEjemplar(int Historialid, int NumEjemplar){
            var GanadoControlEncontrado = _repoGanadoControl.ObtenerGanadoControl(NumEjemplar);
            var HistorialEncontrado = _repoHistoriaClinica.ObtenerHistoriaClinica(Historialid);
            GanadoControlEncontrado.historia = HistorialEncontrado;
            _repoGanadoControl.ActualizarGanadoControl(GanadoControlEncontrado);
        }

        //*****************************Actualizar objetos*************
        private static void ActualizarGanadero(){
            var ganadero = new Ganadero{
                Id = 1,           //Buscar en local (con Azure u otro) el ID para modificar el objeto
                TipoDocumento = "Pasaporte Extranjero",
                Nombres = "Carlos Javier",
                Apellidos = "Rengifo Mendez",
                NumeroTel = "3217534820",
                Direccion = "Casa finca 108",
                Correo = "correomuestra@pruebaext.com",
                Pass = cifrarPass("5487c"),
                Ubicacion = "Cauca"
            };
            _repoGanadero.ActualizarGanadero(ganadero);
        }

        private static void ActualizarVeterinario(){
            var veterinario = new Veterinario{
                TipoDocumento = "Cedula",
                NumDoc = "1104792631",
                Nombres = "Juan Sebastian",
                Apellidos = "Acosta Rendon",
                NumeroTel = "3115758642",
                Direccion = "Calle 4A # 45-23",
                Correo = "campo25@hotmail.com",
                Pass = cifrarPass("Rtx48JMc"),
                veterinaria = "Maskotas",
                NumLicencia = "7854513",
                Especialidad = "Tratamientos y suturas",
                Vacunas = null,
                solicitud = null
            };
            _repoVeterinario.ActualizarVeterinario(veterinario);
        }

        private static void ActualizarGanado(){
            var ganado = new Ganado{
                Id = 1,
                Genero = 'M',
                Edad = 2,
                Peso = 80.2f,
                Raza = "Jersey"
            };
            _repoGanado.ActualizarGanado(ganado);
        }

        private static void ActualizarGanadoControl(){
            var ganadocontrol = new GanadoCitaMedica{

                NumInv = 1542,
                Genero = 'M',
                Edad = 2,
                Peso = 70.2f,
                Raza = "Angus",
                FechaControl = new DateTime(2021, 8, 1),
                NumEjemplar = 2,
                ModConsulta = "Control",
                Vacunas = null,
                Medico = null,
                historia = null
            };
            _repoGanadoControl.ActualizarGanadoControl(ganadocontrol);
        }

        private static void ActualizarVacuna(){
            var vacuna = new Vacuna{

                Nombre = "Rabigan",
                Descripcion = "Vacuna liquida efectiva contra el virus de la rabia",
                Lote = "L108",
                FechaVen = new DateTime(2022,9,8),
                Labo = "Vecol",
            };
            _repoVacuna.ActualizarVacuna(vacuna);
        }

        private static void ActualizarSolicitudVisita(){
            var solicitud = new SolicitudVisita{

                EstadoVisita="Pendiente",
                EstadoEjemplar="No verificado",
                FechaSolicitud = new DateTime(2021,9,6,13,00,10), //AAAA/MM/DD HH/MM/SS
                FechaVisita = new DateTime()
            };
            _repoSolicitudVisita.ActualizarSolicitudVisita(solicitud);
        }

        private static void ActualizarHistoriaClinica(){
            var historia = new HistoriaClinica{
                Id=3,
                HistorialId = 561
                // EstadoVisita="Pendiente",
                // EstadoEjemplar="No verificado",
                // FechaSolicitud = new DateTime(2021,9,6,13,00,10),
                // FechaVisita = new DateTime(),
                // VacunaApli = null,
                // FechaAplicacion = new DateTime(),
                // VeterinarioAplicante = null,
                // NumDosis = 0,
                // Periodicidad = ""
                
            };
            _repoHistoriaClinica.ActualizarHistoriaClinica(historia);
        }

        //*****************************Borrar objetos*************
        //Borrar sin retornar nada
        private static void BorrarGanadero(string NumDoc){
            _repoGanadero.BorrarGanadero(NumDoc);
        }

        private static void BorrarGanado(int NumInv){
            _repoGanado.BorrarGanado(NumInv);
        }

        private static void BorrarGanadoControl(int NumEjemplar){
            _repoGanadoControl.BorrarGanadoControl(NumEjemplar);
        }

        private static void BorrarVacuna(int idvacuna){
            _repoVacuna.BorrarVacuna(idvacuna);
        }

        private static void BorrarSolicitudVisita(int Ticketid){
            _repoSolicitudVisita.BorrarSolicitudVisita(Ticketid);
        }

        private static void BorrarHistoriaClinica(int HistorialId){
            _repoHistoriaClinica.BorrarHistoriaClinica(HistorialId);
        }

        //Borrar incluyendo mensaje en consola
        private static void BorrarGanaderoConMensaje(string NumDoc){
            var response = _repoGanadero.BorrarGanaderoConMensaje(NumDoc);
            //La anterior línea se puede eliminar si se pone directo en el resultado del string
            string message = response ? "El ganadero se ha eliminado correctamente" : "El ganadero no ha sido encontrado";
            Console.WriteLine(message);
        }

        private static void BorrarVeterinarioConMensaje(string NumLicencia){
            var response = _repoVeterinario.BorrarVeterinarioConMensaje(NumLicencia);
            //La anterior línea se puede eliminar si se pone directo en el resultado del string
            string message = response ? "El veterinario se ha eliminado correctamente" : "El veterinario no ha sido encontrado";
            Console.WriteLine(message);
        }
    }
}