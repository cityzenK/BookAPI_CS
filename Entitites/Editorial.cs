using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Entitites
{
    public class Editorial
    {
        [Key]
        public int editorialID { get; set; }
        public string editorial { get; set;}
        public List<Book> books { get; set;}
    }
}
