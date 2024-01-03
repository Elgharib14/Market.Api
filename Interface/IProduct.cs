using Backery.DataBase.Entity;

namespace Backery.Interface
{
    public interface IProduct
    {
        public Task<IEnumerable<product>> GetAll();
        public Task<IEnumerable<product>> GetProductByCatId(int categoryid);
        public Task<product> GPetById(int id);
        public Task<product> Add(product opj);
        public product Edit(product opj);
        public product Delet(product opj);
    }
}
