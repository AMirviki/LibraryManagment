using LibraryManagment.Data;
using LibraryManagment.Models;
using LibraryManagment.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{
    public class BookRepository : IBookRepository
    {
        // Only Readable Database 
        private readonly ApplicationDbContext _context;

        #region CTOR
        // CTOR Db_Context to accesse my Database Record
        public BookRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        #endregion

        #region AddMethod
        public async Task AddBookAysnc(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region DeleteMethod
        public async Task Deletebook(int bookid)
        {
            var DeleteConfirmed = await _context.Books.FirstOrDefaultAsync(c => c.ID == bookid);
            if (DeleteConfirmed == null)
            {
                throw new KeyNotFoundException("Book Not Found...!");
            }
            _context.Remove(DeleteConfirmed);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region GetAllMethod
        public async Task<IEnumerable<Book>> GetAllbook()
        {
            return await _context.Books.ToListAsync();
        }
        #endregion

        #region Get Book By ID Method
        public async Task<Book?> GetBookById(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(c => c.ID == bookId);

        }
        #endregion

        #region Update Method
        public async Task Updatebook(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        #endregion

    }
}
