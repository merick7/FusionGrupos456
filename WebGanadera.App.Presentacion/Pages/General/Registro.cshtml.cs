using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGanadera.App.Dominio;
using WebGanadera.App.Persistencia;

namespace WebGanadera.App.Presentacion.Pages
{
    public class RegistroModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        public IEnumerable<Ganadero> ganaderos { get; private set;}
        public IEnumerable<Veterinario> veterinarios { get; private set;}
        public List<Ganadero> Ganaderos { get; set;}
        public void OnGet()
        {
            ganaderos = _repoGanadero.ObtenerTodosGanaderos();
        }

        public void OnPostAgregar(Ganadero ganadero, Veterinario veterinario){
            if (ganadero != null ) //&& veterinario.NumLicencia == null && veterinario.Especialidad == null
            {
                _repoGanadero.AgregarGanadero(ganadero);
            }
            else if(veterinario != null) //&& veterinario.NumLicencia == null && veterinario.Especialidad == null
            {
                _repoVeterinario.AgregarVeterinario(veterinario);
            }
            ganaderos = _repoGanadero.ObtenerTodosGanaderos();
            veterinarios = _repoVeterinario.ObtenerTodosVeterinarios();
        }
    }
}
