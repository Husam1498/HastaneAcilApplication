﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
      
        public string Fullname { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        public string Email { get; set; }
        [StringLength(10)]
        public string Role { get; set; }

        [StringLength(200)]
        public string ProfileImageFileName { get; set; } = "no-pictures.png";

    }
}
