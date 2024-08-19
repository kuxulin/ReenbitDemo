import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import Chat from '../models/Chat';
import { ChatsService } from '../services/chats.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  @Input()
  chatId!: string;
  chat$!: Observable<Chat>;

  constructor(private chatsService: ChatsService) {}

  ngOnInit(): void {
    this.chat$ = this.chatsService.getChatById(this.chatId);
  }
}
