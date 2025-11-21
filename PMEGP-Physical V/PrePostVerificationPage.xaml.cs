using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PMEGP_Physical_V;

public partial class PrePostVerificationPage : ContentPage, INotifyPropertyChanged
{
    #region Models
    public class VerificationItem
    {
        public required string Title { get; set; }
        public required string Category { get; set; }
    }
    #endregion

    #region Properties
    private ObservableCollection<VerificationItem> _verificationItems = new();
    public ObservableCollection<VerificationItem> VerificationItems
    {
        get => _verificationItems;
        set
        {
            _verificationItems = value;
            OnPropertyChanged();
        }
    }

    private readonly LoginPage.LoginResponse _loginResponse;
    private bool _isDisposed = false;
    private readonly bool _showToastOnLoad = false;
    private bool _hasShownToast = false;
    #endregion

    #region Constructor
    public PrePostVerificationPage(LoginPage.LoginResponse response, bool showToast = false)
    {
        InitializeComponent();
        _loginResponse = response;
        _showToastOnLoad = showToast;

        // Set user ID based on login type
        if (_loginResponse.IsBankLogin)
        {
            UserIdLabel.Text = $"{_loginResponse.IFSC_Code}";
        }
        else
        {
            UserIdLabel.Text = $"{_loginResponse.UserID}";
        }

        // Set binding context
        BindingContext = this;

        // Load verification options
        LoadVerificationOptions();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Show toast after page loads
        if (_showToastOnLoad && !_hasShownToast)
        {
            ShowToast("Login successful!");
            _hasShownToast = true;
        }
    }

    private async void ShowToast(string message)
    {
        try
        {
            // Create toast container
            var toastFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#2E8B57"), // Green color
                CornerRadius = 10,
                Padding = new Thickness(20, 15),
                Margin = new Thickness(20, 0, 20, 20),
                HasShadow = true,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End,
                Opacity = 0,
                TranslationY = 100
            };

            var toastLayout = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Star }
                },
                ColumnSpacing = 12
            };

            // Success icon
            var iconLabel = new Label
            {
                Text = "?",
                FontSize = 24,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            // Message text
            var messageLabel = new Label
            {
                Text = message,
                FontSize = 16,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.WordWrap
            };

            Grid.SetColumn(iconLabel, 0);
            Grid.SetColumn(messageLabel, 1);

            toastLayout.Children.Add(iconLabel);
            toastLayout.Children.Add(messageLabel);

            toastFrame.Content = toastLayout;

            // Get the root grid from XAML
            if (this.Content is Grid rootGrid)
            {
                // Add toast to root grid
                Grid.SetRowSpan(toastFrame, rootGrid.RowDefinitions.Count);
                rootGrid.Children.Add(toastFrame);

                // Animate toast appearance
                await Task.WhenAll(
                    toastFrame.FadeTo(1, 300, Easing.CubicOut),
                    toastFrame.TranslateTo(0, 0, 300, Easing.CubicOut)
                );

                // Wait for 3 seconds
                await Task.Delay(3000);

                // Animate toast disappearance
                await Task.WhenAll(
                    toastFrame.FadeTo(0, 300, Easing.CubicIn),
                    toastFrame.TranslateTo(0, 100, 300, Easing.CubicIn)
                );

                // Remove toast from grid
                rootGrid.Children.Remove(toastFrame);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Toast error: {ex.Message}");
        }
    }
    #endregion

    #region Data Methods
    private void LoadVerificationOptions()
    {
        if (_isDisposed)
            return;

        VerificationItems.Clear();

        VerificationItems.Add(new VerificationItem
        {
            Title = "Pre-Verification",
            Category = "pre_verification"
        });

        VerificationItems.Add(new VerificationItem
        {
            Title = "Post-Verification",
            Category = "post_verification"
        });
    }
    #endregion

    #region Event Handlers
    private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (_isDisposed)
            return;

        var collectionView = sender as CollectionView;

        // Get the selected item BEFORE clearing
        var selectedItem = e.CurrentSelection.FirstOrDefault() as VerificationItem;

        // Clear selection IMMEDIATELY to prevent orange highlight
        if (collectionView != null)
        {
            collectionView.SelectedItem = null;
        }

        if (selectedItem == null)
            return;

        try
        {
            // Navigate to DashboardPage only for Post-Verification
            if (selectedItem.Category == "post_verification")
            {
                // Pass the login response to DashboardPage without showing toast again
                await Navigation.PushAsync(new DashboardPage(_loginResponse, showToast: false));
            }
            else if (selectedItem.Category == "pre_verification")
            {
                // For Pre-Verification, you can show a message or navigate to another page
                await DisplayAlert("Pre-Verification",
                    "Pre-Verification functionality will be implemented here.",
                    "OK");
            }
        }
        catch (Exception ex)
        {
            if (!_isDisposed)
            {
                await DisplayAlert("Navigation Error",
                    $"Failed to navigate: {ex.Message}",
                    "OK");
            }
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        if (_isDisposed)
            return;

        bool result = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (result)
        {
            await PerformLogout();
        }
    }

    protected override bool OnBackButtonPressed()
    {
        if (_isDisposed)
            return true;

        Dispatcher.Dispatch(async () =>
        {
            if (_isDisposed)
                return;

            bool result = await DisplayAlert("Exit", "Do you want to logout?", "Yes", "No");
            if (result)
            {
                await PerformLogout();
            }
        });
        return true;
    }

    private async Task PerformLogout()
    {
        try
        {
            _isDisposed = true;
            _hasShownToast = false;
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new LoginPage());
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Logout error: {ex.Message}");
            await DisplayAlert("Logout", "Logged out successfully", "OK");
            await Navigation.PopToRootAsync();
        }
    }
    #endregion

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}