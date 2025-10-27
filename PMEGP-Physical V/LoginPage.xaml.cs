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

    // WARNING: Only set this to 'true' for development/testing when the server uses a self-signed certificate.
    // Do NOT use certificate bypass in production.
    private readonly bool bypassCertificateValidation = true;

    public LoginPage()
    {
        InitializeComponent();
        GenerateCaptcha();

        if (bypassCertificateValidation)
        {
            // In dev, bypass certificate validation (self-signed). Do NOT use in production.
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

        // Set timeout
        httpClient.Timeout = TimeSpan.FromSeconds(30);

        // Set initial tab state (Unit Login is selected by default)
        UpdateTabUI();
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

    // Bank Login Tab Click Handler
    private void OnBankLoginTabTapped(object sender, EventArgs e)
    {
        if (selectedLoginType != LoginType.BankLogin)
        {
            selectedLoginType = LoginType.BankLogin;
            UpdateTabUI();
        }
    }

    // Unit Login Tab Click Handler
    private void OnUnitLoginTabTapped(object sender, EventArgs e)
    {
        if (selectedLoginType != LoginType.UnitLogin)
        {
            selectedLoginType = LoginType.UnitLogin;
            UpdateTabUI();
        }
    }

    // Update UI based on selected tab
    // Update UI based on selected tab
    private void UpdateTabUI()
    {
        if (selectedLoginType == LoginType.BankLogin)
        {
            // Bank Login is selected
            BankLoginTab.BackgroundColor = Color.FromArgb("#FF6B35");
            BankLoginTabLabel.TextColor = Colors.White;

            UnitLoginTab.BackgroundColor = Color.FromArgb("#B8D4C2");
            UnitLoginTabLabel.TextColor = Color.FromArgb("#FF6B35");

            // Update button text
            LoginButton.Text = "BANK LOGIN";

            // Update heading label
            HeadingLabel.Text = "Bank Pre-Verification Login";
        }
        else
        {
            // Unit Login is selected
            UnitLoginTab.BackgroundColor = Color.FromArgb("#FF6B35");
            UnitLoginTabLabel.TextColor = Colors.White;

            BankLoginTab.BackgroundColor = Color.FromArgb("#B8D4C2");
            BankLoginTabLabel.TextColor = Color.FromArgb("#FF6B35");

            // Update button text
            LoginButton.Text = "UNIT LOGIN";

            // Update heading label
            HeadingLabel.Text = "Physical Verification Login";
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Prevent multiple simultaneous login attempts
        if (!LoginButton.IsEnabled)
            return;

        // Basic validation
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

        // Set loading state
        SetLoadingState(true);

        try
        {
            var response = await CallLoginApi(UserIdEntry.Text.Trim(), PasswordEntry.Text);

            if (response != null)
            {
                System.Diagnostics.Debug.WriteLine($"API Response - Status: {response.Status}, Message: {response.Message}, ID: {response.PhysicalVeriID}");

                if (response.Status)
                {
                    // ✨ NEW: Store the UserID that user entered
                    response.UserID = UserIdEntry.Text.Trim();
                    // Successful login
                    await DisplayAlert("Success", response.Message ?? "Login successful!", "OK");

                    // Navigate to dashboard only on success
                    await Navigation.PushAsync(new DashboardPage(response));
                }
                else
                {
                    // Login failed - show error and reset form
                    await DisplayAlert("Login Failed", response.Message ?? "Invalid credentials. Please try again.", "OK");
                    ResetFormAfterFailure();
                }
            }
            else
            {
                // Null response - unexpected error
                await DisplayAlert("Error", "Unexpected server response. Please try again.", "OK");
                ResetFormAfterFailure();
            }
        }
        catch (HttpRequestException ex)
        {
            // Network/HTTP errors
            System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
            await DisplayAlert("Network Error", "Unable to connect to server. Please check your internet connection and try again.", "OK");
            ResetCaptchaAfterFailure();
        }
        catch (TaskCanceledException ex)
        {
            // Timeout errors
            System.Diagnostics.Debug.WriteLine($"Timeout Error: {ex.Message}");
            await DisplayAlert("Timeout", "Request timed out. Please try again.", "OK");
            ResetCaptchaAfterFailure();
        }
        catch (Exception ex)
        {
            // Other unexpected errors
            System.Diagnostics.Debug.WriteLine($"Login Error: {ex.Message}");
            await DisplayAlert("Error", $"Login failed: {ex.Message}", "OK");
            ResetFormAfterFailure();
        }
        finally
        {
            // Always reset loading state
            SetLoadingState(false);
        }
    }

    private void SetLoadingState(bool isLoading)
    {
        LoginButton.Text = isLoading ? "Logging in..." :
                          (selectedLoginType == LoginType.BankLogin ? "BANK LOGIN" : "UNIT LOGIN");
        LoginButton.IsEnabled = !isLoading;

        // Disable input fields during login to prevent changes
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
        // Clear sensitive fields and reset captcha
        PasswordEntry.Text = "";
        GenerateCaptcha();
        CaptchaEntry.Text = "";

        // Focus on user ID for retry
        UserIdEntry.Focus();
    }

    private async Task<LoginResponse?> CallLoginApi(string userId, string password)
    {
        try
        {
            // Build the inner credentials JSON
            var creds = new { UserID = userId, Password = password };
            var innerJson = JsonSerializer.Serialize(creds);

            // Base64 encode
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(innerJson));

            // Build outer request: { "data": "<base64>" }
            var outer = new { data = base64 };
            var outerJson = JsonSerializer.Serialize(outer);

            var content = new StringContent(outerJson, Encoding.UTF8, "application/json");

            // Select API URL based on login type
            string apiUrl = selectedLoginType == LoginType.BankLogin
                ? "https://115.124.125.153/MobileApp/AuthenticateBankLogin"
                : "https://115.124.125.153/MobileApp/AuthenticatePVLogin";

            System.Diagnostics.Debug.WriteLine($"Calling API: {apiUrl}");

            // Clear and set headers
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            // Make API call
            HttpResponseMessage res = await httpClient.PostAsync(apiUrl, content);
            var responseContent = await res.Content.ReadAsStringAsync();

            // Log API response for debugging
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
                // Try to parse error response
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var errorObj = JsonSerializer.Deserialize<LoginResponse>(responseContent, options);
                    if (errorObj != null)
                        return errorObj;
                }
                catch (JsonException)
                {
                    // Ignore JSON parsing errors for error responses
                }

                // Throw exception with server error details
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
            // Re-throw HTTP exceptions as-is
            throw;
        }
        catch (TaskCanceledException)
        {
            // Re-throw timeout exceptions as-is
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
        httpClient?.Dispose();
    }

    // Enum to track login type
    private enum LoginType
    {
        BankLogin,
        UnitLogin
    }

    // Updated LoginResponse class to match API response structure
    public class LoginResponse
    {
        // Common fields
        public bool Status { get; set; }
        public string? Message { get; set; }

        // Unit Login specific fields
        public int PhysicalVeriID { get; set; }

        // Bank Login specific fields
        public int BankLoginID { get; set; }
        public string? IFSC_Code { get; set; }
        public string? UserID { get; set; }

        // Helper property to identify login type
        public bool IsBankLogin => !string.IsNullOrEmpty(IFSC_Code);
    }
}