using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService_WebAPI.Models;

namespace WebService_WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        //Clase de acceso a datos
        private CategoryDAL data;

        public CategoriesController()
        {
            this.data = new CategoryDAL();
        }

        public IEnumerable<Category> GetCategories()
        {
            return data.GetCategories();
        }

        public Category GetCategoryById(string id)
        {
            return data.GetCategoryById(id);
        }

        public IEnumerable<Category> GetCategoryByShortName(string name)
        {
            return data.GetCategoryByShortName(name);
        }

        public int PostCategory([FromBody] Category category)
        {
            return data.InsertCategory(category);
        }

        public int PutCategory(string id, [FromBody] Category category)
        {
            category.CategoryID = id;
            return data.UpdateCategory(category);
        }

        public int DeleteCategory(string id)
        {
            return data.DeleteCategory(id);
        }
    }
}
