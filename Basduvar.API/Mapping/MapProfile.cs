﻿using AutoMapper;
using Basduvar.API.DTOs;
using Basduvar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basduvar.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category,CategoryDto>();
            CreateMap<CategoryDto,Category>();
        }
    }
}
