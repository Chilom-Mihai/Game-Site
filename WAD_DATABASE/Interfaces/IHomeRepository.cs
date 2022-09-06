
using WAD_DATABASE.Models;
using WAD_DATABASE.Data;

namespace WAD_DATABASE.Interfaces
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Home>> GetAll();

        //Task<IEnumerable<Home>> GetSliceAsync(int offset, int size);

        //Task<IEnumerable<Home>> GetClubsByState(string state);

        //Task<IEnumerable<Home>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size);

        //Task<List<State>> GetAllStates();

        //Task<List<City>> GetAllCitiesByState(string state);

        Task<Home?> GetByIdAsync(int id);

        Task<Home?> GetByIdAsyncNoTracking(int id);

        //Task<IEnumerable<Home>> GetClubByCity(string city);

        Task<int> GetCountAsync();

        //Task<int> GetCountByCategoryAsync(ClubCategory category);

        bool Add(Home home);

        bool Update(Home home);

        bool Delete(Home home);

        bool Save();
    }
}