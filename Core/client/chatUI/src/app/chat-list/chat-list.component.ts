import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import Chat from '../models/Chat';
import { ChatsService } from '../services/chats.service';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.scss'],
})
export class ChatListComponent implements OnInit {
  chats$!: Observable<Chat[]>;

  constructor(private chatsService: ChatsService) {}

  ngOnInit(): void {
    this.chats$ = this.chatsService.loadAllUserChats();
  }
}
