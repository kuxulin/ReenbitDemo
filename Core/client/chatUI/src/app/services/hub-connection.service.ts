import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { UsersService } from './users.service';
@Injectable({
  providedIn: 'root',
})
export class HubConnectionService {
  private hubConnection: HubConnection;

  constructor(private usersService: UsersService) {
    let username = this.usersService.getCurrentUser().userName;
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.serverUrl}/messageHub`, {
        withCredentials: false,
      })
      .build();

    this.hubConnection.start().then(async () => await this.logInHub(username));
  }

  async invokeHubFunction(
    functionName: string,
    fromUserName: string,
    toUserName: string
  ) {
    await this.hubConnection.invoke(functionName, fromUserName, toUserName);
  }

  async logInHub(userName: string) {
    await this.hubConnection.invoke(environment.logInHub, userName);
  }

  listenToHub(functionName: string) {
    return new Observable((observer) => {
      this.hubConnection.on(functionName, () => {
        observer.next();
      });
    });
  }
}
