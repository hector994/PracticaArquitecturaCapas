using CapaEntidad;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion

{
    public partial class Productos : System.Web.UI.Page
    {
        //creamos un objeto de la clase CategoriaLogica que se encuentra en la
        //capa de logica negocios
        private PorductoLogica Logica = new PorductoLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["eliminar"] != null)
            {
                int idCategoria = int.Parse(Request["eliminar"]);

                if (Logica.EliminarProducto(idCategoria))
                {
                    Response.Redirect("~/Categorias.aspx");
                }
                else {

                    string alertError = "Swal.fire({";
                    alertError += "icon: 'error',";
                    alertError += "title: 'Oops...',";
                    alertError += "text: 'El registro de pudo ser eliminado',";
                    alertError += "footer: '<a>Ingresa aqui para obtener más información?</a>'";
                    alertError += "})";

                    ScriptManager.RegisterClientScriptBlock(
                        this, this.GetType(), "script", alertError, true
                    );
                }
            }
        }

        //Creamos funcion para el evento oclick del boton guadar
        protected void ButtonGuadarCategoria_Click(object sender, EventArgs e)
        {
            //verficamos que las si las entradas estan vacias
            if (TextBoxNombreCategoria.Text == "" || TextBoxDescripcionCategoria.Text == "")
            {
                return;
            }

            Producto model = new Producto
            {
                NombreProducto = TextBoxNombreCategoria.Text,
                Descripcion = TextBoxDescripcionCategoria.Text
            };

            //varificamos el resultado
            bool resultado = Logica.AgregarProducto(model);

            if (resultado)
            {
                //refrecamos nustra pagina
                Response.Redirect("~/Categorias.aspx");
            }
        }


    }
}