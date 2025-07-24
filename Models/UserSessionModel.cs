using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class UserSessionModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);

        public void Register(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void Logout()
        {
            Name = null;
            Email = null;
        }
    }
}