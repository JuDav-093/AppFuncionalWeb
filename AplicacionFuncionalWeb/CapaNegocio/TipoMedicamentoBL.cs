using CapaDatos;
using CapaEntidad;
using System.Reflection.Metadata.Ecma335;

namespace CapaNegocio
{
    public class TipoMedicamentoBL
    {
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