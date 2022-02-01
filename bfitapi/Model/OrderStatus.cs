using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("ORDER_STATUS")]
    public class OrderStatus
    {
        [Column("ID_ORDER_STATUS")]
        [Key]
        public int Id { get; set; }
        [Column("DESCRIPTION")]
        [Required]
        [MaxLength(100, ErrorMessage = "Description exceeds max characters.")]
        public string Description { get; set; }
    }
}
