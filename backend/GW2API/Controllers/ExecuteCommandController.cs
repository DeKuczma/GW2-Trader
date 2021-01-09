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
            DateTime lastUpdateTime = _repo.GetLatestLog().LastUpdate;

            if (DateTime.Now < lastUpdateTime.AddHours(1))
                return NoContent();

            IEnumerable<Listing> listingsToAdd = await apiCalls.GetAllListings();

            CommandLog commandLog = new CommandLog();
            commandLog.Deleted = (_repo.GetRecipePricesCount() + _repo.GetTpPricesCount());
            commandLog.CommandExecuted = "update";
            commandLog.Inserted = ((List<Listing>)listingsToAdd).Count;
            commandLog.LastUpdate = DateTime.Now;


            _repo.AddListings(listingsToAdd);
            _repo.AddCommandLog(commandLog);
            if (_repo.SaveChanges())
            {
                CommandLogDto commandLogDto = _mapper.Map<CommandLogDto>(commandLog);
                //TODO: change to add rout in response header
                return Ok(commandLogDto);
            }
            return NotFound();
        }
    }
}
