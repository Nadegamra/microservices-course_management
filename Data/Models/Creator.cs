using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Data.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }
        [ProtectedPersonalData]
        public string Username { get; set; }
        public string NormalizedUsername { get; set; }
        [ProtectedPersonalData]
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}
