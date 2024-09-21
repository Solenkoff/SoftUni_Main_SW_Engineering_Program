namespace ChatApp.Controllers
{
    using ChatApp.ViewModels.Chat;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        private static readonly IList<KeyValuePair<string, string>> messages = 
            new List<KeyValuePair<string, string>>();   

        public IActionResult Show()
        {
            if(messages.Count < 1)
            {
                return this.View(new ChatViewModel());
            }

            var chatViewModel = new ChatViewModel()
            {
                AllMessages = messages.Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToArray()
            };

            return this.View(chatViewModel);
        }


        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Show");
            }

            var newMessage = chat.CurrentMessage;

            messages.Add(new KeyValuePair<string, string>
                (newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }

    }
}
