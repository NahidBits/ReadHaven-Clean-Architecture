using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHaven.Application.Common.Helpers
{
    public static class OtpGenerator
    {
        public static string GenerateOtp(int length = 6)
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(0, 10)));
        }
    }
}
