namespace  AspcoreBll.Auth;

public interface IAuthService
{
    public bool Login(string userName, string pwd);
    public void Logout();

    public User? GetUser();
}