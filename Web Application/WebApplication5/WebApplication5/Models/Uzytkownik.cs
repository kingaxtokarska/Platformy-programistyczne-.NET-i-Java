using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public partial class Uzytkownik
    {
        public string LoginErrorMessage;

        public int IdUzytkownik { get; set; }
        [DisplayName("Login")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string NazwaUzytkownik { get; set; }
        [DisplayName("Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string HasloUzytkownik { get; set; }

    }
}
