using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class DealerCategory
    {
        public string? DealerCode { get; set; }
        public List<string>? Categories { get; set; }
        public Dictionary<string, List<string>>? SubCategories { get; set; }
        //public string? CATEGORY { get; set; }
        //public string? SubCategory { get; set; }
    }
}
