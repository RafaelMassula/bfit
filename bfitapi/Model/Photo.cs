using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("PHOTOS")]
    public class Photo
    {
        [Column("ID_PHOTOS")]
        [Key]
        public int Id { get; set; }
        [Column("BYTES")]
        public byte[] Bytes { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("FILE_EXTENSION")]
        public string FileExtension { get; set; }
        [Column("SIZE")]
        public decimal Size { get; set; }
        [Column("PRODUCT_ID")]
        [ForeignKey("PRODUCT_ID")]
        public Product Product_Id { get; set; }
    }
}
