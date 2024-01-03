using Backery.DataBase.Entity;
using System.Globalization;

namespace Backery.Modell
{
    public class SaleVM
    {
        public List<ProductSaleVM> productSales { get; set; }
        public DateTime Date { get; set; } 
        public DateTime Time { get; set; }
    }
}
