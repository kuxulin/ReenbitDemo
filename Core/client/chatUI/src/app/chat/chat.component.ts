import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import Chat from '../models/Chat';
import { ChatsService } from '../services/chats.service';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from '../services/users.service';
import { HubConnectionService } from '../services/hub-connection.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit, OnDestroy {
  @Input()
  chatId!: string;
  chat$!: Observable<Chat>;
  messageText = '';
  hubSubscription!: Subscription;

  constructor(
    private chatsService: ChatsService,
    private usersService: UsersService,
    private hubConnection: HubConnectionService
  ) {}

  ngOnInit(): void {
    this.loadChat();

    this.hubSubscription = this.hubConnection.receiveMessage().subscribe(() => {
      this.loadChat();
    });
  }

  loadChat() {
    this.chat$ = this.chatsService.getChatById(this.chatId);
  }

  sendMessage(firstUserName: string, secondUserName: string) {
    let user = this.usersService.getCurrentUser();
    let receiverName =
      user.userName === firstUserName ? secondUserName : firstUserName;
    this.chatsService
      .addNewMessageToChat(user.userName, receiverName, this.messageText)
      .subscribe(() => (this.messageText = ''));
  }

  ngOnDestroy(): void {
    this.hubSubscription.unsubscribe();
  }
}
