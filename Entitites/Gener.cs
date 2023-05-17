using System.ComponentModel.DataAnnotations;
using BooksAPI.Validations;
using System;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Entitites
{
    public class Gener
    {
        [Key]
        public int generID { get; set; }
        [Required]
        public string gener { get; set; }

        public List<BookGeners> booksGeners { get; set;}
    }
}
