using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class ActionPermissionDto
    {
        public int PermissionID { get; set; }
        public string? PermissionName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }

    public class ActionPermissionAddDto
    {
        public string? PermissionName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }

    }

    public class ActionPermissionDeleteDto
    {
        public int PermissionID { get; set; }
        public int ModifiedBy { get; set; }
    }
}
