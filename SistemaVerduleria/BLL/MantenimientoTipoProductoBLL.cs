using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class MantenimientoTipoProductoBLL
    {
        public void InsertaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {

            MantenimientoTipoProductoDAL TipoProductoDAL = new MantenimientoTipoProductoDAL();
            TipoProductoDAL.InsertaTipoProducto(Nombre, TipoProducto, TipoPrecio, Cantidad, Precio);

        }

        public void ActualizaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {

            MantenimientoTipoProductoDAL TipoProductoDAL = new MantenimientoTipoProductoDAL();
            TipoProductoDAL.ActualizaTipoProducto(Nombre, TipoProducto, TipoPrecio, Cantidad, Precio);

        }

        public bool ValidaExistenciaProducto(string nombre)
        {
            MantenimientoTipoProductoDAL Producto = new MantenimientoTipoProductoDAL();

            return Producto.ValidaExistenciaProducto(nombre);
        }
    }
}
