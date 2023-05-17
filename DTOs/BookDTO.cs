using BooksAPI.Entitites;
using System.ComponentModel.DataAnnotations;

namespace BooksAPI.DTOs
{
    public class BookDTO
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public  authorDTO author { get; set; }
        public int authorID { get; set; }
        public string Resume { get; set; }
        public string cover { get; set; }
        public SagaDTO saga { get; set; }
        public int sagaID { get; set; }
        public EditorialDTO editorial { get; set; }
        public int editorialID { get; set; }
        public List<GenerDTO> genersBook { get; set; }
    }
}
