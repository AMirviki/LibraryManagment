namespace LibraryManagment.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int Copies { get; set; }
        public string ImagePath { get; set; }
        public IFormFile UploadFile { get; set; }
    }
}
