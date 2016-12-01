using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Controller.Models
{
    class Reader
    {
        [Key]
        public string Name { get; set; }

        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Book> BooksOwned { get; set; }
    }
}
