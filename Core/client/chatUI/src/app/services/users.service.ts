import { Injectable } from '@angular/core';
import User from '../models/User';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { take, tap } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class UsersService {
  constructor(private http: HttpClient) {}

  logIn(username: string) {
    return this.http
      .get<User>(`${environment.serverUrl}/api/users/login`, {
        params: {
          username,
        },
      })
      .pipe(
        take(1),
        tap((res) => {
          this.setUser(res);
        })
      );
  }

  register(username: string) {
    return this.http
      .post<User>(
        `${environment.serverUrl}/api/users/register`,
        {},
        {
          params: {
            username,
          },
        }
      )
      .pipe(
        take(1),
        tap((res) => {
          this.setUser(res);
        })
      );
  }

  getCurrentUser(): User {
    let user: User = {
      id: localStorage.getItem('userId') || '',
      userName: localStorage.getItem('username') || '',
    };
    return user;
  }

  private setUser(user: User) {
    localStorage.setItem('username', user.userName);
    localStorage.setItem('userId', user.id);
  }
}
