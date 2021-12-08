using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Model
{
    public class WishList
    {
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int BookId { get; set; }
    }
}
