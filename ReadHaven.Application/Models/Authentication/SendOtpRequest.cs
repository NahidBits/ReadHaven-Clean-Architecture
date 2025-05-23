using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHaven.Application.Models.Authentication
{
    public class SendOtpRequest
    {
        public string Email { get; set; } = string.Empty;
    }
}
