using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHaven.Application.Common.Interfaces.Security;
using ReadHaven.Application.Contracts.Identity;
using ReadHaven.Application.Contracts.Infrastructure;
using ReadHaven.Application.Models.Authentication;

namespace ReadHaven.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;
        private readonly IOtpService _otpService;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthenticationService authenticationService, IEmailService emailService, IOtpService otpService, IJwtService jwtService)
        {
            _authenticationService = authenticationService;
            _emailService = emailService;
            _otpService = otpService;
            _jwtService = jwtService;        
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordReset request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenticationService.ResetPasswordAsync(request);

            if (!result)
                return BadRequest("Invalid token or user not found.");

            return Ok(new { Message = "Password has been reset successfully." });
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Email is required.");

            var otp = await _otpService.GenerateOtpAsync(request.Email);

            await _emailService.SendEmailAsync(new EmailMessage
            {
                To = request.Email,
                Subject = "Your OTP Code",
                Body = $"<h2>Your OTP is: {otp}</h2>",
                IsHtml = true
            });

            return Ok("OTP sent successfully.");
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequest request)
        {
            var isValid = await _otpService.ValidateOtpAsync(request.Email, request.Otp);

            if (!isValid)
                return BadRequest("Invalid or expired OTP.");
            var token = _jwtService.GenerateToken(request.Email, tokenType: "otp", durationMinutes: 10);

            return Ok(new { Token = token });
        }
    }
}
