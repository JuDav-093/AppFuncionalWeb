using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAPPAspNetCore.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public string Saludar()
        {
            return "Hola crack ";
        }

        public List<TipoMedicamentoCLS> ListartipoMedicamento()
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.listarTipoMedicamento();
        }

    }
}
