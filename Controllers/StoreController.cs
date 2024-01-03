using AutoMapper;
using Backery.DataBase.Entity;
using Backery.Interface;
using Backery.Modell;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStore store;
        private readonly IMapper mapper;

        public StoreController(IStore store, IMapper mapper)
        {
            this.store = store;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await store.GetAll();
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(StoreVM opj)
        {
            var model = mapper.Map<Store>(opj);
            var data = await store.Add(model);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(int id, StoreVM opj)
        {
            var data = await store.GetById(id);
            if (data is null)
            {
                return BadRequest();
            }
            var model = mapper.Map(opj, data);
            store.Edit(model);
            return Ok(model);

        }

        [HttpDelete]
        public async Task<IActionResult> Delet(int id)
        {
            var olddata = await store.GetById(id);
            if (olddata is null)
            {
                return BadRequest();
            }
            var data = store.Delet(olddata);
            return Ok(data);
        }
    }
}
