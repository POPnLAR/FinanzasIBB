using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;


namespace FinanzasIBB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("latobold.ttf", "bold");
                    fonts.AddFont("latoregular.ttf", "medium");
                    fonts.AddFont("fontawesomesolid.otf", "awesomesolid");

                });

           
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBaC2nvnaUAlNBoR7HH2TxRGy5D_Ft4SHQ",
                AuthDomain= "ibbelbosque-24ffd.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

            
            return builder.Build();
        }
    }
}
