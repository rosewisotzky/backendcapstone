using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models
{
    public class Legend
    {
        [Required]
        public int LegendId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Source { get; set; }

        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public string ImageURL { get; set; }
        [Required]
        [Display(Name = "Viewing Points")]
        public ICollection<LegendViewLocation> LegendViewLocations { get; set; }
    }
}
