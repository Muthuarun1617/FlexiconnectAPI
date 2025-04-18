namespace Flexiconnect.Domain.Entities
{
    public class ActionRoleMapping
    {
        public int RoleMappingID { get; set; }  
        public int RoleID { get; set; } 
        public int ActionMenuID { get; set; }
        public string? ActionMenuName { get; set; } 
        public int PermissionID { get; set; }
        public string? PermissionName { get; set; }
        public int IsActive { get; set; }   
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
