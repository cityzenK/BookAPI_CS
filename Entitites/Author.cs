using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Entitites
{
    public class Author
    {
        [Key]
        public int authorID { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string author { get; set; }

        public List<Book> authorBooks { get; set; }
    }
}
