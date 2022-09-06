using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;


namespace WAD_DATABASE.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(News News)
        {
            _context.Add(News);
            return Save();
        }

        public bool Delete(News News)
        {
            _context.Remove(News);
            return Save();
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            return await _context.News.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(News News)
        {
            _context.Update(News);
            return Save();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.News.CountAsync();
        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _context.News.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<News> GetByIdAsyncNoTracking(int id)
        {
            return await _context.News.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

    }
}