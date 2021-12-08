using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TotalCost { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int BookId { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int AddressId { get; set; }
    }
}
