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
        public string Description { get; set; }
    }
}
