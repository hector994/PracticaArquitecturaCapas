using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class PorductoLogica
    {
        //objeto de la clase CategoriaDatos
        private ProductoDatos Datos = new ProductoDatos();

        //obatener categoria
        public Producto GetProducto(int? IdProducto)
        {
            return Datos.GetProductoById(IdProducto);
        }

        //metodo para la seleccion de datos
        public DataTable ListaProducto()
        {
            return Datos.SelectProductoDatos();
        }

        //metodo para agrear una categoria
        public bool AgregarProducto(Producto producto)
        {
            return Datos.InsertProducto(producto);
        }

        public bool ActualizarProducto(Producto producto)
        {
            return Datos.UpdateProducto(producto);
        }

        public bool EliminarProducto(int? IdProducto)
        {
            return Datos.DeleteProducto(IdProducto);
        }
    }
}
