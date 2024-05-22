using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency_Domain.ViewModels
{
    public class RegisterVM
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string RepeatPassword { get; set; }

    }
}
