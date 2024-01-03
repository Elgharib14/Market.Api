using Backery.DataBase;
using Backery.DataBase.Entity;
using Backery.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backery.Reposatory
{
    public class StoreRep : IStore
    {
        private readonly AppDbContext context;

        public StoreRep(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Store> Add(Store opj)
        {
           await context.stores.AddAsync(opj);
            context.SaveChanges();
            return opj;
        }

        public Store Delet(Store opj)
        {
            context.stores.Remove(opj);
            context.SaveChanges();
            return opj;
        }

        public Store Edit(Store opj)
        {
           context.stores.Update(opj);
            context.SaveChanges();
            return opj;
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            return await context.stores.ToListAsync();
        }

        public async Task<Store> GetById(int id)
        {
            return await context.stores.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
