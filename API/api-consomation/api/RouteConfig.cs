public static class RouteConfig
{
    public static void RegisterRoutes(WebApplication app){
        // Task
        app.MapControllerRoute(
            name: "get-all",
            pattern: "{controller=Task}/{action=All}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all",
            pattern: "{controller=Task}/{action=GetById}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all",
            pattern: "{controller=Task}/{action=Add}/{id?}"
        );

        app.MapControllerRoute(
            name: "get-all",
            pattern: "{controller=Task}/{action=Update}/{id?}"
        );


        app.MapControllerRoute(
            name: "get-all",
            pattern: "{controller=Patch}/{action=Patch}/{id?}"
        );
    }
}