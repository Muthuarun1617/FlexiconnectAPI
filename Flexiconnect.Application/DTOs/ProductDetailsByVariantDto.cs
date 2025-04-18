using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class ProductDetailsByVariantDto
    {
        public string? SalesOrganization { get; set; }
        public string? MaterialId { get; set; }
        public decimal? PricePerUnit { get; set; }
        public decimal? NetBillingRate { get; set; }
        public string? UOM { get; set; }
    }
}
