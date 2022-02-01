using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("PRODUCT_INGREDIENTS")]
    public class Product_Ingredient
    {
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Column("INGREDIENT_ID")]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
