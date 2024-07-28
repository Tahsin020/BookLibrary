using BookLibrary.Web.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Web.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly BookLibraryDbContext _context;

    public Repository(BookLibraryDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T model)
    {
        _context.Set<T>().Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T model)
    {
        _context.Set<T>().Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T model)
    {
        _context.Set<T>().Update(model);
        await _context.SaveChangesAsync();
    }
}
