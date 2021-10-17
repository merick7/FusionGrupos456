using System;
using WebGanadera.App.Dominio;
using System.Collections.Generic;

namespace WebGanadera.App.Persistencia {
    public interface IRepositorioVacuna {
        //Agregar un objeto
        Vacuna AgregarVacuna(Vacuna vacuna);

        //Obtener todos los objetos
        IEnumerable<Vacuna> ObtenerTodasVacunas();

        //Actualizar los objetos 
        Vacuna ActualizarVacuna(Vacuna vacuna);
       
        //Eliminar un objeto basado en un ID
        void BorrarVacuna(int idvacuna);

        //Borrar registro retornando
        Boolean BorrarVacunaConMensaje(int idvacuna);

        //Obtener uno especifico
        Vacuna ObtenerVacuna(int idvacuna);

    }
}