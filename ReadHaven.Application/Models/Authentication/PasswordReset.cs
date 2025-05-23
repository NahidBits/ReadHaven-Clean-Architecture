using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHaven.Application.Models.Authentication
{
    public class PasswordReset
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
