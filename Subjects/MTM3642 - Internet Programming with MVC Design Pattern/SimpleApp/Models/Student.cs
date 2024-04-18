using System.ComponentModel.DataAnnotations;

namespace SimpleApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        [MaxLength(30)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [MaxLength(30)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid Email format!")]
        public string? Email { get; set; }
    }
}
