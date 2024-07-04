namespace LibraryManagment.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int Copies { get; set; }

    }
}
