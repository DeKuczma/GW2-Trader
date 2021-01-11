using AutoMapper;
using BaseModels;
using GW2API.Datas;
using GW2API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;
        public ItemController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetAllItems()
        {
            IEnumerable<Item> items = _repo.GetAllItems();
            if (items == null)
                return NotFound();

            IEnumerable<ItemDto> itemsDto = _mapper.Map<IEnumerable<ItemDto>>(items);

            return Ok(itemsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItemById(int id)
        {
            Item item = _repo.GetItemById(id);
            if (item == null)
                return NotFound();
            ItemDto itemDto = _mapper.Map<ItemDto>(item);
            return Ok(itemDto);
        }
    }
}
