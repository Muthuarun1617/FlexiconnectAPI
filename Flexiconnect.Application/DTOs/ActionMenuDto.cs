namespace Flexiconnect.Application.DTOs
{
    public class ActionMenuDto
    {
        public int ActionMenuID { get; set; }
        public string? ActionMenuName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }

    public class ActionMenuAddDto
    {
        public string? ActionMenuName { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }

    }

    public class ActionMenuUpdateDto
    {
        public int ActionMenuID { get; set; }
        public string? ActionMenuName { get; set; }
        public int IsActive { get; set; }
        public int ModifiedBy { get; set; }

    }

    public class ActionMenuDeleteDto
    {
        public int ActionMenuID { get; set; }
        public int ModifiedBy { get; set; }
    }
}
