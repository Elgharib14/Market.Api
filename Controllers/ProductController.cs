using AutoMapper;
using Backery.DataBase.Entity;
using Backery.Interface;
using Backery.Modell;
using Microsoft.AspNetCore.Mvc;

namespace Backery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct product;
        private readonly IMapper mapper;

        public ProductController(IProduct product, IMapper mapper)
        {
            this.product = product;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await product.GetAll();
            return Ok(data);
        }

        [HttpGet("category /{categoryid}")]
        public async Task<IActionResult> GetByCategoryID(int categoryid)
        {
            var data = await product.GetProductByCatId(categoryid);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM opj)
        {
            var model = mapper.Map<product>(opj);
            var data = await product.Add(model);
            return Ok(data);
        }

        [HttpPut("Update /{id}")]
        public async Task<IActionResult> Update(int id, ProductVM opj)
        {
            var olddata = await product.GPetById(id);
            if(olddata is null)
            {
                return BadRequest();
            }
            var model = mapper.Map(opj, olddata);
            var data = product.Edit(model);
            return Ok(data);
        }


        [HttpDelete("Delet /{id}")]
        public async Task<IActionResult> Delet(int id)
        {
            var olddata = await product.GPetById(id);
            if (olddata is null)
            {
                return BadRequest();
            }
            product.Delet(olddata);
            return Ok(olddata);
        }
    }
}
