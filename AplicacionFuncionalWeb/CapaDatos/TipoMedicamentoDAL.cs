using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class TipoMedicamentoDAL  : CadenaDAL
    {
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            TipoMedicamentoCLS otipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);

                                lista.Add(otipoMedicamentoCLS);
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



            /*
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();

            lista.Add(new TipoMedicamentoCLS
            {
                idTipoMedicamento = 1,
                nombre = "Analgésicos",
                descripcion = "Desc1",
                stock = 5
            });

            lista.Add(new TipoMedicamentoCLS
            {
                idTipoMedicamento = 2,
                nombre = "Antialérgicos",
                descripcion = "Desc2",
                stock = 6
            });

            lista.Add(new TipoMedicamentoCLS
            {
                idTipoMedicamento = 3,
                nombre = "Anticonceptivo",
                descripcion = "Desc3",
                stock = 1
            });

            return lista;
            */
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            List<TipoMedicamentoCLS> lista = null;

            

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombretipomedicamento", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            TipoMedicamentoCLS otipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);

                                lista.Add(otipoMedicamentoCLS);
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

