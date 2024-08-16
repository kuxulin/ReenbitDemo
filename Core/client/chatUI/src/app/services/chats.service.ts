import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import Chat from '../models/Chat';
@Injectable({
  providedIn: 'root',
})
export class ChatsService {
  constructor(private http: HttpClient) {}

  loadAllChats(): Observable<Chat[]> {
    return this.http.get<Chat[]>('');
  }
}
