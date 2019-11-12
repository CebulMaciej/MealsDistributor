namespace Domain.Creators.Users.Request.Abstract
{
    public interface IUserCreateRequest
    {
        string Email { get; }
        string Password { get; }
    }
}
