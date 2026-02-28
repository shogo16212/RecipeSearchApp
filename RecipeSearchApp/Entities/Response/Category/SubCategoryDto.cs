using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSearchApp.Entities.Response.Category
{
    public class SubCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
        public string ParentCategoryId { get; set; }
    }
}
