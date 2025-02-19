using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAPPAspNetCore.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult SinMenu()
        //{
        //    return View();
        //}


        //public string saludar(string name)
        //{
        //    return "Hello " + name;
        //}

        public List<TipoMedicamentoCLS> ListartipoMedicamento()
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.listarTipoMedicamento();
        }

        public List<TipoMedicamentoCLS> FiltrartipoMedicamento(string nombre)
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.filtrarTipoMedicamento(nombre);
        }
    }
}
