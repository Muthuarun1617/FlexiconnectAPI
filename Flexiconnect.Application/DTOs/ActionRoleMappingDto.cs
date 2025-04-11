using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Application.DTOs
{
    public class ActionRoleMappingDto
    {
        public int RoleID { get; set; }
        public int ActionMenuID { get; set; }
        public int PermissionID { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
    }

    public class ActionRoleMappingFetchDto
    {
        public int RoleID { get; set; }
        public int ActionMenuID { get; set; }
        public string? ActionMenuName { get; set; }
        public int PermissionID { get; set; }
        public string? PermissionName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}
