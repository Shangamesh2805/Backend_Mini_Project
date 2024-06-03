namespace VideoStoreManagmentAPI.Repositories.Interfaces
{
    public interface IRepository<K, T> where T : class
    {


        public Task<T> AddAsync(T item);
        public Task<T> Delete(K key);
        public Task<T> Update(T item);
        public Task<T> GetByIdAsync(K key);
        public Task<IEnumerable<T>> GetAllAsync();
<<<<<<< HEAD

=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
        Task SaveChangesAsync();
    }
}
