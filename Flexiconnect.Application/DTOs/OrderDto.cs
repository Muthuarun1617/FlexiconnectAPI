using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class OrderDto
    {
        public int? currentPage { get; set; }
        public int? pageSize { get; set; }
        public int? totalRecords { get; set; }
        public bool? hasMore { get; set; }
        public List<Dealer>? Dealers { get; set; }
    }
    public class Dealer
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
    public class DealerRequest
    {
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? SearchText { get; set; }
        public int?  CurrentPage{ get; set; }
        public int? PageSize { get; set; }
    }
}
