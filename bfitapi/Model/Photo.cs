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
        public Photo(byte[] bytes, string description, string contentType, string fileExtension, long size)
        {
            Bytes = bytes;
            Description = description;
            ContentType = contentType;
            FileExtension = fileExtension;
            Size = size;
        }

        [Column("ID_PHOTOS")]
        [Key]
        public int Id { get; set; }
        [Column("BYTES")]
        public byte[] Bytes { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("CONTENT_TYPE")]
        public string ContentType { get; set; }
        [Column("FILE_EXTENSION")]
        public string FileExtension { get; set; }
        [Column("SIZE")]
        public long Size { get; set; }
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
