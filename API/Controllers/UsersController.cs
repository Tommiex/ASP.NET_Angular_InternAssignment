using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Added 'public' - it was missing in your snippet!
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestDto request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MobileNo = request.MobileNo,
                RoleType = request.RoleType,
                Username = request.Username,
                Password = request.Password,
                Permissions = new UserPermissions
                {
                    SuperAdmin = new PermissionSet
                    {
                        Read = request.Permissions.SuperAdmin.Read,
                        Write = request.Permissions.SuperAdmin.Write,
                        Delete = request.Permissions.SuperAdmin.Delete
                    },
                    Admin = new PermissionSet
                    {
                        Read = request.Permissions.Admin.Read,
                        Write = request.Permissions.Admin.Write,
                        Delete = request.Permissions.Admin.Delete
                    },
                    Employee = new PermissionSet
                    {
                        Read = request.Permissions.Employee.Read,
                        Write = request.Permissions.Employee.Write,
                        Delete = request.Permissions.Employee.Delete
                    }
                }
            };


            user = await userRepository.CreateAsync(user);


            var response = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleType = user.RoleType,
                Username = user.Username,
                Permissions = new UserPermissionsDto
                {
                    SuperAdmin = new PermissionSetDto
                    {
                        Read = user.Permissions.SuperAdmin.Read,
                        Write = user.Permissions.SuperAdmin.Write,
                        Delete = user.Permissions.SuperAdmin.Delete
                    },
                    Admin = new PermissionSetDto
                    {
                        Read = user.Permissions.Admin.Read,
                        Write = user.Permissions.Admin.Write,
                        Delete = user.Permissions.Admin.Delete
                    },
                    Employee = new PermissionSetDto
                    {
                        Read = user.Permissions.Employee.Read,
                        Write = user.Permissions.Employee.Write,
                        Delete = user.Permissions.Employee.Delete
                    }
                }
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();
            var response = new List<UserDto>();
            foreach (var user in users)
            {
                response.Add(new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    MobileNo = user.MobileNo,
                    RoleType = user.RoleType,
                    Username = user.Username,
                    Permissions = new UserPermissionsDto
                    {
                        SuperAdmin = new PermissionSetDto
                        {
                            Read = user.Permissions.SuperAdmin.Read,
                            Write = user.Permissions.SuperAdmin.Write,
                            Delete = user.Permissions.SuperAdmin.Delete
                        },
                        Admin = new PermissionSetDto
                        {
                            Read = user.Permissions.Admin.Read,
                            Write = user.Permissions.Admin.Write,
                            Delete = user.Permissions.Admin.Delete
                        },
                        Employee = new PermissionSetDto
                        {
                            Read = user.Permissions.Employee.Read,
                            Write = user.Permissions.Employee.Write,
                            Delete = user.Permissions.Employee.Delete
                        }
                    }
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        //GET: /api/Users/{id}
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var existingUser = await userRepository.GetById(id);
            if (existingUser is null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email,
                MobileNo = existingUser.MobileNo,
                RoleType = existingUser.RoleType,
                Username = existingUser.Username,

                // Map the nested Permissions structure
                Permissions = new UserPermissionsDto
                {
                    SuperAdmin = new PermissionSetDto
                    {
                        Read = existingUser.Permissions.SuperAdmin.Read,
                        Write = existingUser.Permissions.SuperAdmin.Write,
                        Delete = existingUser.Permissions.SuperAdmin.Delete
                    },
                    Admin = new PermissionSetDto
                    {
                        Read = existingUser.Permissions.Admin.Read,
                        Write = existingUser.Permissions.Admin.Write,
                        Delete = existingUser.Permissions.Admin.Delete
                    },
                    Employee = new PermissionSetDto
                    {
                        Read = existingUser.Permissions.Employee.Read,
                        Write = existingUser.Permissions.Employee.Write,
                        Delete = existingUser.Permissions.Employee.Delete
                    }
                }
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        //GET: /api/Users/{id}
        public async Task<IActionResult> EditUser([FromRoute] Guid id, UpdateUserRequestDto request)
        {
            var user = new User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MobileNo = request.MobileNo,
                RoleType = request.RoleType,
                Username = request.Username,
                Permissions = new UserPermissions
                {
                    SuperAdmin = new PermissionSet
                    {
                        Read = request.Permissions.SuperAdmin.Read,
                        Write = request.Permissions.SuperAdmin.Write,
                        Delete = request.Permissions.SuperAdmin.Delete
                    },
                    Admin = new PermissionSet
                    {
                        Read = request.Permissions.Admin.Read,
                        Write = request.Permissions.Admin.Write,
                        Delete = request.Permissions.Admin.Delete
                    },
                    Employee = new PermissionSet
                    {
                        Read = request.Permissions.Employee.Read,
                        Write = request.Permissions.Employee.Write,
                        Delete = request.Permissions.Employee.Delete
                    }
                }
            };

            var updatedUser = await userRepository.UpdateAsync(user);

            if (updatedUser == null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                Id = updatedUser.Id,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Email = updatedUser.Email,
                MobileNo = updatedUser.MobileNo,
                RoleType = updatedUser.RoleType,
                Username = updatedUser.Username,
                Permissions = request.Permissions
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var deletedUser = await userRepository.DeleteAsync(id);

            if (deletedUser == null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                Id = deletedUser.Id,
                FirstName = deletedUser.FirstName,
                LastName = deletedUser.LastName,
                Email = deletedUser.Email,
                MobileNo = deletedUser.MobileNo,
                RoleType = deletedUser.RoleType,
                Username = deletedUser.Username
            };

            return Ok(response);
        }

    }

}