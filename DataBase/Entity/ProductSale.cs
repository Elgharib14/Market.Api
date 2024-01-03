namespace Backery.DataBase.Entity
{
    public class ProductSale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public int SaleId { get; set; }
    }
}
