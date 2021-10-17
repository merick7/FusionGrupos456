using System;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public interface IRepositorioGanadoCitaMedica{
       //Agregar un objeto
        GanadoCitaMedica AgregarGanadoControl(GanadoCitaMedica GanadoMed);

        //Obtener todos los objetos
        IEnumerable<GanadoCitaMedica> ObtenerTodosGanadoControl();

        //Actualizar los objetos 
        GanadoCitaMedica ActualizarGanadoControl(GanadoCitaMedica GanadoMed);
       
        //Eliminar un objeto basado en un ID
        void BorrarGanadoControl(int idGanadoMed);

        //Borrar registro retornando
        Boolean BorrarGanadoControlConMensaje(int idGanadoMed);

        //Obtener uno especifico
        GanadoCitaMedica ObtenerGanadoControl(int idGanadoMed);
    }
}