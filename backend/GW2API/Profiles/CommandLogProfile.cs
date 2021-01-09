using AutoMapper;
using BaseModels;
using GW2API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Profiles
{
    public class CommandLogProfile : Profile
    {
        public CommandLogProfile()
        {
            CreateMap<CommandLog, CommandLogDto>();
        }
    }
}
