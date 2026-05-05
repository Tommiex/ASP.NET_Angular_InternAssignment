namespace CodePulse.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string RoleType { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Nested object for permissions
        public UserPermissions Permissions { get; set; } = new UserPermissions();
    }

    public class UserPermissions
    {
        public PermissionSet SuperAdmin { get; set; } = new PermissionSet { Read = true, Write = true, Delete = true };
        public PermissionSet Admin { get; set; } = new PermissionSet { Read = true };
        public PermissionSet Employee { get; set; } = new PermissionSet { Read = true };
    }

    public class PermissionSet
    {
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
    }
}