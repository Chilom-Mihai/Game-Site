
using WAD_DATABASE.Models;
using WAD_DATABASE.Data;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Interfaces
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Games>> GetAll();


        Task<Games?> GetByIdAsync(int id);

        Task<Games?> GetByIdAsyncNoTracking(int id);

        

        Task<int> GetCountAsync();

       

        bool Add(Games Games);

        bool Update(Games Games);

        bool Delete(Games Games);

        bool Save();
    }
}