using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        
        [RegularExpression(
            "^(\\+\\d{1,2}\\s?)?1?\\-?\\.?\\s?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$\r\n",
            ErrorMessage = "Invalid Phone number")]
        public string Phone { get; set; }
    }
}
