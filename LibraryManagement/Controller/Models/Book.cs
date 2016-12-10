﻿using System;
using System.ComponentModel.DataAnnotations;


namespace Controller.Models
{
    public class Book
    {
        [Key]
        public string Name { get; set; }

        public string Author { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Department { get; set; }
        public Reader Reader { get; set; }

        public bool IsOutdated { get; set; }
        public bool IsOwned { get; set; }
        public DateTime? dateGiven { get; set; }
        public DateTime? dateMustBeReturned { get; set; }
    }
}
