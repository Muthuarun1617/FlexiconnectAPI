using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Entities
{
    public class ActionMenuMaster
    {
        public int ActionMenuID { get; set; }
        public string? ActionMenuName {  get; set; }
        public int IsActive { get; set; }
        public int IsParent { get; set; }   
    }
}
