import { DialogRef } from '@angular/cdk/dialog';
import { Component } from '@angular/core';
import { ChatsService } from '../services/chats.service';
import { UsersService } from '../services/users.service';
import { HubConnectionService } from '../services/hub-connection.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-create-new-chat-dialog',
  templateUrl: './create-new-chat-dialog.component.html',
  styleUrls: ['./create-new-chat-dialog.component.scss'],
})
export class CreateNewChatDialogComponent {
  receiverUserName = '';
  messageText = '';

  constructor(
    private dialogRef: DialogRef<CreateNewChatDialogComponent>,
    private chatsService: ChatsService,
    private usersService: UsersService,
    private hubConnection: HubConnectionService
  ) {}

  sendMessage() {
    if (!this.receiverUserName || !this.messageText) return;

    let user = this.usersService.getCurrentUser();
    this.chatsService
      .addNewMessageToChat(
        user.userName,
        this.receiverUserName,
        this.messageText
      )
      .subscribe(async () => {
        await this.hubConnection.invokeHubFunction(
          environment.createChat,
          user.userName,
          this.receiverUserName
        );
        this.dialogRef.close();
      });
  }
}
