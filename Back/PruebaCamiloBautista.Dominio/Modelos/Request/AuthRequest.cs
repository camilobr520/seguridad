
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }
    }
}
