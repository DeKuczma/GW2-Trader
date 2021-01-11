using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GW2API.Dtos;
using BaseModels;
using GW2API.Datas;
using AutoMapper;

namespace GW2API.Controllers
{
    [Route("api/Logs")]
    [ApiController]
    public class CommandLogController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        public CommandLogController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CommandLogDto> GetLatestUpdate()
        {
            CommandLog commandLog = _repo.GetLatestLog();
            if(commandLog != null)
            {
                CommandLogDto commandLogDto = _mapper.Map<CommandLogDto>(_repo.GetLatestLog());
                return Ok(commandLogDto);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<CommandLogDto> GetLogById(int id)
        {
            CommandLog commandLog = _repo.GetLogById(id);
            if(commandLog != null)
            {
                CommandLogDto commandLogDto = _mapper.Map<CommandLogDto>(commandLog);
                return Ok(commandLogDto);
            }
            return NotFound();
        }
    }
}
