import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  username = '';
  constructor(private usersService: UsersService, private router: Router) {}
  register() {
    this.usersService.register(this.username).subscribe(() => {
      this.router.navigateByUrl('chats');
    });
  }
}
