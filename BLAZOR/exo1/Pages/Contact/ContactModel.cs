using System.ComponentModel.DataAnnotations;

namespace exo1.models;

public class ContactModel
{
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Nom { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [Phone]
        public string Telephone { get; set; } = "";

        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string Message { get; set; } = "";

        [StringLength(50, ErrorMessage = "Color cannot exceed 50 characters.")]
        public string Color { get; set; } = "";


    public override string ToString()
    {
        return $"\nNom: {Nom}\nEmail: {Email}\nTelephone: {Telephone}\nMessage: {Message}\nColor: {Color}";
    }
}