﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kauaicapstone.Models
{
    public class Comment
    {
        [Required]
        public int CommentId { get; set;  }
        [Required]
        public int UserId { get; set;  }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DatePosted { get; set;  }
        [Required]
        public int LocationId { get; set; }
    }
}
