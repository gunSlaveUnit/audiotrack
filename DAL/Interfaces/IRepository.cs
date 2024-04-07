namespace DAL.Interfaces;

public interface IRepository<T> where T : class, IEntity, new()
{
    public Task<List<T>> GetAsync();
    public Task<T?> GetAsync(string id);
    public Task<T> CreateAsync(T e);
    public Task UpdateAsync(string id, T e);
    public Task RemoveAsync(string id);
}