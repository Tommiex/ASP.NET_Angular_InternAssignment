namespace CodePulse.API.Models.DTO
{
    public class UpdateUserRequestDto
    {
       public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string RoleType { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public UserPermissionsDto Permissions { get; set; } = new UserPermissionsDto();
    }
}