using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Column("ID_CUSTOMER")]
        [Key]
        public int Id { get; set; }
        [Column("NAME")]
        [Required]
        public string Name { get; set; }
        [Column("CPF")]
        [Required]
        public string Cpf { get; set; }
        [Column("SEX")]
        [Required]
        public Char Sex { get; set; }
        [Column("EMAIL")]
        [Required]
        public string Email { get; set; }
        [Column("BIRTH_DATE")]
        [Required]
        public DateTime BirthDate { get; set; }

        public IList<Address> Adresses { get; set; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            return this.Cpf.Equals(customer.Cpf) || this.Email.ToLower().Equals(customer.Email.ToLower());
        }
    }

}
