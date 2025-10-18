using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace PMEGP_Physical_V;

public partial class DashboardPage : ContentPage, INotifyPropertyChanged
{
    #region Models
    public class DashboardItem
    {
        public required string Title { get; set; }
        public int Count { get; set; }
        public required string Category { get; set; }
    }

    // Unit Login API Response
    public class UnitApiResponse
    {
        public bool Success { get; set; }
        public UnitDashboardData? Data { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class UnitDashboardData
    {
        public int TotalCount { get; set; }
        public int IsWorkingCount { get; set; }
        public int IsDefunctCount { get; set; }
        public int IsNonTracableCount { get; set; }
        public int IsPendingCount { get; set; }
    }

    // Bank Login API Response
    public class BankApiResponse
    {
        public bool Success { get; set; }
        public string? BankIFSC { get; set; }
        public int UnderProcess { get; set; }
        public int Completed { get; set; }
    }

    // New class for passing data to DetailsPage
    public class DetailsPageRequest
    {
        public string UserName { get; set; } = "Test";
        public required string Status { get; set; }
    }
    #endregion

    #region Properties
    private ObservableCollection<DashboardItem> _dashboardItems = new();
    public ObservableCollection<DashboardItem> DashboardItems
    {
        get => _dashboardItems;
        set
        {
            _dashboardItems = value;
            OnPropertyChanged();
        }
    }

    private readonly LoginPage.LoginResponse _loginResponse;
    private readonly HttpClient _httpClient;
    private bool _isLoading = false;
    private bool _isDisposed = false;
    #endregion

    #region Constructor
    public DashboardPage(LoginPage.LoginResponse response)
    {
        InitializeComponent();
        _loginResponse = response;

        // ⚠️ Development ONLY: Bypass SSL certificate validation
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback =
                (message, cert, chain, sslPolicyErrors) => true
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        // Set user ID based on login type
        if (_loginResponse.IsBankLogin)
        {
            UserIdLabel.Text = $"{_loginResponse.IFSC_Code}";
        }
        else
        {
            UserIdLabel.Text = $"{_loginResponse.PhysicalVeriID}";
        }

        // Set binding context
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Only load data if not already loading and not disposed
        if (!_isLoading && !_isDisposed)
        {
            await LoadDashboardDataAsync();
        }
    }
    #endregion

    #region API Methods
    private async Task LoadDashboardDataAsync()
    {
        // Prevent multiple simultaneous loads
        if (_isLoading || _isDisposed)
            return;

        _isLoading = true;

        try
        {
            // Show loading on UI thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (!_isDisposed)
                {
                    if (_loginResponse.IsBankLogin)
                        UserIdLabel.Text = $"{_loginResponse.IFSC_Code} - Loading...";
                    else
                        UserIdLabel.Text = $"{_loginResponse.PhysicalVeriID} - Loading...";
                }
            });

            // Check login type and load appropriate data
            if (_loginResponse.IsBankLogin)
            {
                await FetchBankDataFromApiAsync();
            }
            else
            {
                // Unit Login - check if PhysicalVeriID == 1 to call API
                if (_loginResponse.PhysicalVeriID == 1)
                {
                    await FetchUnitDataFromApiAsync();
                }
                else
                {
                    // Load default/hardcoded data for other users
                    LoadDefaultUnitDashboardData();
                }
            }

            // Update UI to show loaded
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (!_isDisposed)
                {
                    if (_loginResponse.IsBankLogin)
                        UserIdLabel.Text = $"{_loginResponse.IFSC_Code}";
                    else
                        UserIdLabel.Text = $"{_loginResponse.PhysicalVeriID}";
                }
            });
        }
        catch (Exception ex)
        {
            if (!_isDisposed)
            {
                await ShowErrorAsync($"Failed to load dashboard data: {ex.Message}");
            }
        }
        finally
        {
            _isLoading = false;
        }
    }

    private async Task FetchBankDataFromApiAsync()
    {
        if (_isDisposed)
            return;

        try
        {
            // Build API URL with IFSC code
            string apiUrl = $"https://115.124.125.153/MobileApp/GetBankApplicationCount?bankIfsc={_loginResponse.IFSC_Code}";

            System.Diagnostics.Debug.WriteLine($"Fetching Bank Data from: {apiUrl}");

            // Send GET request
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Empty response from server");
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var apiResponse = JsonSerializer.Deserialize<BankApiResponse>(jsonString, options);

                if (apiResponse?.Success == true)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        if (!_isDisposed)
                            MapBankDataToDashboard(apiResponse);
                    });
                }
                else
                {
                    throw new Exception("API returned unsuccessful response");
                }
            }
            else
            {
                throw new Exception($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Network error: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            throw new Exception("Request timeout. Please check your internet connection.");
        }
        catch (JsonException ex)
        {
            throw new Exception($"Failed to parse server response: {ex.Message}");
        }
    }

    private async Task FetchUnitDataFromApiAsync()
    {
        if (_isDisposed)
            return;

        try
        {
            const string API_BASE_URL = "https://115.124.125.153/MobileApp/GetPVDashboardData";

            // Build request payload
            var requestPayload = new
            {
                userName = "Test", // hardcoded
                PhysicalVeriID = _loginResponse.PhysicalVeriID // dynamic
            };

            var json = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Send POST request
            var response = await _httpClient.PostAsync(API_BASE_URL, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Empty response from server");
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var apiResponse = JsonSerializer.Deserialize<UnitApiResponse>(jsonString, options);

                if (apiResponse?.Success == true && apiResponse.Data != null)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        if (!_isDisposed)
                            MapUnitDataToDashboard(apiResponse.Data);
                    });
                }
                else
                {
                    throw new Exception(apiResponse?.Message ?? "API returned unsuccessful response");
                }
            }
            else
            {
                throw new Exception($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Network error: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            throw new Exception("Request timeout. Please check your internet connection.");
        }
        catch (JsonException ex)
        {
            throw new Exception($"Failed to parse server response: {ex.Message}");
        }
    }

    private void MapBankDataToDashboard(BankApiResponse data)
    {
        if (_isDisposed)
            return;

        DashboardItems.Clear();

        DashboardItems.Add(new DashboardItem
        {
            Title = "Pending",
            Count = data.UnderProcess,
            Category = "pending"
        });

        DashboardItems.Add(new DashboardItem
        {
            Title = "Completed",
            Count = data.Completed,
            Category = "completed"
        });
    }

    private void MapUnitDataToDashboard(UnitDashboardData data)
    {
        if (_isDisposed)
            return;

        DashboardItems.Clear();

        DashboardItems.Add(new DashboardItem
        {
            Title = "Total Reports",
            Count = data.TotalCount,
            Category = "total_reports"
        });

        DashboardItems.Add(new DashboardItem
        {
            Title = "Working Units",
            Count = data.IsWorkingCount,
            Category = "working_units"
        });

        DashboardItems.Add(new DashboardItem
        {
            Title = "Defunct Units",
            Count = data.IsDefunctCount,
            Category = "defunct_units"
        });

        DashboardItems.Add(new DashboardItem
        {
            Title = "Non-Traceable Units",
            Count = data.IsNonTracableCount,
            Category = "non_traceable_units"
        });

        DashboardItems.Add(new DashboardItem
        {
            Title = "Reports Pending",
            Count = data.IsPendingCount,
            Category = "reports_pending"
        });
    }

    private void LoadDefaultUnitDashboardData()
    {
        if (_isDisposed)
            return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_isDisposed)
                return;

            DashboardItems.Clear();

            DashboardItems.Add(new DashboardItem
            {
                Title = "Reports Received",
                Count = 16,
                Category = "reports_received"
            });

            DashboardItems.Add(new DashboardItem
            {
                Title = "Reports Pending",
                Count = 5,
                Category = "reports_pending"
            });

            DashboardItems.Add(new DashboardItem
            {
                Title = "Working Unit",
                Count = 7,
                Category = "working_unit"
            });

            DashboardItems.Add(new DashboardItem
            {
                Title = "Defunct Unit",
                Count = 1,
                Category = "defunct_unit"
            });

            DashboardItems.Add(new DashboardItem
            {
                Title = "Non-Traceable Unit",
                Count = 3,
                Category = "non_traceable_unit"
            });
        });
    }

    private string GetStatusForCategory(string category)
    {
        return category.ToLower() switch
        {
            // Bank Login categories
            "pending" => "PendingApplications",
            "completed" => "CompletedApplications",

            // Unit Login categories
            "total_reports" => "ApplicationRecieved",
            "reports_received" => "ApplicationRecieved",
            "reports_pending" => "PendingApplications",
            "working_unit" => "WorkingApplications",
            "working_units" => "WorkingApplications",
            "defunct_unit" => "DefunctApplications",
            "defunct_units" => "DefunctApplications",
            "non_traceable_unit" => "NonTraceable",
            "non_traceable_units" => "NonTraceable",
            _ => "PendingApplications"
        };
    }
    #endregion

    #region Error Handling
    private async Task ShowErrorAsync(string message)
    {
        if (_isDisposed)
            return;

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            if (_isDisposed)
                return;

            bool retry = await DisplayAlert(
                "Error",
                message,
                "Retry",
                "Use Default Data");

            if (retry)
            {
                // Retry loading data - but don't create infinite loops
                if (!_isLoading)
                {
                    await LoadDashboardDataAsync();
                }
            }
            else
            {
                // Load default data as fallback (only for Unit Login)
                if (!_loginResponse.IsBankLogin)
                {
                    LoadDefaultUnitDashboardData();
                    UserIdLabel.Text = $"{_loginResponse.PhysicalVeriID}";
                }
                else
                {
                    // For Bank Login, show empty or minimal data
                    DashboardItems.Clear();
                    UserIdLabel.Text = $"{_loginResponse.IFSC_Code}";
                }
            }
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
        var selectedItem = e.CurrentSelection.FirstOrDefault() as DashboardItem;

        // Clear selection IMMEDIATELY to prevent orange highlight
        if (collectionView != null)
        {
            collectionView.SelectedItem = null;
        }

        if (selectedItem == null)
            return;

        try
        {
            // Check if Bank Login or Unit Login
            if (_loginResponse.IsBankLogin)
            {
                string status = selectedItem.Category.ToLower() == "pending" ? "Pending" : "Completed";
                await Navigation.PushAsync(new DetailsPageBL(_loginResponse.IFSC_Code ?? "", status));
            }
            else
            {
                var detailsRequest = new DetailsPageRequest
                {
                    UserName = "Test",
                    Status = GetStatusForCategory(selectedItem.Category)
                };

                await Navigation.PushAsync(new DetailsPage(detailsRequest));
            }
        }
        catch (Exception ex)
        {
            if (!_isDisposed)
            {
                await DisplayAlert("Navigation Error",
                    $"Failed to navigate to details: {ex.Message}",
                    "OK");
            }
        }
    }

    private async void OnNewLoanTapped(object sender, EventArgs e)
    {
        if (_isDisposed)
            return;

        await DisplayAlert("New Loan", "New Loan functionality will be implemented here.", "OK");
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
            _httpClient?.Dispose();
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

    #region Cleanup
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // _isDisposed = true;
        // _httpClient?.Dispose();
    }
    #endregion
}