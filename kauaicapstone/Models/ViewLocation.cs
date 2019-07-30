using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models
{
    public class ViewLocation
    {
        [Required]
        public int ViewLocationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string ViewPointAddress { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public ICollection<LegendViewLocation> LegendViewLocations { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
