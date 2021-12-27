using bfitapi.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("PRODUCTS")]
    public class Product
    {
        public Product(int id, string description, decimal price, int size, DateTime manufactoringDate)
        {
            Id = id;
            Description = description;
            Price = price;
            Size = size;
            ManufactoringDate = this.CheckeManufactoringDate(manufactoringDate);
            ExpirationDate = manufactoringDate.AddDays(90); ;
        }
        public Product(int id)
        {
            Id = id;
        }

        [Column("ID_PRODUCT")]
        [Key]
        public int Id { get; set; }
        [Column("DESCRIPTION")]
        [Required]
        [MaxLength(120, ErrorMessage = "Description exceeds max characters.")]
        public string Description { get; set; }
        [Column("PRICE")]
        [Required]
        public decimal Price { get; set; }
        [Column("SIZE")]
        [Required]
        public int Size { get; set; }
        [Column("MANUFACTORING_DATE")]
        [Required]
        public DateTime ManufactoringDate { get; set; }
        [Column("EXPIRATION_DATE")]
        [Required]
        public DateTime ExpirationDate { get; set; }
        public IList<Photo> Photos { get; set; }

        public override bool Equals(object obj)
        {
            Product product = obj as Product;

            return this.Description.ToLower().Equals(product.Description.ToLower()) &&
                (!this.Id.Equals(product.Id));

        }

        private DateTime CheckeManufactoringDate(DateTime manufactoringDate)
        {
            int diferenceBeteewDate = DateTime.Now.Subtract(manufactoringDate).Days;
            if(diferenceBeteewDate >= 90) throw new DateManufactoringGreaterNinetyDaysException(manufactoringDate);
            return manufactoringDate;

        }
    }
}
