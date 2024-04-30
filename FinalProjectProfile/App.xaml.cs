namespace FinalProjectProfile
{
    public partial class App : Application
    {
        public App()
        {
            // Register your Syncfusion license key
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCe0x1RXxbf1x0ZFNMYVVbQXBPMyBoS35RckVnWn9edndVR2lZUEd0");

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
