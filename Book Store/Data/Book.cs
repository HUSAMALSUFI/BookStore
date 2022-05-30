using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Data
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill BookTitle")]
        public string BookTitle { get; set; }
        [Required(ErrorMessage = "Please fill Year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please fill Price")]
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Authors")]
        public int Authors_Id { get; set; }
        public Authors Authors { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Imagepath { get; set; }
        [Required(ErrorMessage = "Please fill Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please fill Stock")]
        public int Stock { get; set; }

    }
}
