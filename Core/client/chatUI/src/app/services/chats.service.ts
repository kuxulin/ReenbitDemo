import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import Chat from '../models/Chat';
import { environment } from 'src/environments/environment.development';
import { UsersService } from './users.service';
@Injectable({
  providedIn: 'root',
})
export class ChatsService {
  constructor(private http: HttpClient, private usersService: UsersService) {}

  loadAllUserChats(): Observable<Chat[]> {
    let user = this.usersService.getUser();
    return this.http.get<Chat[]>(`${environment.apiUrl}/chats/${user.id}`);
  }
}
