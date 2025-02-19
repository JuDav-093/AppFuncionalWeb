using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAPPAspNetCore.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SucursalCLS> ListarSucursal()
        {
            SucursalDAL suc = new SucursalDAL();
            return suc.listarSucursal();
        }


        public List<SucursalCLS> FiltrarSucursal(SucursalCLS objSucursal)
        {
            if (objSucursal == null)
            {
                objSucursal = new SucursalCLS();
            }
            SucursalBL obj = new SucursalBL();
            return obj.filtrarSucursal(objSucursal);
        }
    }
}
