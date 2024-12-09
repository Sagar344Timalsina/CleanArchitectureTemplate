namespace Domain.Interfaces
{
    public interface IPasswordHasher:IService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password,string hashedPassword);
    }
}
