using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class LaboratorioDAL : CadenaDAL
    {
        public List<LaboratorioCLS> listarLaboratorios()
        {
            List<LaboratorioCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            LaboratorioCLS laboratorio;
                            lista = new List<LaboratorioCLS>();
                            while (dr.Read())
                            {
                                laboratorio = new LaboratorioCLS();
                                laboratorio.iddlaboratorio = dr.GetInt32(0);
                                laboratorio.nombre = dr.GetString(1);
                                laboratorio.direccion = dr.GetString(2);
                                laboratorio.personacontacto = dr.GetString(3);

                                lista.Add(laboratorio);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    lista = null;
                    throw;
                }
            }
            return lista;
        }

        public List<LaboratorioCLS> filtrarLaboratorios(LaboratorioCLS objLab)
        {
            List<LaboratorioCLS> lista = null;



            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", objLab.nombre ?? "");
                        cmd.Parameters.AddWithValue("@direccion", objLab.direccion ?? "");
                        cmd.Parameters.AddWithValue("@personacontacto", objLab.personacontacto ?? "");
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            LaboratorioCLS olaboratorioCLS;
                            lista = new List<LaboratorioCLS>();
                            while (dr.Read())
                            {
                                olaboratorioCLS = new LaboratorioCLS();
                                olaboratorioCLS.iddlaboratorio = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                olaboratorioCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                olaboratorioCLS.direccion = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                olaboratorioCLS.personacontacto = dr.IsDBNull(3) ? "" : dr.GetString(3);

                                lista.Add(olaboratorioCLS);
                            }
                        }
                    }
               }
               catch (Exception)
                {
                    cn.Close();
                    lista = null;
                    throw;

               }
            }
            return lista;

    }

 }


}
