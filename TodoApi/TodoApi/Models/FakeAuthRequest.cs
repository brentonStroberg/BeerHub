using TodoApi.Enums;

namespace TodoApi.Models;

public class FakeAuthRequest
{
    public Guid? UserId { get; set; }
    public EUserType Type { get; set; }
}