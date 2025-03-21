using Microsoft.AspNetCore.Builder;

public static class RouteConfig
{
    public static void RegisterRoutes(WebApplication app)
    {
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        

        // Planes 
        app.MapControllerRoute(
            name: "list-planes-types",
            pattern: "{controller=PlaneType}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "list-planes",
            pattern: "{controller=Plane}/{action=Index}/{id?}");


        // Auth 
        app.MapControllerRoute(
            name: "auth",
            pattern: "{controller=Auth}/{action=Auth}");
        app.MapControllerRoute(
            name: "login",
            pattern: "{controller=Auth}/{action=Login}");
        
    }
}