﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Observer.Models
{
    public class Discount
    {
        
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }

    }
}
