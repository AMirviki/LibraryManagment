using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagment.Models
{
    public class Loan
    {
        public int ID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Navigation Property
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
