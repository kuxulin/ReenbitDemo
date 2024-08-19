import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ChatListComponent } from './chat-list/chat-list.component';
import { RegisterComponent } from './register/register.component';
import { ChatComponent } from './chat/chat.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'chats', component: ChatListComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'chats/:chatId', component: ChatComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { bindToComponentInputs: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
