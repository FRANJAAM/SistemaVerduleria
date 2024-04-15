using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MantenimientoTipoProductoDAL
    {
        public void InsertaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {

            DataBaseDAL db = new DataBaseDAL();
            SqlCommand comando = new SqlCommand("SP_RegistraTipoProducto");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            comando.Parameters.AddWithValue("@TipoPrecio", TipoPrecio);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Precio", Precio);

            db.InsercionDatos(comando);
        }

        public void ActualizaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {

            DataBaseDAL db = new DataBaseDAL();
            SqlCommand comando = new SqlCommand("SP_ActualizaTipoProducto");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            comando.Parameters.AddWithValue("@TipoPrecio", TipoPrecio);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Precio", Precio);

            db.InsercionDatos(comando);
        }

        public bool ValidaExistenciaProducto(string Nombre)
        {
            bool existe;

            DataBaseDAL db = new DataBaseDAL();
            SqlCommand comando = new SqlCommand("SP_ConsultaExistenciaProducto");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);

            DataSet ds = db.LecturaDatos(comando, "[T_Productos]");

            if (ds.Tables[0].Rows.Count == 0)
            {
                existe = false;
            }
            else
            {
                existe = true;
            }

            return existe;
        }
    }
}
