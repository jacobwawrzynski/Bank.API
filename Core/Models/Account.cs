﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Account : ModelBase
    {
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
