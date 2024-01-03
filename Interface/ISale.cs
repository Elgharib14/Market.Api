using Backery.DataBase.Entity;

namespace Backery.Interface
{
    public interface ISale
    {
        public Task<IEnumerable<Sale>> GetAll();
        public Task<Sale> Add(Sale opj);
        public Task<Sale> Delet(Sale opj);
    }
}
