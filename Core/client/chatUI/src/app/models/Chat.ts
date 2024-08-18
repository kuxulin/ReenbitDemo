import Message from './Message';

export default interface Chat {
  id: string;
  firstUserName: string;
  secondUserName: string;
  messages: Message[];
}
