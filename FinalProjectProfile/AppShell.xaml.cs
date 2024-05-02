using FinalProjectProfile.Pages;
using FinalProjectProfile.StartUp;

namespace FinalProjectProfile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Register all routes
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("signup", typeof(SignUpPage));
            Routing.RegisterRoute("onboard", typeof(OnboardingPage));
        }
    }
}
