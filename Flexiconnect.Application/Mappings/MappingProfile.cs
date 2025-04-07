using AutoMapper;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ActionMenuMaster, ActionMenuDto>();
        }
    }
}
