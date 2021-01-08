﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GW2API.Dtos;
using GW2API.Models;

namespace GW2API.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<ExecuteCommandReadDto, CommandsProfile>();
        }
    }
}