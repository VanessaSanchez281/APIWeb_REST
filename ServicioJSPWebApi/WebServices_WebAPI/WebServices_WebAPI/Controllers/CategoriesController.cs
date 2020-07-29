using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebServices_WebAPI.Models;

namespace WebServices_WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        //Clase de acceso a datos
        private CategoryDAL data;
        public CategoriesController()
        {
            //Instanciar el objeto.
            this.data = new CategoryDAL();
        }
        
        //Ruta URL: "GET api/categories"
        public IEnumerable<Category> GetCategories()
        {
            return data.GetCategories();
        }
        //Ruta URL: "GET api/categories/masks"
        //NOTA: "Mask" es el valor de ejemplo para el parametro: id
        public Category GetCategoryByID(string id)
        {
            return data.GetCategoryById(id);
        }
        //Ruta URL: "GET api/categories/?name=Masks"
        //NOTA: "Mask" es el valor de ejemplo para el parametro: name
        public IEnumerable<Category> GetCategoryByShortName(string name)
        {
            return data.GetCategoryByShortName(name);
        }
        //Ruta URL: "POST(Insert): api/categories"
        public string PostCategory([FromBody] Category category)
        {
            return data.InsertCategory(category);
        }
        //Ruta URL: "PUT(Update): api/categories/masks"
        public string PutCategory(string id, [FromBody] Category category)
        {
            category.CategoryID = id;
            //Llamar a la Capa de Acceso a Datos
            return data.UpdateCategory(category);
        }
        //Ruta URL: "DELETE: api/categories/masks"
        public string DeleteCategory(string id)
        {
            Category category = new Category();
            category.CategoryID = id;
            //Llamar a la Capa de Acceso a Datos
            return data.DeleteCategory(category);
        }
    }
}
