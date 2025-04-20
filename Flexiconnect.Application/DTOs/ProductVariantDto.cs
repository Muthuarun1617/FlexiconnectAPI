using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class ProductVariantDto
    {
        public string? DealerCode { get; set; }
        public string? Product { get; set; }
        public string? ProductDescription { get; set; }

        public List<string> Colors { get; set; } = new();
        public Dictionary<string, List<string>> Images { get; set; } = new();
        public Dictionary<string, List<string>> Sizes { get; set; } = new();
        public Dictionary<string, Dictionary<string, List<string>>> Dimensions { get; set; } = new();
        public Dictionary<string, Dictionary<string, Dictionary<string, List<int>>>> Thickness { get; set; } = new();
    }
}
