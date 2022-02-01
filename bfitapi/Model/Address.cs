using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("ADRESS")]
    public class Address
    {
        [Column("ID_ADRESS")]
        [Key]
        public int Id { get; set; }
        [Column("ROAD")]
        [Required]
        [MaxLength(120, ErrorMessage = "Road exceeds max characters.")]
        public string Road { get; set; }
        [Column("NEIGHBORHOOD")]
        [Required]
        [MaxLength(120, ErrorMessage = "Neighborhood exceeds max characters.")]
        public string Neighborhood { get; set; }
        [Column("CITY")]
        [Required]
        [MaxLength(120, ErrorMessage = "City exceeds max characters.")]
        public string City { get; set; }
        [Column("NUMBER")]
        [Required]
        [MaxLength(8, ErrorMessage = "Number exceeds max characters.")]
        public string Number { get; set; }
        [Column("ZIP_COD")]
        [Required]
        [MaxLength(9, ErrorMessage = "Zip cod exceeds max characters.")]
        public string ZipCod { get; set; }
        [Column("ADRESS_COMPLEMENT")]
        [MaxLength(10, ErrorMessage = "Adress complement exceeds max characters.")]
        public string AdressComplement { get; set; }
        [Column("STATE")]
        [Required]
        [MaxLength(2, ErrorMessage = "State exceeds max characters.")]
        public string State { get; set; }
        [Column("COUNTRY")]
        [Required]
        [MaxLength(70, ErrorMessage = "Country exceeds max characters.")]
        public string Country { get; set; }
        public Customer Customer { get; set; }
        [Column("CUSTOMER_ID")]
        [ForeignKey("CUSTOMER_ID")]
        public int CustomerId { get; set; }
    }
}
