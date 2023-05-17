namespace BooksAPI.Entitites
{
    public class BookGeners
    {
        public int generID { get; set; }
        public Gener Gener { get; set; }
        public int bookID { get; set; }
        public Book Book { get; set; } 
    }
}
