using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoPHP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        public HttpResponseMessage ConexionServicio(string servicio)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/rest/public/api/");
            var request = cliente.GetAsync(servicio).Result;
            return request;
        }
        public List<Category> ObtenerCategorias()
        {
            try
            {
                if (ConexionServicio("category").IsSuccessStatusCode)
                {
                    var resultadoJson = ConexionServicio("category").Content.ReadAsStringAsync().Result;
                    var listaEstudiantes = JsonConvert.DeserializeObject<List<Category>>(resultadoJson);
                    return listaEstudiantes;
                }
            }
            catch (Exception)
            {

                Mensaje("No se puede conectar con el servidor");
            }
            return null;

        }

        public void InsertarCategoria()
        {
            try
            {
                Category category = new Category();
                category.CategoryID = txtId.Text;
                category.ShortName = txtNombreCorto.Text;
                category.LongName = txtNombreLargo.Text;

                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:8080/rest/public/api/category/");
                var request = cliente.PostAsync("nuevo", category, new JsonMediaTypeFormatter()).Result;
                var resultadoJson = request.Content.ReadAsStringAsync().Result;
                if (request.IsSuccessStatusCode)
                {
                    if (request.IsSuccessStatusCode)
                    {
                        if (resultadoJson == "\"Cliente Guardado\"")
                        {
                           Mensaje("Cliente Guardado");
                           CargarGridView();
                           LimpiarCampos();
                            LimpiarUltimo();
                        }
                        else if(resultadoJson != "\"Cliente Guardado\"")
                        {
                            lblMensajeError.Text = resultadoJson;
                            LimpiarCampos();
                        }
                    }
                }
                else
                {
                    Mensaje("No se puede conectar con el servidor");
                }
            }
            catch (Exception)
            {

                Mensaje("No se puede conectar con el servidor");
            }
            
        }

        public void ActualizarCategoria()
        {
            try
            {
                Category category = new Category();
                category.ShortName = txtNombreCorto.Text;
                category.LongName = txtNombreLargo.Text;

                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:8080/rest/public/api/category/");
                var request = cliente.PutAsync("actualizar/" + txtId.Text, category, new JsonMediaTypeFormatter()).Result;
                var resultadoJson = request.Content.ReadAsStringAsync().Result;
                if (request.IsSuccessStatusCode)
                {


                    if (request.IsSuccessStatusCode)
                    {
                        if (resultadoJson == "\"Cliente Actualizado\"")
                        {
                            Mensaje("Cliente Actualizado");
                            CargarGridView();
                            LimpiarCampos();
                            LimpiarUltimo();
                        }
                        else if (resultadoJson != "\"Cliente Actualizado\"")
                        {
                            lblMensajeError.Text = resultadoJson;
                            Mensaje("No se pudo Actualizar");
                            LimpiarCampos();
                        }
                    }

                }
                else
                {
                    Mensaje("No se puede conectar con el servidor");
                }
            }
            catch (Exception)
            {

                Mensaje("No se puede conectar con el servidor");
            }
        }

        public void EliminarCategoria()
        {

            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:8080/rest/public/api/category/");
                var request = cliente.DeleteAsync("eliminar/" + txtId.Text).Result;
                var resultadoJson = request.Content.ReadAsStringAsync().Result;
                   
                    if (request.IsSuccessStatusCode)
                    {
                        if (resultadoJson == "\"Cliente No Eliminado\"")
                        {
                            Mensaje("Cliente Eliminado");
                            CargarGridView();
                            LimpiarCampos();
                        LimpiarUltimo();
                    }
                        else if (resultadoJson != "\"Cliente No Eliminado\"")
                        {
                        lblMensajeError.Text = resultadoJson;
                        LimpiarCampos();
                        }
                    


                    //foreach (GridViewRow row in gvCategories.Rows)
                    //{
                    //    string aux = (string)Session["auxGlobal"];
                    //    var dato = row.Cells[1].Text;
                    //    if (dato == (string)Session["auxGlobal"])
                    //    {
                    //        Mensaje("No se puede Eliminar Tiene Relaciones Foraneas");
                    //        break;
                    //    }
                    //}
                    
                }
                else
                {
                    Mensaje("No se puede conectar con el servidor");
                }
            }
            catch (Exception)
            {

                Mensaje("No se puede conectar con el servidor");
            }
            
        }


            public void CargarGridView()
              {

            try { 
                    gvCategories.DataSource = ObtenerCategorias();
                    gvCategories.DataBind();
            }
            catch (NullReferenceException)
            {
                gvCategories.EmptyDataText = "Lista Vacía";
                gvCategories.DataBind();
                CamposBloqueados();
                Mensaje("No se puede conectar con el servidor");
            }
          
        }
        public void CamposBloqueados()
        {
            txtId.Enabled = false;
            txtNombreLargo.Enabled = false;
            txtNombreCorto.Enabled = false;
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;

        }
        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombreLargo.Text = "";
            txtNombreCorto.Text = "";
            Button1.Visible = true;
            Button2.Visible = false;
            txtId.ReadOnly = false;
           
       }
        public void LimpiarUltimo()
        {
            lblMensajeError.Text = "";
        }
        public void Mensaje(string message)
        {
            string script = "<script language=\"javascript\">alert('" + message + "');</script>";

            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "CERRAR", script, false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertarCategoria();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ActualizarCategoria();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EliminarCategoria();
           
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
       
        }

        protected void gvCategories_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvCategories.HeaderRow.TableSection = TableRowSection.TableHeader;
            Session["auxGlobal"] = gvCategories.Rows[e.NewSelectedIndex].Cells[1].Text;
            txtId.Text = gvCategories.Rows[e.NewSelectedIndex].Cells[1].Text;
            txtNombreLargo.Text = gvCategories.Rows[e.NewSelectedIndex].Cells[3].Text;
            txtNombreCorto.Text = gvCategories.Rows[e.NewSelectedIndex].Cells[2].Text;
            txtId.ReadOnly = true;
            Button1.Visible = false;
            Button2.Visible = true;
        }
    }
}