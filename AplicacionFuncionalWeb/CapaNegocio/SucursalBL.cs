using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SucursalBL
    {
        public List<SucursalCLS> ListarSucursal()
        {
            SucursalDAL sucursalDAL = new SucursalDAL();
            return sucursalDAL.listarSucursal();
        }

        public List<SucursalCLS> filtrarSucursal(SucursalCLS objSuc)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(objSuc);
        }
    }
}