using Flexiconnect.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<OrderDto> GetDealerByRole(DealerRequest dealerRequest);
        Task<DealerCategory> GetProductFilter(string DealerCode);
        Task<ResponseProductCatelogue> GetProductCatalogue(ProductCatelogueDto productCatelogue);
        Task<FrequentlyOrderProducutsDto> GetFrequentlyOrderProducts(string DealerCode);
        Task<ProductDetailsByVariantDto> GetProductDetailsByVariant(string DealerCode, string Color, string Size, string Dimension, decimal Thickness);
        Task<ProductVariantDto> GetProductsVariant(string DealerCode, string Product);

    }
}
