namespace PMEGP_Physical_V
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartSplashSequence();
        }

        private async void StartSplashSequence()
        {
            // Initial state - elements are invisible
           // LogoContainer.Opacity = 0;
            //LogoContainer.Scale = 0.8;

            // Animate logo container - fade in and scale up
           // await LogoContainer.FadeTo(1, 1000); // Fade in over 1 second
            //await LogoContainer.ScaleTo(1, 500); // Scale to normal size

            // Add a subtle bounce effect
            //await LogoFrame.ScaleTo(1.1, 200);
            //await LogoFrame.ScaleTo(1, 200);

            // Wait total ~3 seconds on splash screen
            await Task.Delay(1300);

            // Navigate to Login screen
            await NavigateToLogin();
        }

        private async Task NavigateToLogin()
        {
            // Ensure NavigationPage wraps MainPage in App.xaml.cs
            await Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }




    }

}
