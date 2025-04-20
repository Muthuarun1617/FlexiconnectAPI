using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class FrequentlyOrderProducutsDto
    {
        public string? DealerCode { get; set; }
        public List<string>? Products { get; set; }
    }
}
