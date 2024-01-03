using Azure.Core;
using Backery.DataBase;
using Backery.DataBase.Entity;
using Backery.Interface;
using Backery.Migrations;
using Backery.Modell;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backery.Reposatory
{
    public class SaleRep : ISale
    {
        private readonly AppDbContext context;

        public SaleRep(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Sale> Add(Sale opj)
        {
            context.sales.Add(opj);
            await context.SaveChangesAsync();

            foreach (var item in opj.productSales)
            {
                var store = await context.stores.FirstOrDefaultAsync(s => s.ProductName == item.Name);
                if (store != null)
                {
                    if (item.quantity > store.Quantity)
                    {
                        throw new Exception("The quantity in the store cannot achieve this amount.");
                    }
                }
                    store.Quantity -= item.quantity;
                    context.Entry(store).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                }

            
            return opj;
        }

        public  async Task<Sale> Delet(Sale opj)
        {
            context.sales.Remove(opj!);
             context.SaveChanges();

            foreach (var item in opj.productSales)
            {
                var store = await context.stores.FirstOrDefaultAsync(s => s.ProductName == item.Name);
                if (store != null)
                {
                    store.Quantity += item.quantity;
                    context.Entry(store).State = EntityState.Modified;
                     context.SaveChanges();
                }

            }
            return opj;
            
        }

        public async Task<IEnumerable<Sale>> GetAll()
        {
            return await context.sales.Include(x => x.productSales).ToListAsync();
        }
    }
}
