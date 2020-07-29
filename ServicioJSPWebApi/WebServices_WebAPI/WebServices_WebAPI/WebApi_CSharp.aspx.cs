using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Data;
using WebServices_WebAPI.Models;
using System.Net.Http;
using Microsoft.Ajax.Utilities;

namespace WebServices_WebAPI
{
    public partial class WebApi_CSharp : System.Web.UI.Page
    {
        // Configurar la url para realizar la petición HTTP
        string url = "http://localhost:65226/api/categories/";
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGridView();
        }

        private void CargarGridView()
        {
            HttpWebRequest solicitud = (HttpWebRequest)WebRequest.Create(url);
            solicitud.Method = "GET";
            solicitud.ContentType = "text/xml; encoding='utf-8'";     
            WebResponse response = solicitud.GetResponse();
            Stream stream = response.GetResponseStream();
            //  StreamReader leedor = new StreamReader(stream);
            //string mensaje = leedor.ReadToEnd();
            DataSet ds = new DataSet();
            ds.ReadXml(stream);
            gvCategories.DataSource = ds.Tables[0];
            gvCategories.DataBind();
        }
        

        protected void gvCategories_PreRender(object sender, EventArgs e)
        {
            gvCategories.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void ButtonInsertar_Click(object sender, EventArgs e)
        {
            if (TextBoxCategoryID.Text!="" && TextBoxLongName.Text!="" && TextBoxShortName.Text!="")
            {
                Label4.Text = "";
                Insertar();
            }
            else
            {
                Label4.Text = "Campos en blanco";
            }
           
        }

        private void Insertar()
        {

            Category categoria = new Category();
            categoria.CategoryID = TextBoxCategoryID.Text;
            categoria.ShortName = TextBoxShortName.Text;
            categoria.LongName = TextBoxLongName.Text;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                var request = cliente.PostAsJsonAsync(url, categoria).Result;
                string result = request.Content.ReadAsStringAsync().Result;
                if (request.IsSuccessStatusCode)
                {
                    if (result == "\"1\"")
                    {                   
                        Label4.Text = "insertado correctamente";
                        CargarGridView();
                        LimpiarCampos();
                    }
                    else if(result != "\"1\"")
                    {
                      
                        Label4.Text = result;
                        
                    }
                }
                else
                {
                    Response.Write("<script> alert ('No se puede consumir el Servicio WEB')</script>");
                }
            }


        }

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
            if (TextBoxCategoryID.Text != "" && TextBoxLongName.Text != "" && TextBoxShortName.Text != "")
            {
                Label4.Text = "";
                Actualizar();
            }
            else
            {
                Label4.Text = "Campos en blanco";
            }
            
        }

        private void Actualizar()
        {
            
                Category categoria = new Category();
                categoria.CategoryID = TextBoxCategoryID.Text;
                categoria.ShortName = TextBoxShortName.Text;
                categoria.LongName = TextBoxLongName.Text;
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(url);
                    var request = cliente.PutAsJsonAsync(url + categoria.CategoryID, categoria).Result;
                    string result = request.Content.ReadAsStringAsync().Result;
                if (request.IsSuccessStatusCode)
                    {
                    if (result == "\"1\"")
                    {
                        Label4.Text = "Actualizado";
                        CargarGridView();
                        LimpiarCampos();
                    }
                    else if (result != "\"1\"")
                    {
                        Label4.Text = "Error no se puede actualizar"+result;
                    }
                }
                    else
                    {
                    Label4.Text = "No se puede consumir el Servicio WEB";
                    }
                }
          
            
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (TextBoxCategoryID.Text != "" && TextBoxLongName.Text != "" && TextBoxShortName.Text != "")
            {
                Label4.Text = "";
                Eliminar();
            }
            else
            {
                Label4.Text = "Campos en blanco";
            }
          
        }

        private void Eliminar()
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                var request = cliente.DeleteAsync(url + TextBoxCategoryID.Text).Result;
                string result = request.Content.ReadAsStringAsync().Result;
                if (request.IsSuccessStatusCode)
                {
                    if (result == "\"1\"")
                    {
                        Label4.Text = "Eliminado correctamente";
                        CargarGridView();
                        LimpiarCampos();
                    }
                    else if (result != "\"1\"")
                    {
                        Label4.Text = "No se puede eliminar: "+result;

                    }
                }
                else
                {
                    Label4.Text = "No se puede consumir el Servicio WEB";
                }
            }
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            TextBoxCategoryID.Text = "";
            TextBoxShortName.Text = "";
            TextBoxLongName.Text = "";
           
        }

        protected void gvCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvCategories.Rows[rowIndex];
            TextBoxCategoryID.Text = row.Cells[1].Text;
            TextBoxShortName.Text = row.Cells[3].Text;
            TextBoxLongName.Text = row.Cells[2].Text;
            Label4.Text = "";
        }

        
    }
}