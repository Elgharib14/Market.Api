using AutoMapper;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;
        private readonly IMapper mapper;

        public CategoryController(ICategory category, IMapper mapper) 
        {
            this.category = category;
            this.mapper = mapper;
        }


        [HttpGet]
        public  async Task<IActionResult> Get() 
        { 
            var data = await category.GetAll();
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryVM opj)
        {
            var model = mapper.Map<Category>(opj);    
            var data = await category.Add(model);
            return Ok(data);
        }
        [HttpPut("Edit /{id}")]
        public  async Task<IActionResult> Edit(int id,CategoryVM opj)
        {
            var data = await category.GetById(id);
            if (data is null)
            {
                return BadRequest();
            }
            var model= mapper.Map(opj, data);
            category.Edit(model);
            return Ok(model);    
            
        }

        [HttpDelete("Delet /{id}")]
        public async Task<IActionResult> Delet(int id)
        {
            var olddata = await category.GetById(id);
            if (olddata is null)
            {
                return BadRequest();
            }
            var data = category.Delet(olddata);
            return Ok(data);
        }
    }
}
