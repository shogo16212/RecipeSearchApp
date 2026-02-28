using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSearchApp.Entities.Response.Category
{
    public class LargeData
    {
        public List<CategoryDto> Large { get; set; }
        public List<SubCategoryDto> Medium { get; set; }
        public List<SubCategoryDto> Small { get; set; }
    }
}
