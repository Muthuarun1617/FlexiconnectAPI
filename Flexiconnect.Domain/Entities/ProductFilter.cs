using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Entities
{
    public class ProductFilter
    {
        public string? DealerCode { get; set; }
        public List<string>? Categories { get; set; }
        public Dictionary<string, List<string>>? SubCategories { get; set; }
    }
}
