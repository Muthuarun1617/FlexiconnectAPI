using Flexiconnect.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Interfaces
{
    public interface IOrderDomain
    {
        Task<Order> GetDealerByRole(Order dealerRequest);
        Task<Order> GetProductFilter(string DealerCode);
        Task<Order> GetProductCatalogue(Order ProductCatalogue);
        Task<Order> GetFrequentlyOrderProducts(string DealerCode);
        Task<Order> GetProductDetailsByVariant(string DealerCode, string Color, string Size, string Dimension, decimal Thickness);
        Task<Order> GetProductsVariant(string DealerCode,string Product);
    }
}
