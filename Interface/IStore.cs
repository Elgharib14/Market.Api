using Backery.DataBase.Entity;

namespace Backery.Interface
{
    public interface IStore
    {
        public Task<IEnumerable<Store>> GetAll();
        public Task<Store> GetById(int id);
        public Task<Store> Add(Store opj);
        public Store Edit(Store opj);
        public Store Delet(Store opj);
    }
}
