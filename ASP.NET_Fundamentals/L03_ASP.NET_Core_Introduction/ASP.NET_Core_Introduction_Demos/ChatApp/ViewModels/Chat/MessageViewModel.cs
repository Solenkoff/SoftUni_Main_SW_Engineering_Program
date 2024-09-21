namespace ChatApp.ViewModels.Chat
{
    using System.ComponentModel.DataAnnotations;

    public class MessageViewModel
    {
        [Required]
        public string Sender { get; set; } = null!;

        [Required]
        public string MessageText { get; set; } = null!;
    }
}
