import { HttpClient, httpResource } from '@angular/common/http';
import { inject, Injectable, InputSignal, signal } from '@angular/core';
import { CreateUserRequestDto, User } from '../../../shared/models/user.model';
import { environment } from '../../../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  addUserStatus = signal<'idle' | 'loading' | 'error' | 'success'>('idle');
  addUser(user: CreateUserRequestDto): Observable<void> {
    this.addUserStatus.set('loading');
    return this.http.post<void>(`${this.apiBaseUrl}/api/Users`, user);
  }
  
  getAllUsers() {
    const users = httpResource<User[]>(()=>`${this.apiBaseUrl}/api/Users`)
    return users
  }

  getUserByID(id: InputSignal<string | undefined>){
    return httpResource<User[]>(()=>`${this.apiBaseUrl}/api/Users/${id()}`)
  }

  updateUser(id: string, user: CreateUserRequestDto): Observable<void> {
    return this.http.put<void>(`${this.apiBaseUrl}/api/Users/${id}`, user); 
  }

  deleteUser(id:string): Observable<User>{
    return this.http.delete<User>(`${this.apiBaseUrl}/api/Users/${id}`);
  }
}
