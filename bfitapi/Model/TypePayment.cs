using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("TIPO_PAGAMENTO")]
    public class TypePayment
    {
        [Column("ID_TIPO_PAGAMENTO")]
        [Key]
        public int Id { get; set; }
        [Column("DESCRICAO")]
        [Required]
        [MaxLength(100, ErrorMessage = "Description exceeds max characters.")]
        [MinLength(3, ErrorMessage = "Description required min 3 characters.")]
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            TypePayment typePayment = obj as TypePayment;

            return this.Description.ToLower().Equals(typePayment.Description.ToLower()) &&
                (!this.Id.Equals(typePayment.Id));
        }
    }
}
