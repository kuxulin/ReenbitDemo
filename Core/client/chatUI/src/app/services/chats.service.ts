import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, take, tap } from 'rxjs';
import Chat from '../models/Chat';
import { environment } from 'src/environments/environment.development';
import { UsersService } from './users.service';
import { HubConnectionService } from './hub-connection.service';
@Injectable({
  providedIn: 'root',
})
export class ChatsService {
  constructor(
    private http: HttpClient,
    private usersService: UsersService,
    private hubConnection: HubConnectionService
  ) {}

  getChatById(chatId: string) {
    return this.http
      .get<Chat>(`${environment.serverUrl}/api/chats`, {
        params: {
          chatId,
        },
      })
      .pipe(tap((res) => console.log(res)));
  }

  loadAllUserChats(): Observable<Chat[]> {
    let user = this.usersService.getCurrentUser();
    return this.http.get<Chat[]>(
      `${environment.serverUrl}/api/chats/${user.id}`
    );
  }

  addNewMessageToChat(
    authorName: string,
    receiverName: string,
    messageText: string
  ) {
    return this.http
      .put<Chat>(`${environment.serverUrl}/api/chats`, {
        text: messageText,
        toUserName: receiverName,
        fromUserName: authorName,
      })
      .pipe(take(1));
  }
}
