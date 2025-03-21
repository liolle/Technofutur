using Microsoft.AspNetCore.Http;

namespace AspcoreBll;

public class SessionManager
{
    private readonly ISession _session;

    public SessionManager (IHttpContextAccessor httpContextAccessor){
        _session = httpContextAccessor.HttpContext!.Session;
    }

    public int UserId 
    {
        get 
        {
            int? res = _session.GetInt32("UserId");
            if (res == null) {return -1;}            

            return (int) res;
        }
        set
        {
            _session.SetInt32("UserId",value);
        }
    }

    public string UserName
    {
        get 
        {
            string? res = _session.GetString("UserName");
            if (res == null) {return "";}            

            return (string) res;
        }
        set
        {
            _session.SetString("UserName",value);
        }
    } 

    public string Role
    {
        get 
        {
            string? res = _session.GetString("UserRole");
            if (res == null) {return "";}            

            return (string) res;
        }
        set
        {
            _session.SetString("UserRole",value);
        }
    } 

}