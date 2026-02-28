using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSearchApp.Entities.Response.Recipe
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public string RecipeUrl { get; set; }
        public string FoodImageUrl { get; set; }
        public string MediumImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public int Pickup { get; set; }
        public int Shop { get; set; }
        public string Nickname { get; set; }
        public string RecipeDescription { get; set; }
        public MaterialDto RecipeMaterial { get; set; }
        public string RecipeIndication { get; set; }
        public string RecipeCost { get; set; }
        public string RecipePublishday { get; set; }
        public string Rank { get; set; }
    }
}
