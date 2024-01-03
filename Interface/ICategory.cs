using Backery.DataBase.Entity;

namespace Backery.Interface
{
    public interface ICategory
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetById(int id);
        public Task<Category> Add(Category opj);
        public Category Edit(Category opj);
        public Category Delet(Category opj);


    }
}
