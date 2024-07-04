using LibraryManagment.Data;
using LibraryManagment.Models;
using LibraryManagment.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Services
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        #region CTOR
        public LoanRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        #endregion

        #region AddMethod
        public async Task AddloanAysnc(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();  
        }
        #endregion

        #region Delete Method
        public async Task DeleteLoanAysnc(int id)
        {
            var DeleteConfiremd = await _context.Loans.FindAsync(id);
            if(DeleteConfiremd!=null)
            {
                 _context.Remove(DeleteConfiremd);
            }
         await  _context.SaveChangesAsync();
        }
        #endregion

        #region GetAllMethod
        public async Task<IEnumerable<Loan>> GetAllLoanAysnc()
        {
           return await _context.Loans.ToListAsync();
        }
        #endregion

        #region GetByIDMethod
        public async Task<Loan?> GetLoanByIdAysnc(int id)
        {
            return await _context.Loans.FirstOrDefaultAsync(c => c.ID == id);
        }
        #endregion

        #region UpdateMethod
        public async Task UpdateLoanAysnc(Loan loan)
        {
             _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
