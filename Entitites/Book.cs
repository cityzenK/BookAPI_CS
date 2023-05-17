using System.ComponentModel.DataAnnotations;
using BooksAPI.Validations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using BooksAPI.DTOs;

namespace BooksAPI.Entitites
{
    public class Book
    {
        [Key]
        public int bookID { get; set; }
        [Required]
        public string title { get; set; }
        public Author author{ get; set; }
        public int authorID { get; set; }
        [Required]
        public string Resume { get; set; }
        [Required]
        public string cover { get; set; }

        public Saga saga { get; set; }
        public int sagaID { get; set; }
        public Editorial editorial { get; set; }
        public int editorialID { get; set; }

        public List<BookGeners> genersBook { get; set;}

    }
}
