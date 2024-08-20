import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import Chat from '../models/Chat';
import { ChatsService } from '../services/chats.service';
import { CreateNewChatDialogComponent } from '../create-new-chat-dialog/create-new-chat-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { UsersService } from '../services/users.service';
import { HubConnectionService } from '../services/hub-connection.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.scss'],
})
export class ChatListComponent implements OnInit, OnDestroy {
  chats$!: Observable<Chat[]>;
  hubSubsription!: Subscription;
  constructor(
    private dialog: MatDialog,
    private chatsService: ChatsService,
    private usersService: UsersService,
    private hubConnection: HubConnectionService
  ) {}

  ngOnInit(): void {
    this.loadChats();

    this.hubSubsription = this.hubConnection
      .listenToHub(environment.newChatCreated)
      .subscribe(() => this.loadChats());
  }

  loadChats() {
    this.chats$ = this.chatsService.loadAllUserChats();
  }

  openCreatingChatDialog() {
    let dialogref = this.dialog.open(CreateNewChatDialogComponent);
  }

  showInterlocutorName(firstUserName: string, secondUserName: string) {
    let user = this.usersService.getCurrentUser();
    return user.userName === firstUserName ? secondUserName : firstUserName;
  }

  ngOnDestroy() {
    this.hubSubsription.unsubscribe();
  }
}
