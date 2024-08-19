import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import Chat from '../models/Chat';
import { ChatsService } from '../services/chats.service';
import { CreateNewChatDialogComponent } from '../create-new-chat-dialog/create-new-chat-dialog.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.scss'],
})
export class ChatListComponent implements OnInit {
  chats$!: Observable<Chat[]>;

  constructor(private dialog: MatDialog, private chatsService: ChatsService) {}

  ngOnInit(): void {
    this.chats$ = this.chatsService.loadAllUserChats();
  }

  openCreatingChatDialog() {
    let dialogref = this.dialog.open(CreateNewChatDialogComponent);

    dialogref.afterClosed().subscribe(); // update chatlist
  }
}
