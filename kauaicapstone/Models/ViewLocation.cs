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
        public int LocationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ViewPointAddress { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        public ICollection<Legend> Legends { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
