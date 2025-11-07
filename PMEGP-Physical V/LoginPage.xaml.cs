using System.Text;
using System.Text.Json;

namespace PMEGP_Physical_V;

public partial class LoginPage : ContentPage
{
    private string currentCaptcha = string.Empty;
    private readonly Random random = new Random();
    private readonly HttpClient httpClient;

    // Track which login type is currently selected
    private LoginType selectedLoginType = LoginType.UnitLogin;

    // Keyboard handling properties
    private bool isKeyboardVisible = false;
    private double keyboardHeight = 0;
    private View? currentFocusedView = null;

    // WARNING: Only set this to 'true' for development/testing when the server uses a self-signed certificate.
    // Do NOT use certificate bypass in production.
    private readonly bool bypassCertificateValidation = true;

    public LoginPage()
    {
        InitializeComponent();
        GenerateCaptcha();

        if (bypassCertificateValidation)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            httpClient = new HttpClient(handler);
        }
        else
        {
            httpClient = new HttpClient();
        }

        httpClient.Timeout = TimeSpan.FromSeconds(30);
        UpdateTabUI();

        // Subscribe to keyboard visibility changes
        SubscribeToKeyboardEvents();
    }

    private void SubscribeToKeyboardEvents()
    {
        // Subscribe to soft input visibility changes
        Microsoft.Maui.Controls.Application.Current!.RequestedThemeChanged += (s, e) => { };

        // For better keyboard handling on Android
#if ANDROID
        var page = this;
        page.SizeChanged += OnPageSizeChanged;
#endif
    }

    private void OnPageSizeChanged(object? sender, EventArgs e)
    {
        // This helps detect keyboard show/hide on Android
        if (currentFocusedView != null && isKeyboardVisible)
        {
            _ = ScrollToView(currentFocusedView);
        }
    }

    private void OnEntryFocused(object? sender, FocusEventArgs e)
    {
        if (sender is Entry entry)
        {
            isKeyboardVisible = true;

            // Find the parent Border for the Entry
            var parent = entry.Parent;
            while (parent != null && parent is not Border)
            {
                parent = parent.Parent;
            }

            if (parent is Border border)
            {
                currentFocusedView = border;

                // Highlight the focused field
                border.Stroke = Color.FromArgb("#2E8B57");
                border.StrokeThickness = 2;

                // Delay to ensure keyboard is fully shown - increased delay for better timing
                Device.StartTimer(TimeSpan.FromMilliseconds(400), () =>
                {
                    _ = ScrollToView(border);
                    return false;
                });
            }
        }
    }

    private void OnEntryUnfocused(object? sender, FocusEventArgs e)
    {
        if (sender is Entry entry)
        {
            // Find the parent Border for the Entry
            var parent = entry.Parent;
            while (parent != null && parent is not Border)
            {
                parent = parent.Parent;
            }

            if (parent is Border border)
            {
                // Reset border to normal state
                border.Stroke = Color.FromArgb("#D0D0D0");
                border.StrokeThickness = 1;
            }
        }

        // Check if no other entry is focused
        Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
        {
            if (UserIdEntry.IsFocused || PasswordEntry.IsFocused || CaptchaEntry.IsFocused)
            {
                return false;
            }

            isKeyboardVisible = false;
            currentFocusedView = null;
            return false;
        });
    }

    private async Task ScrollToView(View view)
    {
        try
        {
            if (view == null || MainScrollView == null)
                return;

            // Get the position of the view relative to the ScrollView
            var viewY = await GetViewYPosition(view);

            // Get screen and keyboard dimensions
            var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            var scrollViewHeight = MainScrollView.Height;

            // Estimate keyboard height - increased from 45% to 55% for more aggressive scrolling
            var estimatedKeyboardHeight = screenHeight * 0.55;

            // Calculate visible area when keyboard is shown
            var visibleArea = scrollViewHeight - estimatedKeyboardHeight;

            // Calculate the ideal scroll position
            // Position field closer to top of visible area (30% from top instead of 50%)
            var targetScrollY = viewY - (visibleArea * 0.3) + (view.Height / 2);

            // Add extra offset to ensure field is well above keyboard
            var extraOffset = 80; // Additional pixels to scroll
            targetScrollY += extraOffset;

            // Ensure we don't scroll beyond content bounds
            targetScrollY = Math.Max(0, targetScrollY);

            // Smooth scroll to the calculated position
            await MainScrollView.ScrollToAsync(0, targetScrollY, true);

            System.Diagnostics.Debug.WriteLine($"Scrolled to Y: {targetScrollY}, View Y: {viewY}, Visible Area: {visibleArea}, Extra Offset: {extraOffset}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error scrolling to view: {ex.Message}");
        }
    }

    private async Task<double> GetViewYPosition(View view)
    {
        try
        {
            double y = 0;
            var element = view as Element;

            while (element != null && element != MainScrollView)
            {
                if (element is VisualElement visualElement)
                {
                    y += visualElement.Y;
                }
                element = element.Parent;
            }

            return y;
        }
        catch
        {
            return 0;
        }
    }

    private void OnScrollViewScrolled(object? sender, ScrolledEventArgs e)
    {
        // Track scroll position if needed for future enhancements
        System.Diagnostics.Debug.WriteLine($"ScrollView scrolled to Y: {e.ScrollY}");
    }

    private void GenerateCaptcha()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        currentCaptcha = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        CaptchaLabel.Text = currentCaptcha;
    }

    private async void OnReloadCaptchaClicked(object sender, EventArgs e)
    {
        await ReloadCaptchaButton.RotateTo(360, 500);
        ReloadCaptchaButton.Rotation = 0;
        GenerateCaptcha();
        CaptchaEntry.Text = "";
    }

    private void OnBankLoginTabTapped(object sender, EventArgs e)
    {
        if (selectedLoginType != LoginType.BankLogin)
        {
            selectedLoginType = LoginType.BankLogin;
            UpdateTabUI();
        }
    }

    private void OnUnitLoginTabTapped(object sender, EventArgs e)
    {
        if (selectedLoginType != LoginType.UnitLogin)
        {
            selectedLoginType = LoginType.UnitLogin;
            UpdateTabUI();
        }
    }

    private void UpdateTabUI()
    {
        if (selectedLoginType == LoginType.BankLogin)
        {
            BankLoginTab.BackgroundColor = Color.FromArgb("#FF6B35");
            BankLoginTabLabel.TextColor = Colors.White;

            UnitLoginTab.BackgroundColor = Color.FromArgb("#B8D4C2");
            UnitLoginTabLabel.TextColor = Color.FromArgb("#FF6B35");

            LoginButton.Text = "BANK LOGIN";
            HeadingLabel.Text = "Bank Pre-Verification Login";
        }
        else
        {
            UnitLoginTab.BackgroundColor = Color.FromArgb("#FF6B35");
            UnitLoginTabLabel.TextColor = Colors.White;

            BankLoginTab.BackgroundColor = Color.FromArgb("#B8D4C2");
            BankLoginTabLabel.TextColor = Color.FromArgb("#FF6B35");

            LoginButton.Text = "UNIT LOGIN";
            HeadingLabel.Text = "Physical Verification Login";
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (!LoginButton.IsEnabled)
            return;

        // Dismiss keyboard before login
        UserIdEntry.Unfocus();
        PasswordEntry.Unfocus();
        CaptchaEntry.Unfocus();

        if (string.IsNullOrWhiteSpace(UserIdEntry.Text))
        {
            await DisplayAlert("Error", "Please enter User ID", "OK");
            UserIdEntry.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter Password", "OK");
            PasswordEntry.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(CaptchaEntry.Text))
        {
            await DisplayAlert("Error", "Please enter Captcha", "OK");
            CaptchaEntry.Focus();
            return;
        }

        if (!string.Equals(CaptchaEntry.Text.Trim(), currentCaptcha, StringComparison.OrdinalIgnoreCase))
        {
            await DisplayAlert("Error", "Invalid Captcha. Please try again.", "OK");
            ResetCaptchaAfterFailure();
            return;
        }

        SetLoadingState(true);

        try
        {
            var response = await CallLoginApi(UserIdEntry.Text.Trim(), PasswordEntry.Text);

            if (response != null)
            {
                System.Diagnostics.Debug.WriteLine($"API Response - Status: {response.Status}, Message: {response.Message}, ID: {response.PhysicalVeriID}");

                if (response.Status)
                {
                    response.UserID = UserIdEntry.Text.Trim();
                    var dashboardPage = new DashboardPage(response, showToast: true);
                    await Navigation.PushAsync(dashboardPage);
                }
                else
                {
                    await DisplayAlert("Login Failed", response.Message ?? "Invalid credentials. Please try again.", "OK");
                    ResetFormAfterFailure();
                }
            }
            else
            {
                await DisplayAlert("Error", "Unexpected server response. Please try again.", "OK");
                ResetFormAfterFailure();
            }
        }
        catch (HttpRequestException ex)
        {
            System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
            await DisplayAlert("Network Error", "Unable to connect to server. Please check your internet connection and try again.", "OK");
            ResetCaptchaAfterFailure();
        }
        catch (TaskCanceledException ex)
        {
            System.Diagnostics.Debug.WriteLine($"Timeout Error: {ex.Message}");
            await DisplayAlert("Timeout", "Request timed out. Please try again.", "OK");
            ResetCaptchaAfterFailure();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Login Error: {ex.Message}");
            await DisplayAlert("Error", $"Login failed: {ex.Message}", "OK");
            ResetFormAfterFailure();
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    private void SetLoadingState(bool isLoading)
    {
        LoginButton.Text = isLoading ? "Logging in..." :
                          (selectedLoginType == LoginType.BankLogin ? "BANK LOGIN" : "UNIT LOGIN");
        LoginButton.IsEnabled = !isLoading;

        UserIdEntry.IsEnabled = !isLoading;
        PasswordEntry.IsEnabled = !isLoading;
        CaptchaEntry.IsEnabled = !isLoading;
        ReloadCaptchaButton.IsEnabled = !isLoading;
    }

    private void ResetCaptchaAfterFailure()
    {
        GenerateCaptcha();
        CaptchaEntry.Text = "";
        CaptchaEntry.Focus();
    }

    private void ResetFormAfterFailure()
    {
        PasswordEntry.Text = "";
        GenerateCaptcha();
        CaptchaEntry.Text = "";
        UserIdEntry.Focus();
    }

    private async Task<LoginResponse?> CallLoginApi(string userId, string password)
    {
        try
        {
            var creds = new { UserID = userId, Password = password };
            var innerJson = JsonSerializer.Serialize(creds);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(innerJson));
            var outer = new { data = base64 };
            var outerJson = JsonSerializer.Serialize(outer);
            var content = new StringContent(outerJson, Encoding.UTF8, "application/json");

            string apiUrl = selectedLoginType == LoginType.BankLogin
                ? "https://115.124.125.153/MobileApp/AuthenticateBankLogin"
                : "https://115.124.125.153/MobileApp/AuthenticatePVLogin";

            System.Diagnostics.Debug.WriteLine($"Calling API: {apiUrl}");

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage res = await httpClient.PostAsync(apiUrl, content);
            var responseContent = await res.Content.ReadAsStringAsync();

            Console.WriteLine($"API Raw Response: {responseContent}");
            System.Diagnostics.Debug.WriteLine($"API Raw Response: {responseContent}");

            if (res.IsSuccessStatusCode)
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var loginResp = JsonSerializer.Deserialize<LoginResponse>(responseContent, options);
                    return loginResp;
                }
                catch (JsonException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to parse login response: {ex.Message}");
                    throw new Exception("Invalid response format from server");
                }
            }
            else
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var errorObj = JsonSerializer.Deserialize<LoginResponse>(responseContent, options);
                    if (errorObj != null)
                        return errorObj;
                }
                catch (JsonException)
                {
                }

                throw new HttpRequestException($"Server returned {(int)res.StatusCode} {res.ReasonPhrase}");
            }
        }
        catch (JsonException ex)
        {
            System.Diagnostics.Debug.WriteLine($"JSON Error: {ex.Message}");
            throw new Exception("Failed to process request data");
        }
        catch (HttpRequestException)
        {
            throw;
        }
        catch (TaskCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"API Call Error: {ex.Message}");
            throw new Exception($"Network error: {ex.Message}");
        }
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Forgot Password",
            "Please contact your system administrator to reset your password.",
            "OK");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Unsubscribe from events
#if ANDROID
        this.SizeChanged -= OnPageSizeChanged;
#endif

        httpClient?.Dispose();
    }

    private enum LoginType
    {
        BankLogin,
        UnitLogin
    }

    public class LoginResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public int PhysicalVeriID { get; set; }
        public int BankLoginID { get; set; }
        public string? IFSC_Code { get; set; }
        public string? UserID { get; set; }
        public bool IsBankLogin => !string.IsNullOrEmpty(IFSC_Code);
    }
}