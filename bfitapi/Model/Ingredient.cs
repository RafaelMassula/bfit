using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("INGREDIENTS")]
    public class Ingredient
    {
        [Column("ID_INGREDIENT")]
        public int Id { get; set; }
        [Column("DESCRIPTION")]
        [Required]
        [MaxLength(120, ErrorMessage = "Description exceeds max characters.")]
        public string Description { get; set; }
        [Column("AMOUNT", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Amount { get; set; }
        public ICollection<Product_Ingredient> Product_Ingredients { get; set; }
    }
}
