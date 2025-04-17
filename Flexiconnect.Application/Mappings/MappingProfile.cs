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
            CreateMap<ActionMenuAddDto, ActionMenuMaster>();
            CreateMap<ActionMenuUpdateDto, ActionMenuMaster>();
            CreateMap<ActionMenuDeleteDto, ActionMenuMaster>();
            CreateMap<ActionMenuDto, ActionMenuMaster>();

            CreateMap<ActionPermissionMaster, ActionPermissionDto>();
            CreateMap<ActionPermissionAddDto, ActionPermissionMaster>();
            CreateMap<ActionPermissionUpdateDto, ActionPermissionMaster>();
            CreateMap<ActionPermissionDeleteDto, ActionPermissionMaster>();
            CreateMap<ActionPermissionDto, ActionPermissionMaster>();

            CreateMap<ActionRoleMapping, ActionRoleMappingFetchDto>();
            CreateMap<ActionRoleMappingDto, ActionRoleMapping>();

            CreateMap<DealerRequest, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<DomainDealer, Dealer>();
            CreateMap<Order, DealerCategory>();
            CreateMap<ProductCatelogue, Order>();
            CreateMap<Order, ResponseProductCatelogue>();
            CreateMap<Order, FrequentlyOrderProducutsDto>();
            CreateMap<Order, ProductDetailsByVariant>();
            CreateMap<Order, ProductVariant>();
        }
    }
}
