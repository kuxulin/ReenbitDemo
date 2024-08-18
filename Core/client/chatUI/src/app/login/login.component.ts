import { Component } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  username = '';
  constructor(private usersService: UsersService, private router: Router) {}
  logIn() {
    this.usersService.logIn(this.username).subscribe(() => {
      this.router.navigateByUrl('chats');
    });
  }
}
