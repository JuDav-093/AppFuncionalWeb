using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LaboratorioBL
    {
        public List<LaboratorioCLS> ListarLaboratorio()
        {
            LaboratorioDAL lab = new LaboratorioDAL();
            return lab.listarLaboratorios();
        }

        public List<LaboratorioCLS> filtrarLaboratorio(LaboratorioCLS objLab)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.filtrarLaboratorios(objLab);
        }

    }
}
