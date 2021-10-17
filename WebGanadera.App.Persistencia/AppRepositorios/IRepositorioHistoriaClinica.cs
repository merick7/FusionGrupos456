using System;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia{
    public interface IRepositorioHistoriaClinica{
        //Agregar un objeto
        HistoriaClinica AgregarHistoriaClinica(HistoriaClinica Historia);

        //Obtener todos los objetos
        IEnumerable<HistoriaClinica> ObtenerTodasHistoriaClinica();

        //Actualizar los objetos 
        HistoriaClinica ActualizarHistoriaClinica(HistoriaClinica Historia);
        
        //Eliminar un objeto basado en un ID
        void BorrarHistoriaClinica(int HistorialId);

        //Borrar registro retornando
        Boolean BorrarHistoriaClinicaConMensaje(int HistorialId);

        //Obtener uno especifico
        HistoriaClinica ObtenerHistoriaClinica(int HistorialId);
    }
}