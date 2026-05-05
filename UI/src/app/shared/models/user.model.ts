// Define the permission structure first
export interface PermissionSetDto {
  read: boolean;
  write: boolean;
  delete: boolean;
}

export interface UserPermissionsDto {
  superAdmin: PermissionSetDto;
  admin: PermissionSetDto;
  employee: PermissionSetDto;
}

// The main Create User Request DTO
export interface CreateUserRequestDto {
  firstName: string;
  lastName: string;
  email: string;
  mobileNo: string;
  roleType: string;
  username: string;
  password: string;
  permissions: UserPermissionsDto;
}

export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  mobileNo: string;
  roleType: string;
  username: string;
  permissions: UserPermissionsDto;
}
