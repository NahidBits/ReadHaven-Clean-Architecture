

using ReadHaven.Domain.Common;

namespace ReadHaven.Domain.Entities;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }
    public string Role { get; set; }
}
