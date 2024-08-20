import { DialogRef } from '@angular/cdk/dialog';
import { Component, Input } from '@angular/core';
import { ChatsService } from '../services/chats.service';
import { UsersService } from '../services/users.service';

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
    private usersService: UsersService
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
      .subscribe(() => {
        this.dialogRef.close();
      });
  }
}
