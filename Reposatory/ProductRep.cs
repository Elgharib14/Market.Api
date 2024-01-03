using Backery.DataBase;
using Backery.DataBase.Entity;
using Backery.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backery.Reposatory
{
    public class ProductRep : IProduct
    {
        private readonly AppDbContext context;

        public ProductRep(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<product> Add(product opj)
        {
            await context.products.AddAsync(opj);  
            context.SaveChanges();  
            return opj; 
        }

        public product Delet(product opj)
        {
            context.products.Remove(opj);
            context.SaveChanges();  
            return opj; 
        }

        public product Edit(product opj)
        {
            context.products.Update(opj);
            context.SaveChanges();
            return opj;
        }

        public async Task<IEnumerable<product>> GetAll()
        {
            return await context.products.ToListAsync();
        }

        public async Task<IEnumerable<product>> GetProductByCatId(int categoryid)
        {
            return await context.products.Where(p => p.CategoryId == categoryid).ToListAsync();
        }

        public async Task<product> GPetById(int id)
        {
            return await context.products.SingleOrDefaultAsync(p=>p.Id ==id);
        }
    }
}
