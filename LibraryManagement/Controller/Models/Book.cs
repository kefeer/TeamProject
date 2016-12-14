using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Controller.Models
{
    public class Book
    {
      
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Department { get; set; }
        public int NumberInStock { get; set; }
      
        public bool IsOutdated { get; set; }

    }
}
