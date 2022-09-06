using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private readonly ApplicationDbContext _context;

        public GamesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Games Games)
        {
            _context.Add(Games);
            return Save();
        }

        public bool Delete(Games Games)
        {
            _context.Remove(Games);
            return Save();
        }

        public async Task<IEnumerable<Games>> GetAll()
        {
            return await _context.Games.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Games Games)
        {
            _context.Update(Games);
            return Save();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Games.CountAsync();
        }

 

        public async Task<Games> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Games> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Games.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

  
    }
}