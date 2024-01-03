namespace Backery.DataBase.Entity
{
    public class Sale
    {
        public int Id { get; set; }
        public List<ProductSale> productSales { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

    }
}
