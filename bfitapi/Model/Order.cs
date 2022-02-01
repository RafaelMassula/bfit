using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Model
{
    [Table("ORDERS")]
    public class Order
    {
        [Column("ID_ORDER")]
        [Key]
        public int Id { get; set; }
        [Column("TOTAL", TypeName = ("decimal(18,2"))]
        [Required]
        public int Total { get; set; }
        [Column("DEADLINE")]
        [Required]
        public DateTime Deadline { get; set; }
        [Column("ORDER_DATE")]
        [Required]
        public DateTime OrderDate { get; set; }
        public int PaymentTypeId { get; set; }
        [ForeignKey("ORDER_FK_PAYMENT_TYPE_ID")]
        public PaymentType TypePayment { get; set; }
        public int OrderStatusId { get; set; }
        [ForeignKey("ORDER_FK_STATUS_ID")]
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("ORDER_FK_CUSTOMER_ID")]
        public Customer Customer { get; set; }
    }
}
