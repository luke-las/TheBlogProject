using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.ViewModels
{
    public class ContactMe
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at most {1} characters.", MinimumLength = 0)]
        public string Subject { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at most {1} characters.", MinimumLength = 0)]
        public string Message { get; set; }

    }
}
