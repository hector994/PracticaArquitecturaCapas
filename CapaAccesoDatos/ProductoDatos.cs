using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ProductoDatos
    {
        //realizar la conexion dentro de la clase
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString);

        //metodo para la consulta de datos
        public Producto GetProductoById(int? IdProducto)
        {
            Producto producto = null;
            connection.Open();
            SqlCommand command = new SqlCommand("SelectProducto", connection);
            // declaramos que utilizaremos un procedimiento almacenado
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProducto", IdProducto);
            SqlDataReader dataReader = command.ExecuteReader(); //ejecutamos la consulta
            command.Parameters.Clear(); //limpiamos los parametros

            while (dataReader.Read())
            {
                producto = new Producto()
                {
                    IdProducto = int.Parse(dataReader["IdProducto"].ToString()),
                    NombreProducto = dataReader["NombreProducto"].ToString(),
                    CantidadProducto = int.Parse(dataReader["CantidaProducto"].ToString()),
                    IdCategoria = int.Parse(dataReader["IdCategoria"].ToString()),
                    Descripcion = dataReader["Descripcion"].ToString()
                };
            }

            connection.Close();

            return producto;
        }

        //metodo para la consulta de datos
        public DataTable SelectProductoDatos()
        {
            SqlCommand command = new SqlCommand("SelectProducto", connection);
            command.CommandType = CommandType.StoredProcedure; // declaramos que utilizaremos un procedimiento almacenado
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command); // se almacena y ejecuta.
            DataTable dataTable = new DataTable(); // se crea el data table
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        //Creando  metodo para insertar datos en la tabla categoria
        public bool InsertProducto(Producto producto)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("InsertProducto", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProducto", producto.IdProducto);
            command.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
            command.Parameters.AddWithValue("@CantidadProducto", producto.CantidadProducto);
            command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
            command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            int result = command.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            command.Parameters.Clear(); //limpiamos los parametros
            connection.Close();

            //si las el numero de filas devuelto es mayor a cero significa
            //que los datos se insertaron correctamente
            if (result > 0)
            {
                return true;
            }

            return false;
        }


        //Creando metodo para actualiza datos en la tabla categoria
        public bool UpdateProducto(Producto producto)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UpdateProducto", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProducto", producto.IdProducto);
            command.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
            command.Parameters.AddWithValue("@CantidadProducto", producto.CantidadProducto);
            command.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
            command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            int result = command.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            command.Parameters.Clear(); //limpiamos los parametros
            connection.Close();

            //si las el numero de filas devuelto es mayor a cero significa
            //que los datos se actuliazaron correctamente
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        //metodo para eliminar categoria
        public bool DeleteProducto(int? IdProducto)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DeletePorducto", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProducto", IdProducto);
            int result = command.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            command.Parameters.Clear(); //limpiamos los parametros
            connection.Close();
            //si las el numero de filas devuelto es mayor a cero significa
            //que los datos se actuliazaron correctamente
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
