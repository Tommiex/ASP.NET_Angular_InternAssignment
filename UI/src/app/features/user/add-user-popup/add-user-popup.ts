import { CommonModule } from '@angular/common';
import { Component, effect, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CreateUserRequestDto, User } from '../../../shared/models/user.model';
import { UserService } from '../services/user-service';

@Component({
  selector: 'app-ad-user-popup',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-user-popup.html',
  styleUrl: './add-user-popup.css',
})
export class AddUserPopup {
  constructor(){
    effect(()=>{
      if(this.userService.addUserStatus()=='success'){
        console.log("success")
      }
      if(this.userService.addUserStatus()=='error'){
        console.error('Add user request failed')
      }
    })
  }
  
  private userService = inject(UserService)
  @Input() selectedUser: User | null = null;
  @Output() close = new EventEmitter<void>();
  @Output() userAdded = new EventEmitter<void>();
  roles = [['Admin', 'admin'], ['Super Admin','superAdmin'], ['Employee','employee']];
  modules = ['Super Admin', 'Admin', 'Employee'];
  addUserFormGroup = new FormGroup({
    firstName: new FormControl<string>('', { nonNullable: true, validators: Validators.required }),
    lastName: new FormControl<string>('', { nonNullable: true, validators: Validators.required }),
    email: new FormControl<string>('', { nonNullable: true, validators: [Validators.required, Validators.email] }),
    mobileNo: new FormControl<string>('', { nonNullable: true, validators:[ Validators.required, Validators.maxLength(10)]}),
    roleType: new FormControl<string>('', { nonNullable: true, validators: Validators.required }),
    username: new FormControl<string>('', { nonNullable: true, validators: Validators.required }),
    password: new FormControl<string>('', { nonNullable: true, validators: Validators.required }),
    confirmPassword: new FormControl<string>('', {
      nonNullable: true,
      validators: Validators.required,
    }),
    permissions: new FormGroup({
      superAdmin: new FormGroup({
        read: new FormControl<boolean>(true, { nonNullable: true }),
        write: new FormControl<boolean>(true, { nonNullable: true }),
        delete: new FormControl<boolean>(true, { nonNullable: true }),
      }),
      admin: new FormGroup({
        read: new FormControl<boolean>(true, { nonNullable: true }),
        write: new FormControl<boolean>(false, { nonNullable: true }),
        delete: new FormControl<boolean>(false, { nonNullable: true }),
      }),
      employee: new FormGroup({
        read: new FormControl<boolean>(true, { nonNullable: true }),
        write: new FormControl<boolean>(false, { nonNullable: true }),
        delete: new FormControl<boolean>(false, { nonNullable: true }),
      }),
    }),
  });

  ngOnInit() {
    if (this.selectedUser) {
      // Patch the form 
      this.addUserFormGroup.patchValue(this.selectedUser);
      
      this.addUserFormGroup.controls.password.clearValidators();
      this.addUserFormGroup.controls.confirmPassword.clearValidators();
      this.addUserFormGroup.controls.password.updateValueAndValidity();
      this.addUserFormGroup.controls.confirmPassword.updateValueAndValidity();
    }
  }
  get nameFromControl(){
    return this.addUserFormGroup.controls.firstName;
  }
 
  onSubmit = () => {
    console.log('submit');
    console.log(this.addUserFormGroup.value);
    const addUserFromValue = this.addUserFormGroup.getRawValue()
    const addUserRequestDto: CreateUserRequestDto = {
      firstName: addUserFromValue.firstName,
      lastName: addUserFromValue.lastName,
      email: addUserFromValue.email,
      mobileNo: addUserFromValue.mobileNo,
      roleType: addUserFromValue.roleType,
      username: addUserFromValue.username,
      password: addUserFromValue.password,
      permissions: addUserFromValue.permissions
    }

   if (this.selectedUser) {     
      this.userService.updateUser(this.selectedUser.id, addUserRequestDto).subscribe({
        next: () => {
          this.userAdded.emit();
          this.close.emit();    
        },
        error: (err) => console.error('Update failed', err)
      });
    } else {
     
      this.userService.addUser(addUserRequestDto).subscribe({
        next: () => {
          this.userAdded.emit();
          this.close.emit();    
        },
        error: (err) => console.error('Add failed', err)
      });
    }
    
    this.close.emit();
  };
}
