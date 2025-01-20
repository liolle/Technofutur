using System.ComponentModel.DataAnnotations;

namespace tf2024_asp_razor.Models
{
    public class Replique
    {
        [Required]
        [MinLength(3)]
        public string Film { get; set; }
        [Required]
        [MinLength(4)]
        public string RepliqueCulte { get; set; } 
        [EmailAddress]
        public string email { get; set; }
    }
}
