import { Component, computed, inject, signal } from '@angular/core';
import { ButtonComponent } from '../../../shared/components/button-component/button-component';
import { AddUserPopup } from '../add-user-popup/add-user-popup';
import { UserService } from '../services/user-service';
import { User } from '../../../shared/models/user.model';


@Component({
  selector: 'app-user-list',
  imports: [ButtonComponent, AddUserPopup],
  templateUrl: './user-list.html',
  styleUrl: './user-list.css',
})
export class UserList {

  private userService = inject(UserService);
  private getAllUsersRef = this.userService.getAllUsers();

  isLoading = this.getAllUsersRef.isLoading;
  isError = this.getAllUsersRef.error;
  isPopupVisible: boolean = false;
 
  selectedUserForEdit: User | null = null;
  sortKey = signal<string>('name');

  value = computed(() => {
    const users = this.getAllUsersRef.value() || [];
    const key = this.sortKey();

    return [...users].sort((a, b) => {
      if (key === 'name') {
        return a.firstName.localeCompare(b.firstName);
      } else if (key === 'role') {
        return a.roleType.localeCompare(b.roleType);
      }
      return 0;
    });
  });

  refreshList() {
    this.getAllUsersRef.reload();
  }

  sortUsers(key: string) {
    this.sortKey.set(key);
  }
  

  getRoleClass(role: string): string {
    switch (role.toLowerCase()) {
      case 'superadmin': return 'bg-blue-500 text-white';
      case 'admin': return 'bg-sky-400 text-white';
      default: return 'bg-slate-200 text-slate-600';
    }
  }

  deleteUser(id: string): void {
  if (confirm('Are you sure you want to delete this user?')) {
    this.userService.deleteUser(id).subscribe({
      next: () => {
        this.refreshList(); 
      },
      error: (err) => console.error('Delete failed', err)
    });
  }
}

  openAddUserPopup() {
    this.selectedUserForEdit = null; // Clear selection for "Add"
    this.isPopupVisible = true;
  }

  openEditPopup(user: User) {
    this.selectedUserForEdit = user; // Set selection for "Edit"
    this.isPopupVisible = true;
  }

  closePopup(): void {
    this.isPopupVisible = false;
    this.selectedUserForEdit = null;
  }
}
