using Backery.DataBase;
using Backery.DataBase.Entity;
using Backery.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backery.Reposatory
{
    public class CategoryRep : ICategory
    {
        private readonly AppDbContext context;

        public CategoryRep(AppDbContext context) 
        {
            this.context = context;
        }
        public async Task<Category> Add(Category opj)
        {
            await context.categories.AddAsync(opj);  
            context.SaveChanges();
            return opj;
        }

        public Category Delet(Category opj)
        {
           context.categories.Remove(opj);
            context.SaveChanges();
            return opj;
        }

        public Category Edit(Category opj)
        {
            context.categories.Update(opj);
            context.SaveChanges();
            return opj;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
           return await context.categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
           var data = await context.categories.SingleOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
