using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Entitites
{
    public class Saga
    {
        [Key]
        public int sagaID { get; set; }
        public string saga { get; set; }
        public List<Book> books { get; set; }
    }
}
