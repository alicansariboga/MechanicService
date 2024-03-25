﻿namespace MechanicService.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity); //listing
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        // add-update-delete
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}