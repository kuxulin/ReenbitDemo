import Message from './Message';

export default interface Chat {
  id: string;
  firstUserId: string;
  seconduUserId: string;
  messages: Message[];
}
