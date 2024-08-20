import { Pipe, PipeTransform } from '@angular/core';
import Message from '../models/Message';

@Pipe({
  name: 'messagesSort',
})
export class MessagesSortPipe implements PipeTransform {
  transform(messages: Message[]) {
    return messages.sort((a, b) => {
      let first = new Date(a.createdAt).getTime();
      let second = new Date(b.createdAt).getTime();
      let res = first - second;
      return res;
    });
  }
}
