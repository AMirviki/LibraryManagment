using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagment.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        public int Copies { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
