namespace Flexiconnect.Domain.Entities
{
    public class ActionMenuMaster
    {
        public int ActionMenuID { get; set; }
        public string? ActionMenuName {  get; set; }
        public int IsActive { get; set; }
        public int IsParent { get; set; }
        public int IsDeleted { get; set; }  
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
