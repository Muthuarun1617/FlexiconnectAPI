using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Entities
{
    public class ProductVariantRow
    {
        public string SubProductHierarchy { get; set; }
        public string ColorName { get; set; }
        public string Size { get; set; }
        public string Dimension { get; set; }
        public int Thickness { get; set; }
        public string ImageUrl { get; set; }
    }
    public class Order
    {
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? SearchText { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        //}
        //public class DealerResponse
        //{
        public int? currentPage { get; set; }
        //public int? pageSize { get; set; }
        public int? totalRecords { get; set; }
        public bool? hasMore { get; set; }
        public List<DomainDealer>? Dealers { get; set; }
        //Get Product List
        public string? DealerCode { get; set; }
        public List<string>? Categories { get; set; }
        public Dictionary<string, List<string>>? SubCategories { get; set; }
        public string? CATEGORY { get; set; }
        public string? SubCategory { get; set; }
        //Get Product Catalogue
        public List<string> SelectedCategories { get; set; } = new();
        public List<string> SelectedSubCategories { get; set; } = new();
        public List<string> Products { get; set; } = new();
        public string? SalesOrganization { get; set; }
        public string? MaterialId { get; set; }
        public decimal? PricePerUnit { get; set; }
        public decimal? NetBillingRate { get; set; }
        public string? UOM { get; set; }
        //Product Variant
        public string? Product { get; set; }
        public string? ProductDescription { get; set; }
        public List<string> Colors { get; set; } = new();
        public Dictionary<string, List<string>> Images { get; set; } = new();
        public Dictionary<string, List<string>> Sizes { get; set; } = new();
        public Dictionary<string, Dictionary<string, List<string>>> Dimensions { get; set; } = new();
        public Dictionary<string, Dictionary<string, Dictionary<string, List<int>>>> Thickness { get; set; } = new();
    }
    public class DomainDealer
    {
        public string? DealerCode { get; set; }
        public string? DealerName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Region { get; set; }
        public string? BusinessLocation { get; set; }
        public string? ChannelFormat { get; set; }
    }
}
