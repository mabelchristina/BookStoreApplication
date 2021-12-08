using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Model
{
    public class Cart
    {
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Books")]
        public int BookId { get; set; }

        [Required]
        public int NumberOfBooks { get; set; }
        public double Price { get; set; }
    }
}
