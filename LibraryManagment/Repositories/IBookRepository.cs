using LibraryManagment.Models;

namespace LibraryManagment.Repositories
{
    public interface IBookRepository
    {
        // GetAll Book Like List
        Task<IEnumerable<Book>> GetAllbook();
        //Get By ID 1 Book
        Task<Book?> GetBookById(int bookId);
        //Add New Book
        Task AddBookAysnc(Book book);
        //Update Book Information
        Task Updatebook(Book book);
        // Delete Book From List
        Task Deletebook(int bookid);


    }
}
