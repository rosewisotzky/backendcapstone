using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public ICollection<Comment> UserComments { get; set; }
        public ICollection<Legend> UserLegend { get; set; }
        public ICollection<ViewLocation> UserViewLocations { get; set; }
        
    }
}
