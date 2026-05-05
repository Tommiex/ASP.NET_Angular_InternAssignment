namespace CodePulse.API.Models.DTO
{
    public class UserPermissionsDto
    {
        public PermissionSetDto SuperAdmin { get; set; } = new PermissionSetDto();
        public PermissionSetDto Admin { get; set; } = new PermissionSetDto();
        public PermissionSetDto Employee { get; set; } = new PermissionSetDto();
    }
}