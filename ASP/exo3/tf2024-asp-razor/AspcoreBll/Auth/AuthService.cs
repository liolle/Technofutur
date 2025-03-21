namespace AspcoreBll.Auth;


public class AuthService(SessionManager session) : IAuthService
{
    static readonly Dictionary<string,User> users = new(){
        {"admin_test-admin_test",new User{UserId = 0,UserName = "admin_test",pwd = "admin_test", Role = "admin"}},
        {"pilot_test-pilot_test",new User{UserId = 0,UserName = "pilot_test",pwd = "pilot_test", Role = "pilot"}},
        {"mechanic_test-mechanic_test",new User{UserId = 0,UserName = "mechanic_test",pwd = "mechanic_test", Role = "mechanic"}},
    };

    public User? GetUser()
    {
        if (session.UserId<0) {return null;}
        return new User{UserId = 0,UserName = session.UserName,pwd = "", Role = session.Role};
    }

    public bool Login(string userName,string pwd)
    {
        User? u = users.GetValueOrDefault($"{userName}-{pwd}");
        if (u == null){return false;}

        session.UserId = u.UserId;
        session.UserName = u.UserName;
        session.Role = u.Role;
        return true;
    }

    public void Logout()
    {
        session.UserId = -1;
        session.UserName = "";
        session.Role = "";
    }
}

public class User
{
    public int UserId {get;set;}
    public required string UserName {get;set;}
    public required string pwd {get;set;}
    public required string Role {get;set;}
}