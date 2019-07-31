using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models.ViewModels
{
    public class CreateLegendViewModel
    {
        public Legend Legend { get; set; }
        public ViewLocation Location { get; set; }
        public List<int> LocationIds { get; set;  }
    }
}
