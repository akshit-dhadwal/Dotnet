using DataLayer.ContextFiles;
using DataLayer.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class BaseRepository(UserDbContext context) : IBaseRepository
    {
        private readonly UserDbContext _context = context;
        public void Add<T>(T item)
        {
            context.Add(item);
        }
        public void AddRange<T>(IEnumerable<T> items)
        {
            _context.AddRange(items);
        }
        public void Delete<T>(T item)
        {
            _context.Remove(item);
        }
        public void DeleteRange<T>(IEnumerable<T> items)
        {
            _context.RemoveRange(items);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Update<T>(T item)
        {
            _context.Update(item);
        }
        public void UpdateRange<T>(IEnumerable<T> items)
        {
            _context.UpdateRange(items);
        }
    }
}
