using AutoMapper;
using Azure.Core;
using Backery.DataBase;
using Backery.DataBase.Entity;
using Backery.Interface;
using Backery.Modell;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly ISale sale;

        public SaleController(AppDbContext context ,IMapper mapper, ISale sale)
        {
            this.context = context;
            this.mapper = mapper;
            this.sale = sale;
        }

        [HttpPost("sales")]
        public async Task<ActionResult<Sale>> AddSale([FromBody] SaleVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            var sales = mapper.Map<Sale>(request);
            sales.Date = DateTime.Now;
            sales.Time = DateTime.Now;
           
            var data = await sale.Add(sales);
           

            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sals = await sale.GetAll();
            //var data = mapper.Map<IEnumerable<SaleVM>>(sals);
            return Ok(sals);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletSale(int id)
        {
            var data =  context.sales.Include(x=>x.productSales).Where(x=>x.Id == id).SingleOrDefault();
            if (data is null)
                BadRequest(ModelState);
          
            var saledelet = sale.Delet(data);
            return Ok(saledelet);

        }

    }
}
