using Microsoft.AspNetCore.Mvc;
using GW2API.Datas;
using GW2API.Models;
using GW2API.Dtos;
using AutoMapper;
using System;
using BaseModels;
using GW2API.APICalls;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GW2API.Controllers
{
    [Route("api/execute_command")]
    [ApiController]
    public class ExecuteCommandController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        public ExecuteCommandController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CommandLogDto>> PostExeuteCommand(ExecuteCommandReadDto commandDto, [FromServices]IApiCalls apiCalls)
        {
            ExecuteCommand command = _mapper.Map<ExecuteCommandReadDto, ExecuteCommand>(commandDto);
            if(command == null)
            {
                return BadRequest();
            }


            switch(command.Command)
            {
                case "update":
                    return await UpdateDb(apiCalls);
                default:
                    return BadRequest();
            }
        }

        private async Task<ActionResult<CommandLogDto>> UpdateDb(IApiCalls apiCalls)
        {
            //DateTime lastUpdateTime = _repo.GetLatestLog().LastUpdate;

            //if (DateTime.Now < lastUpdateTime.AddHours(1))
            //    return NoContent();

            //_repo.ClearListings();
            //IEnumerable<Listing> listingsToAdd = await apiCalls.GetAllListings();

            //_repo.AddListings(listingsToAdd);

            //CommandLog commandLog = new CommandLog();
            //commandLog.Deleted = (_repo.GetRecipePricesCount() + _repo.GetTpPricesCount());
            //commandLog.CommandExecuted = "update";
            //commandLog.LastUpdate = DateTime.Now;
            //commandLog.Inserted = _repo.GetListingsCount();
            //_repo.AddCommandLog(commandLog);

            SetAllRecipesCreationPrice();

            //if (_repo.SaveChanges())
            //{
            //    //return NotFound();
            //    CommandLogDto commandLogDto = _mapper.Map<CommandLogDto>(commandLog);
            ////TODO: change to add rout in response header
            //    return Ok(commandLogDto);
            //}

            return NotFound();
        }

        private void SetAllRecipesCreationPrice()
        {
            foreach(var recipe in _repo.GetAllRecipes().ToList())
            {
                List<Ingredient> allIngredients = recipe.Ingredients;
                if(recipe.GuildIngredients != null)
                    allIngredients.AddRange(recipe.GuildIngredients);

                List<TPListing> itemListings = _repo.GetItemBuyOrder(recipe.OutputItemId);
                RecipePrice recipePrice = new RecipePrice();
                recipePrice.ItemId = recipe.OutputItemId;
                int? itemPrice;

                if (itemListings == null || itemListings.Count == 0)
                {
                    itemPrice = null;
                    recipePrice.PossibleToBuy = false;
                    _repo.AddRecipePrice(recipePrice);
                    continue;
                }

                itemPrice = (int)(itemListings[0].UnitPrice * 0.85);

                int? creationPriceBuyNow = 0;
                int? creationPriceBuyOrder = 0;

                foreach (var ingredient in allIngredients)
                {
                    List<TPListing> ingredientListings = _repo.GetItemSellOrder(ingredient.ItemId);
                    int? ingredientPrice = GetItemIngredientPrice(ingredient, ingredientListings);
                    if(ingredientPrice == null)
                        creationPriceBuyNow = null;
                    else if(creationPriceBuyNow != null)
                    {
                        creationPriceBuyNow += ingredientPrice;
                    }

                    ingredientListings = _repo.GetItemBuyOrder(ingredient.ItemId);
                    ingredientPrice = GetItemIngredientPrice(ingredient, ingredientListings);
                    if (ingredientPrice == null)
                        creationPriceBuyOrder = null;
                    else if (creationPriceBuyOrder != null)
                    {
                        creationPriceBuyOrder += ingredientPrice;
                    }
                }

                if(creationPriceBuyNow != null)
                    recipePrice.CreationPriceBuyNow = itemPrice.Value - creationPriceBuyNow.Value;
                if(creationPriceBuyOrder != null)
                    recipePrice.CreationPriceBuyOrder = itemPrice.Value - creationPriceBuyOrder.Value;
                if (creationPriceBuyOrder != null && creationPriceBuyNow != null)
                    recipePrice.PossibleToBuy = false;
                else
                    recipePrice.PossibleToBuy = true;
                _repo.AddRecipePrice(recipePrice);
            }
        }

        private int? GetItemIngredientPrice(Ingredient ingredient, List<TPListing> listings)
        {
            if (listings == null)
                return null;
            int? creationPrice = 0;
            int remaining = ingredient.Count;
            int listingIndex = 0;
            while (remaining > 0 && listingIndex < listings.Count)
            {
                creationPrice += 1;
                if(listings[listingIndex].Quantity >= remaining)
                {
                    creationPrice += remaining * listings[listingIndex].UnitPrice;
                    remaining = 0;
                }
                else
                {
                    creationPrice += listings[listingIndex].Quantity * listings[listingIndex].UnitPrice;
                    remaining -= listings[listingIndex].Quantity;
                    listingIndex++;
                }
            }

            if (remaining != 0)
                return null;
            return creationPrice;
        }
    }
}
