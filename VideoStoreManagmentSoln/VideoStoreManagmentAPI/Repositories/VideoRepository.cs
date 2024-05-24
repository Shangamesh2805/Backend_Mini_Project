using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Repositories
{
    public class VideoRepository : IRepository<int, Videos>
    {
        public Task<Videos> AddAsync(Videos item)
        {
            throw new NotImplementedException();
        }

        public Task<Videos> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Videos>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Videos> GetByIdAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Videos> Update(Videos item)
        {
            throw new NotImplementedException();
        }
    }
}
