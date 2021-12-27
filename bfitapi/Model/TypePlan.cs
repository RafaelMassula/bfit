using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("TIPO_PLANO")]
    public class TypePlan
    {
        [Column("ID_TIPO_PLANO")]
        [Key]
        public int Id { get; set; }
        [Column("DESCRICAO")]
        [Required]
        [MaxLength(100, ErrorMessage = "Description exceeds max characters.")]
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            TypePlan typePlan = obj as TypePlan;

            return this.Description.ToLower().Equals(typePlan.Description.ToLower()) &&
                (!this.Id.Equals(typePlan.Id));

        }
    }
}
