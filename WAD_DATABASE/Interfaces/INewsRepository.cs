
using WAD_DATABASE.Models;
using WAD_DATABASE.Data;

namespace WAD_DATABASE.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAll();


        Task<News?> GetByIdAsync(int id);

        Task<News?> GetByIdAsyncNoTracking(int id);


        Task<int> GetCountAsync();


        bool Add(News News);

        bool Update(News News);

        bool Delete(News News);

        bool Save();
    }
}