import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './core/components/navbar/navbar';
import { Sidebar } from './core/components/sidebar/sidebar';
import { UserList } from './features/user/user-list/user-list';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, Sidebar, UserList], //Dependency use in this component
  templateUrl: './app.html', //html file that this component will load to
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('CodePulse');
}

