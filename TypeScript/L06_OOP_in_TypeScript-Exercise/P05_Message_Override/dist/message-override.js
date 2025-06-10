"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Message {
    send() {
        return 'Sending message...';
    }
}
class EmailMessage extends Message {
    send() {
        return 'Sending Email...';
    }
}
class SMSMessage extends Message {
    send() {
        return 'Sending SMS...';
    }
}
const messages = [new Message(), new EmailMessage(), new SMSMessage()];
messages.forEach((msg) => {
    console.log(msg.send());
});
//# sourceMappingURL=message-override.js.map