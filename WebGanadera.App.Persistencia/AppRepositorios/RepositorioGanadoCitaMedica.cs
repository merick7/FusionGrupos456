using System;
using System.Linq;
using WebGanadera.App.Dominio;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebGanadera.App.Persistencia{
    public class RepositorioGanadoCitaMedica:IRepositorioGanadoCitaMedica{
        private readonly AppContext _appContext;

        public RepositorioGanadoCitaMedica(AppContext appContext){
            _appContext = appContext;
        }

        //Añadirlo
        GanadoCitaMedica IRepositorioGanadoCitaMedica.AgregarGanadoControl(GanadoCitaMedica GanadoControl){
            var GanadoCitaMedicaAgregado = _appContext.GanadoControl.Add(GanadoControl);
            _appContext.SaveChanges();
            return GanadoCitaMedicaAgregado.Entity;
        }

        //Listarlos
        IEnumerable<GanadoCitaMedica> IRepositorioGanadoCitaMedica.ObtenerTodosGanadoControl(){
            return _appContext.GanadoControl;
        }

        //Actualizar datos
        GanadoCitaMedica IRepositorioGanadoCitaMedica.ActualizarGanadoControl(GanadoCitaMedica GanadoControl) {
            var GanadoCitaMedicaEncontrado = _appContext.GanadoControl.FirstOrDefault(g => g.NumEjemplar == GanadoControl.NumEjemplar);

            if (GanadoCitaMedicaEncontrado != null){
                GanadoCitaMedicaEncontrado.Genero = GanadoControl.Genero;
                //GanadoCitaMedicaEncontrado.Edad = GanadoControl.Edad;
                GanadoCitaMedicaEncontrado.Peso = GanadoControl.Peso;
                //GanadoCitaMedicaEncontrado.Raza = GanadoControl.Raza;
                GanadoCitaMedicaEncontrado.FechaControl = GanadoControl.FechaControl;
                //GanadoCitaMedicaEncontrado.NumEjemplar = GanadoControl.NumEjemplar;
                GanadoCitaMedicaEncontrado.ModConsulta = GanadoControl.ModConsulta;
                GanadoCitaMedicaEncontrado.Vacunas = GanadoControl.Vacunas;
                GanadoCitaMedicaEncontrado.Medico = GanadoControl.Medico;
                GanadoCitaMedicaEncontrado.historia = GanadoControl.historia;

                _appContext.SaveChanges();
            }
            return GanadoCitaMedicaEncontrado;
        }
        
        //Eliminar un objeto sin retornar ningún valor
        void IRepositorioGanadoCitaMedica.BorrarGanadoControl(int idGanado){
            //Se busca el Id primero
            var GanadoCitaMedicaEncontrado = _appContext.GanadoControl.FirstOrDefault(g => g.NumEjemplar == idGanado);

            if (GanadoCitaMedicaEncontrado != null){
                _appContext.GanadoControl.Remove(GanadoCitaMedicaEncontrado);
                _appContext.SaveChanges();
            }else{
                Console.WriteLine("No se ha encontrado el ganado asociado al ID");}
        }
        
        //Obtener un objeto de acuerdo al ID
        GanadoCitaMedica IRepositorioGanadoCitaMedica.ObtenerGanadoControl(int idGanado) {
            var GanadoCitaMedicaEncontrado = _appContext.GanadoControl.Where(g => g.NumEjemplar == idGanado).Include(g=>g.Medico).FirstOrDefault();
            return GanadoCitaMedicaEncontrado;
        }
        
        //Retornar un mensaje cuando se elimina
        Boolean IRepositorioGanadoCitaMedica.BorrarGanadoControlConMensaje(int idGanado) {
            var GanadoCitaMedicaEncontrado = _appContext.GanadoControl.FirstOrDefault(g => g.NumEjemplar == idGanado);
            if (GanadoCitaMedicaEncontrado != null)
            {
                _appContext.GanadoControl.Remove(GanadoCitaMedicaEncontrado);
                _appContext.SaveChanges();

                return true;
            } 
            return false;
        }
    }
}