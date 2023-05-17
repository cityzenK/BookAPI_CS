using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Entitites
{
    public class HomeBook
    {
        [Key]
        public int bookID { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
    }
}
