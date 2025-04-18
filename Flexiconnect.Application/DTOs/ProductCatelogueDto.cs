using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class ProductCatelogueDto
    {
        public string? DealerCode { get; set; }
        public List<string> SelectedCategories { get; set; } 
        public List<string> SelectedSubCategories { get; set; }
        public string? SearchText { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
    public class  ResponseProductCatelogue
    {
        public int? currentPage { get; set; }
        public int? pageSize { get; set; }
        public int? totalRecords { get; set; }
        public bool? hasMore { get; set; }
        public List<string> Products { get; set; } = new();

    }
}
