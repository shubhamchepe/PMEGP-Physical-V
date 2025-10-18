namespace PMEGP_Physical_V
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set splash screen as the main page
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
