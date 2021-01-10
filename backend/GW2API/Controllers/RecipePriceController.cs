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
    [Route("api/crafting")]
    [ApiController]
    public class RecipePriceController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;
        public RecipePriceController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<RecipePrice>> GetAllRecipePrice()
        {
            IEnumerable<RecipePrice> recipePrices = _repo.GetAllRecipePrices();
            if (recipePrices == null)
                return NoContent();
            IEnumerable<RecipePriceDto> recipePricesDto = _mapper.Map<IEnumerable<RecipePriceDto>>(recipePrices);
            return Ok(recipePricesDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipePrice> GetRecipePriceById(int id)
        {
            RecipePrice recipePrice = _repo.GetRecipePriceById(id);
            if (recipePrice == null)
                return NoContent();
            return Ok(_mapper.Map<RecipePriceDto>(recipePrice));
        }

        [HttpGet("profitable/{buyOrder}")]
        public ActionResult<IEnumerable<RecipePrice>> GetProfitableRecipePrice(bool buyOrder)
        {
            IEnumerable<RecipePrice> recipePrices;
            if (buyOrder)
                recipePrices = _repo.GetRecipePriceByBuyOrderProfit().OrderByDescending(v => v.CreationPriceBuyOrder);
            else
                recipePrices = _repo.GetRecipePriceByBuyNowProfit().OrderByDescending(v => v.CreationPriceBuyNow);
            if (recipePrices == null)
                return NoContent();
            return Ok(_mapper.Map<IEnumerable<RecipePriceDto>>(recipePrices));
        }
    }
}
