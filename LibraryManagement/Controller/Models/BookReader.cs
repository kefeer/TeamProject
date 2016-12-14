
using System;
using System.ComponentModel.DataAnnotations;

namespace Controller.Models
{
    public class BookReader
    {
        [Key]
        public int ID { get; set; }
        public int BookID { get; set; }
        public int ReaderID { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? DateMustBeReturned { get; set; }
    }
}
