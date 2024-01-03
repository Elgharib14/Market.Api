using AutoMapper;
using Backery.DataBase.Entity;
using Backery.Modell;

namespace Backery.Mapper
{
    public class DemoProfile :Profile
    {
        public DemoProfile()
        {
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();

            CreateMap<product, ProductVM>();
            CreateMap<ProductVM, product>();

            CreateMap<Store, StoreVM>();
            CreateMap<StoreVM, Store>();

            CreateMap<Sale, SaleVM>();
            CreateMap<SaleVM, Sale>();

            CreateMap<ProductSaleVM, ProductSale>();
            CreateMap<ProductSale, ProductSaleVM>();
        }
    }
}
