using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class SucursalDAL : CadenaDAL
    {
        public List<SucursalCLS> listarSucursal()
        {
            List<SucursalCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            SucursalCLS sucursal;
                            lista = new List<SucursalCLS>();
                            while (dr.Read())
                            {
                                sucursal = new SucursalCLS();
                                sucursal.idSucursal = dr.GetInt32(0);
                                sucursal.nombre = dr.GetString(1);
                                sucursal.direccion = dr.GetString(2);

                                lista.Add(sucursal);
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

        public List<SucursalCLS> filtrarSucursal(SucursalCLS objSuc)
        {
            List<SucursalCLS> lista = null;

            

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", objSuc.nombre ?? "");
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            SucursalCLS osucursalCLS;
                            lista = new List<SucursalCLS>();
                            while (dr.Read())
                            {
                                osucursalCLS = new SucursalCLS();
                                osucursalCLS.idSucursal = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                osucursalCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                osucursalCLS.direccion = dr.IsDBNull(2) ? "" : dr.GetString(2);

                                lista.Add(osucursalCLS);
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
