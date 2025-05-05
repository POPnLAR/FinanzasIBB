using FinanzasIBB.Views;
using Firebase.Auth;

namespace FinanzasIBB
{
    public partial class App : Application
    {
        public App(FirebaseAuthClient firebaseAuthClient)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage(firebaseAuthClient));
        }
    }
}