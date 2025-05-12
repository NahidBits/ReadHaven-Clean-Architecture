﻿

using ReadHaven.Domain.Common;

namespace ReadHaven.Domain.Entities;

public class OtpRequest : BaseEntity
{
    public string Email { get; set; }
    public string Otp { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsValidated { get; set; }
}