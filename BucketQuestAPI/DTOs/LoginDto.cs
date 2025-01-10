using System.ComponentModel.DataAnnotations;
namespace BucketQuestAPI.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(maximumLength: 64, MinimumLength = 5)]
        public required string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 6)]
        public required string Password { get; set; }
    }
}