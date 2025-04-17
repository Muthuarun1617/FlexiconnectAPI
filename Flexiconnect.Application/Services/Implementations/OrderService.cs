using AutoMapper;
using Flexiconnect.Application.DTOs;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.Services.Implementations
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderDomain _actionOrderDomain;
        private readonly IMapper _mapper;
        public OrderService(IOrderDomain actionOrder, IMapper mapper)
        {
            _actionOrderDomain = actionOrder;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetDealerByRole(DealerRequest dealerRequest)
        {
            OrderDto actionMenuMaster = new OrderDto();
            Order actionOrder = new Order();
            actionOrder = _mapper.Map<DealerRequest, Order>(dealerRequest);
            var response = await _actionOrderDomain.GetDealerByRole(actionOrder);
            actionMenuMaster = _mapper.Map<Order, OrderDto>(response);

            return actionMenuMaster;
        }
        public async Task<DealerCategory> GetProductFilter(string DealerCode)
        {
            DealerCategory dealerCategory = new DealerCategory();

            ProductFilter productFilter = new ProductFilter();
            var response = await _actionOrderDomain.GetProductFilter(DealerCode);
            dealerCategory = _mapper.Map<Order, DealerCategory>(response);


            return dealerCategory;
        }


        public async Task<ResponseProductCatelogue> GetProductCatalogue(ProductCatelogue productCatelogue)
        {
            Order actionOrder = new Order();
            ResponseProductCatelogue dealerCategory = new ResponseProductCatelogue();
            actionOrder = _mapper.Map<ProductCatelogue, Order>(productCatelogue);

            var response = await _actionOrderDomain.GetProductCatalogue(actionOrder);

            dealerCategory = _mapper.Map<Order, ResponseProductCatelogue>(response);
            return dealerCategory;
            //throw new NotImplementedException();
        }

        public async Task<FrequentlyOrderProducutsDto> GetFrequentlyOrderProducts(string DealerCode)
        {
            FrequentlyOrderProducutsDto frequentlyOrderProducutsDto = new FrequentlyOrderProducutsDto();
            var response = await _actionOrderDomain.GetFrequentlyOrderProducts(DealerCode);
            frequentlyOrderProducutsDto = _mapper.Map<Order, FrequentlyOrderProducutsDto>(response);
            return frequentlyOrderProducutsDto;
        }

        public async Task<ProductDetailsByVariant> GetProductDetailsByVariant(string DealerCode, string Color, string Size, string Dimension, decimal Thickness)
        {
            ProductDetailsByVariant productDetailsByVariant=new ProductDetailsByVariant();
            var response = await _actionOrderDomain.GetProductDetailsByVariant(DealerCode,Color,Size,Dimension,Thickness);
            productDetailsByVariant = _mapper.Map<Order, ProductDetailsByVariant>(response);
            return productDetailsByVariant;
        }

        public async Task<ProductVariant> GetProductsVariant(string DealerCode, string Product)
        {
            ProductVariant productVariant = new ProductVariant();
            var response = await _actionOrderDomain.GetProductsVariant(DealerCode, Product);
            productVariant = _mapper.Map<Order, ProductVariant>(response);
            throw new NotImplementedException();
        }
    }
}
