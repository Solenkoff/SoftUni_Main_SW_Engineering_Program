namespace TextSplitter.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class TextSplitViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Text to split must be between 2 and 30 characters")]
        public string Text { get; set; } = null!;

        public string? SplitText { get; set; } 
    }
}
