using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DataBaseDAL
    {
        public SqlConnection Conexion { get; set; }
        public SqlConnection AbreConexionSQL()
        {
            string ser = "DESKTOP-3TAVB1D\\SQLEXPRESS";
            string database = "SistemaVerduleria";
            string us = "sa";
            string pw = "Welcome123*";

            String con = $"Data source={ser}; Initial Catalog={database}; User Id={us}; Password={pw}; Integrated Security=false; TrustServerCertificate=true;"; 

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(con);
                builder.ConnectTimeout = 30;  // Establece el tiempo de espera de la conexión según tus necesidades

                SqlConnection sqlConexion = new SqlConnection(builder.ConnectionString);

                sqlConexion.Open();

                if (sqlConexion.State != ConnectionState.Open)
                {
                    throw new Exception("No fue posible registrar el producto, intente nuevamente. [Error de conexión]");
                }

                return sqlConexion;
            }
            catch (Exception ex)
            {
                ex.Source += " Conexion " + con;
                throw ex;
            }
        }


        public DataSet LecturaDatos(SqlCommand sqlCommand, String tabla)
        {

            DataSet dsTabla = new DataSet();
            try
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(sqlCommand))
                {
                    sqlCommand.Connection = AbreConexionSQL();
                    dsTabla = new DataSet();
                    adaptador.Fill(dsTabla, tabla);
                }
                return dsTabla;
            }
            catch (Exception ex)
            {
                ex.Source += " SQL: " + sqlCommand.CommandText.ToString();
                throw ex;
            }
            finally
            {
                Dispose();
            }

        }


        public int InsercionDatos(SqlCommand sqlCommand)
        {

            int registrosafectados = 0;
            try
            {

                sqlCommand.Connection = AbreConexionSQL();

                registrosafectados = sqlCommand.ExecuteNonQuery();

                return registrosafectados;

            }
            catch (Exception ex)
            {
                ex.Source += " SQL: " + sqlCommand.CommandText.ToString();
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (Conexion != null)
                Conexion.Close();
        }

    }
}
