import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import Chat from '../models/Chat';
import { ChatsService } from '../services/chats.service';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  @Input()
  chatId!: string;
  chat$!: Observable<Chat>;
  messageText = '';

  constructor(
    private chatsService: ChatsService,
    private usersService: UsersService
  ) {}

  ngOnInit(): void {
    this.chat$ = this.chatsService.getChatById(this.chatId);
  }

  sendMessage(firstUserName: string, secondUserName: string) {
    let user = this.usersService.getCurrentUser();
    let receiverName =
      user.userName === firstUserName ? secondUserName : firstUserName;
    this.chatsService
      .addNewMessageToChat(user.userName, receiverName, this.messageText)
      .subscribe();
  }
}
