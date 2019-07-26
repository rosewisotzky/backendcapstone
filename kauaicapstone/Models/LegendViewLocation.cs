using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models
{
    public class LegendViewLocation
    { 
        [Required]
        public int LegendViewLocationId { get; set; }
        [Required]
        public int LegendId { get; set; }
        [Required]
        public int ViewLocationId { get; set; }
        public Legend Legend { get; set; }
        public ViewLocation ViewLocation { get; set; }
    }
}
