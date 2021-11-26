using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonModel.ResponseModel
{
    public class BookResponse
    {
        /// <summary>
        /// Gets or sets the BookId
        /// </summary>
        [Required]
        public int BookId { get; set; }
        /// <summary>
        /// Gets or sets the BookName
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Book Name is not valid")]
        public string BookTitle { get; set; }

        /// <summary>
        /// Gets or sets the AuthorName
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Author Name is not valid")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Description is not valid")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int BookCount { get; set; }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public string Image { get; set; }

    }
}
