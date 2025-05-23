using ReadHaven.Application.Contracts.Infrastructure;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Common.Helpers;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Infrastructure.Otp
{
    public class OtpService : IOtpService
    {
        private readonly IOtpRepository _otpRepo;

        public OtpService(IOtpRepository otpRepo)
        {
            _otpRepo = otpRepo;
        }

        public async Task<string> GenerateOtpAsync(string email)
        {
            var otp = OtpGenerator.GenerateOtp();

            var record = new OtpRequest
            {
                Id = Guid.NewGuid(),
                Email = email,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                IsValidated = true
            };

            await _otpRepo.AddAsync(record);
            return otp;
        }

        public async Task<bool> ValidateOtpAsync(string email, string otp)
        {
            var record = await _otpRepo.GetValidOtpAsync(email);

            if (record == null)
                return false;

            if (record.Otp == otp)
            {
                record.IsValidated = false;
                await _otpRepo.UpdateAsync(record);
                return true;
            }

            await _otpRepo.UpdateAsync(record);
            return false;
        }
    }
}
