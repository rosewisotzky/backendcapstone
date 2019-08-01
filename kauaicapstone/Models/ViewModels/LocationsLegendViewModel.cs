using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models.ViewModels
{
    public class LocationsLegendViewModel
    {
        public Legend Legend { get; set;  }
        public ViewLocation ViewLocation { get; set; }
        public List<ViewLocation> AvailableLocations { get; set; }
     

    }
}
