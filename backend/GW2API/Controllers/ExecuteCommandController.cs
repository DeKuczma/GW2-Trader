using Microsoft.AspNetCore.Mvc;
using GW2API.Datas;
using GW2API.Models;
using GW2API.Dtos;
using AutoMapper;

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
        public ActionResult PostExeuteCommand(ExecuteCommandReadDto commandDto)
        {
            ExecuteCommand command = _mapper.Map<ExecuteCommandReadDto, ExecuteCommand>(commandDto);
            if(command == null)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
