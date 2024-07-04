using LibraryManagment.Models;

namespace LibraryManagment.Repositories
{
    public interface ILoanRepository
    {
        //Get All Loan As List (I Use Enumrable)
        Task<IEnumerable<Loan>> GetAllLoanAysnc();
        // Get Olny 1 Loan
        Task<Loan?> GetLoanByIdAysnc(int id);
        // Add new Loan
        Task AddloanAysnc(Loan loan);
        // Update Loan Information
        Task UpdateLoanAysnc(Loan loan);
        // Delete Loan 
        Task DeleteLoanAysnc(int id);
        
    }
}
