using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseModels;
using GW2API.Dtos;

namespace GW2API.Profiles
{
    public class RecipePriceProfile : Profile
    {
        public RecipePriceProfile()
        {
            CreateMap<RecipePrice, RecipePriceDto>();
        }
    }
}
