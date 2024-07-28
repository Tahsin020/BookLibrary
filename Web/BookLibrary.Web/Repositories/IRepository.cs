namespace BookLibrary.Web.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(T model);
}
