#nullable enable

using Microsoft.Maui.Layouts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PMEGP_Physical_V
{
    // API Models
    public class ApiRequest
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
    }

    public class ApiResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<ApplicantData> Data { get; set; } = new();

        [JsonPropertyName("recordCount")]
        public int RecordCount { get; set; }
    }

    public class ApplicantData
    {
        [JsonPropertyName("ApplID")]
        public int ApplID { get; set; }

        [JsonPropertyName("ApplCode")]
        public string ApplCode { get; set; } = string.Empty;

        [JsonPropertyName("ApplName")]
        public string ApplName { get; set; } = string.Empty;

        [JsonPropertyName("ComnAddress")]
        public string ComnAddress { get; set; } = string.Empty;

        [JsonPropertyName("ComnTaluka")]
        public string ComnTaluka { get; set; } = string.Empty;

        [JsonPropertyName("ComnDistrict")]
        public string ComnDistrict { get; set; } = string.Empty;

        [JsonPropertyName("ComnPin")]
        public string ComnPin { get; set; } = string.Empty;

        [JsonPropertyName("FinalSubDate")]
        public string FinalSubDate { get; set; } = string.Empty;

        // Changed to handle null values properly
        [JsonPropertyName("isPendingForFieldInspector")]
        public bool? IsPendingForFieldInspector { get; set; }

        [JsonPropertyName("isUnitVerDone")]
        public bool? IsUnitVerDone { get; set; }

        [JsonPropertyName("isBankVerDone")]
        public bool? IsBankVerDone { get; set; }

        [JsonPropertyName("ProdDescr")]
        public string ProdDescr { get; set; } = string.Empty;

        [JsonPropertyName("UnitAddress")]
        public string UnitAddress { get; set; } = string.Empty;

        [JsonPropertyName("UnitTaluka")]
        public string UnitTaluka { get; set; } = string.Empty;

        [JsonPropertyName("UnitDistrict")]
        public string UnitDistrict { get; set; } = string.Empty;

        [JsonPropertyName("UnitPin")]
        public string UnitPin { get; set; } = string.Empty;

        // Additional fields from your JSON response
        [JsonPropertyName("IsWorking")]
        public bool? IsWorking { get; set; }

        [JsonPropertyName("IsDefunct")]
        public bool? IsDefunct { get; set; }

        [JsonPropertyName("IsNonTracable")]
        public bool? IsNonTracable { get; set; }

        [JsonPropertyName("MobileNo1")]
        public string MobileNo1 { get; set; } = string.Empty;
    }

    // View Models - MODIFIED to include ApplID
    public class ApplicantViewModel : INotifyPropertyChanged
    {
        public int ApplID { get; set; } // ADDED THIS PROPERTY
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DateOfSubmission { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string TraceabilityStatus { get; set; } = string.Empty;
        public string DocumentsIconPath { get; set; } = string.Empty;
        public string BriefcaseIconPath { get; set; } = string.Empty;
        public Color StatusBadgeColor { get; set; }
        public bool IsCompleted => Status == "Completed";
        public bool IsPending => Status == "Pending";
        public bool IsInProgress => Status == "In Progress";
        public string PhoneNumber { get; set; } = string.Empty;
        public string UnitFullAddress { get; set; } = string.Empty;
        public bool IsUnitVerDone { get; set; } = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DetailsPageViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "https://115.124.125.153/MobileApp/GetPVList";

        private ObservableCollection<ApplicantViewModel> _applicants = new();
        private ObservableCollection<ApplicantViewModel> _filteredApplicants = new();
        private bool _isLoading;
        private string _errorMessage = string.Empty;
        private string _searchText = string.Empty;
        private bool _shouldRefreshOnAppearing = false;




        public ObservableCollection<ApplicantViewModel> Applicants
        {
            get => _applicants;
            set
            {
                _applicants = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ApplicantViewModel> FilteredApplicants
        {
            get => _filteredApplicants;
            set
            {
                _filteredApplicants = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterApplicants();
            }
        }

        public DetailsPageViewModel()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (message, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }





        public async Task LoadDataAsync(string userName, string status)
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                var request = new ApiRequest
                {
                    UserName = userName,
                    Status = status
                };

                var jsonRequest = JsonSerializer.Serialize(request);
                var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(API_URL, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(jsonString))
                    {
                        throw new Exception("Empty response from server");
                    }

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    };

                    var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString, options);

                    if (apiResponse?.Success == true && apiResponse.Data != null)
                    {
                        var applicantViewModels = apiResponse.Data.Select(MapToViewModel).ToList();

                        Applicants.Clear();
                        foreach (var applicant in applicantViewModels)
                        {
                            Applicants.Add(applicant);
                        }

                        FilterApplicants();
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
                ErrorMessage = $"Network error: {ex.Message}";
            }
            catch (TaskCanceledException)
            {
                ErrorMessage = "Request timeout. Please check your internet connection.";
            }
            catch (JsonException ex)
            {
                ErrorMessage = $"Failed to parse server response: {ex.Message}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Failed to load data: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        // MODIFIED to include ApplID mapping
        private ApplicantViewModel MapToViewModel(ApplicantData data)
        {
            var viewModel = new ApplicantViewModel
            {
                ApplID = data.ApplID,
                IsUnitVerDone = data.IsUnitVerDone ?? false,
                Id = data.ApplCode,
                Name = data.ApplName,
                DateOfSubmission = ParseDateFromJson(data.FinalSubDate)
            };

            // Build complete address
            var addressParts = new List<string>();
            if (!string.IsNullOrWhiteSpace(data.ComnAddress))
                addressParts.Add(data.ComnAddress.Trim());
            if (!string.IsNullOrWhiteSpace(data.ComnTaluka))
                addressParts.Add(data.ComnTaluka.Trim());
            if (!string.IsNullOrWhiteSpace(data.ComnDistrict))
                addressParts.Add(data.ComnDistrict.Trim());
            if (!string.IsNullOrWhiteSpace(data.ComnPin))
                addressParts.Add(data.ComnPin.Trim());

            viewModel.Address = string.Join(", ", addressParts);

            // Store phone number
            viewModel.PhoneNumber = data.MobileNo1 ?? string.Empty;

            // Build unit address for maps
            var unitAddressParts = new List<string>();
            var unitValues = new[] {
        data.UnitAddress?.Trim(),
        data.UnitTaluka?.Trim(),
        data.UnitDistrict?.Trim(),
        data.UnitPin?.Trim()
    };

            foreach (var value in unitValues)
            {
                if (!string.IsNullOrWhiteSpace(value) && !unitAddressParts.Contains(value, StringComparer.OrdinalIgnoreCase))
                {
                    unitAddressParts.Add(value);
                }
            }
            viewModel.UnitFullAddress = string.Join(", ", unitAddressParts);

            // Determine traceability status
            if (data.IsWorking == true)
            {
                viewModel.TraceabilityStatus = "Working";
            }
            else if (data.IsDefunct == true)
            {
                viewModel.TraceabilityStatus = "Defunct";
            }
            else if (data.IsNonTracable == true)
            {
                viewModel.TraceabilityStatus = "Non-Tracable";
            }
            else
            {
                viewModel.TraceabilityStatus = "Unknown";
            }


            // Apply status logic with proper null handling
            if (data.IsPendingForFieldInspector == true)
            {
                viewModel.Status = "Pending";
                viewModel.StatusBadgeColor = Color.FromArgb("#F44336"); // Red
            }
            else if (data.IsUnitVerDone == true)
            {
                viewModel.Status = "Completed";
                viewModel.StatusBadgeColor = Color.FromArgb("#4CAF50"); // Green
            }
            else if (data.IsDefunct == true)
            {
                viewModel.Status = "In Progress";
                viewModel.StatusBadgeColor = Color.FromArgb("#FF9800"); // Orange
            }
            else if (data.IsWorking == true)
            {
                viewModel.Status = "Working";
                viewModel.StatusBadgeColor = Color.FromArgb("#4CAF50"); // Green
            }
            else
            {
                viewModel.Status = "In Progress";
                viewModel.StatusBadgeColor = Color.FromArgb("#FF9800"); // Orange
            }

            // Apply conditional icon paths
            viewModel.DocumentsIconPath = data.IsBankVerDone == true ? "docs_green.png" : "docs_orange.png";
            viewModel.BriefcaseIconPath = data.IsUnitVerDone == true ? "brief_green.png" : "brief_orange.png";

            return viewModel;
        }

        private string ParseDateFromJson(string jsonDate)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonDate))
                    return DateTime.Now.ToString("dd-MM-yyyy");

                // Handle JSON date format like "/Date(1747723687020)/"
                if (jsonDate.StartsWith("/Date(") && jsonDate.EndsWith(")/"))
                {
                    var timestampStr = jsonDate.Substring(6, jsonDate.Length - 8);
                    if (long.TryParse(timestampStr, out var timestamp))
                    {
                        var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
                        return dateTime.DateTime.ToString("dd-MM-yyyy");
                    }
                }

                // Try to parse as regular DateTime
                if (DateTime.TryParse(jsonDate, out var parsedDate))
                {
                    return parsedDate.ToString("dd-MM-yyyy");
                }

                return DateTime.Now.ToString("dd-MM-yyyy");
            }
            catch
            {
                return DateTime.Now.ToString("dd-MM-yyyy");
            }
        }

        private void FilterApplicants()
        {
            FilteredApplicants.Clear();

            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? Applicants
                : Applicants.Where(a =>
                    a.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    a.Id.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            foreach (var applicant in filtered)
            {
                FilteredApplicants.Add(applicant);
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class DetailsPage : ContentPage
    {
        private readonly DetailsPageViewModel _viewModel;
        private double screenWidth;
        private double screenHeight;
        private double scaleFactor;
        private bool isSmallScreen;
        private bool isTablet;
        private bool _shouldRefreshOnAppearing = false;
        private string _userName = "Test";
        private string _status = "PendingApplications";
        private bool _hasLoadedOnce = false;
        private DateTime _lastLoadedAt = DateTime.MinValue;
        private readonly TimeSpan _refreshStaleThreshold = TimeSpan.FromSeconds(10);

        public DetailsPage(DashboardPage.DetailsPageRequest request)
        {
            InitializeComponent();

            _viewModel = new DetailsPageViewModel();
            BindingContext = _viewModel;

            // Store request parameters for refresh
            _userName = request.UserName;
            _status = request.Status;

            InitializeResponsiveDesign();
            _ = LoadDataAsync(request.UserName, request.Status);

            if (SearchEntry != null)
            {
                SearchEntry.TextChanged += OnSearchTextChanged;
            }
        }

        private async Task LoadDataAsync(string userName, string status)
        {
            // ✨ NEW: Show loader before fetching data
            ShowLoader();

            try
            {
                await _viewModel.LoadDataAsync(userName, status);

                if (!_viewModel.IsLoading && string.IsNullOrEmpty(_viewModel.ErrorMessage))
                {
                    DisplayApplicants(_viewModel.FilteredApplicants.ToList());
                }
                else if (!string.IsNullOrEmpty(_viewModel.ErrorMessage))
                {
                    await DisplayAlert("Error", _viewModel.ErrorMessage, "OK");
                }
            }
            finally
            {
                // ✨ NEW: Always hide loader after data is loaded (success or failure)
                HideLoader();
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // First-time load
            if (!_hasLoadedOnce)
            {
                _hasLoadedOnce = true;
                await RefreshDataAsync();
                _lastLoadedAt = DateTime.UtcNow;
                return;
            }

            // Refresh when coming back from subpages
            if (_shouldRefreshOnAppearing)
            {
                _shouldRefreshOnAppearing = false;
                await RefreshDataAsync();
                _lastLoadedAt = DateTime.UtcNow;
                return;
            }

            // Auto-refresh if data older than threshold
            if ((DateTime.UtcNow - _lastLoadedAt) > _refreshStaleThreshold)
            {
                await RefreshDataAsync();
                _lastLoadedAt = DateTime.UtcNow;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Dispose only when actually popped from navigation
            try
            {
                if (Navigation != null && !Navigation.NavigationStack.Contains(this))
                {
                    _viewModel?.Dispose();
                }
            }
            catch
            {
                // ignore navigation errors
            }
        }


        private async Task RefreshDataAsync()
        {
            try
            {
                ShowLoader();
                await _viewModel.LoadDataAsync(_userName, _status);

                if (!_viewModel.IsLoading && string.IsNullOrEmpty(_viewModel.ErrorMessage))
                {
                    DisplayApplicants(_viewModel.FilteredApplicants.ToList());
                    _lastLoadedAt = DateTime.UtcNow;
                }
                else if (!string.IsNullOrEmpty(_viewModel.ErrorMessage))
                {
                    await DisplayAlert("Error", _viewModel.ErrorMessage, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            }
            finally
            {
                HideLoader();
            }
        }

        public async Task RefreshDataExternallyAsync()
        {
            System.Diagnostics.Debug.WriteLine($"🔄 External refresh triggered with status: {_status}");
            ShowLoader();
            await _viewModel.LoadDataAsync(_userName, _status);
            if (!_viewModel.IsLoading && string.IsNullOrEmpty(_viewModel.ErrorMessage))
            {
                DisplayApplicants(_viewModel.FilteredApplicants.ToList());
            }
            HideLoader();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > 0 && height > 0)
            {
                UpdateResponsiveProperties(width, height);
                UpdateHeaderFontSize();

                if (_viewModel.FilteredApplicants.Any())
                {
                    DisplayApplicants(_viewModel.FilteredApplicants.ToList());
                }
            }
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void InitializeResponsiveDesign()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            screenWidth = displayInfo.Width / displayInfo.Density;
            screenHeight = displayInfo.Height / displayInfo.Density;
            UpdateResponsiveProperties(screenWidth, screenHeight);
        }

        private void UpdateResponsiveProperties(double width, double height)
        {
            screenWidth = width;
            screenHeight = height;
            scaleFactor = Math.Max(0.7, Math.Min(1.3, screenWidth / 400.0));
            isSmallScreen = screenWidth < 500;
            isTablet = screenWidth >= 600;
        }

        private void UpdateHeaderFontSize()
        {
            if (SearchEntry != null)
            {
                var baseSearchFontSize = isTablet ? 16 : 14;
                SearchEntry.FontSize = baseSearchFontSize * scaleFactor;
            }
        }

        private void ShowLoader()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                LoadingOverlay.IsVisible = true;
                LoadingSpinner.IsRunning = true;
                ApplicantsContainer.IsVisible = false;
            });
        }

        private void HideLoader()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                LoadingOverlay.IsVisible = false;
                LoadingSpinner.IsRunning = false;
                ApplicantsContainer.IsVisible = true;
            });
        }

        private double GetResponsiveFontSize(double baseSize) => baseSize * scaleFactor;
        private double GetResponsiveSpacing(double baseSpacing) => baseSpacing * scaleFactor;
        private Thickness GetResponsivePadding(double basePadding) => new Thickness(basePadding * scaleFactor);
        private Thickness GetResponsivePadding(double horizontal, double vertical) => new Thickness(horizontal * scaleFactor, vertical * scaleFactor);

        private void DisplayApplicants(List<ApplicantViewModel> applicantsToShow)
        {
            // ✨ NEW: Ensure container is visible when displaying applicants
            ApplicantsContainer.IsVisible = true;

            if (ApplicantsContainer == null) return;

            ApplicantsContainer.Children.Clear();
            ApplicantsContainer.RowDefinitions.Clear();
            ApplicantsContainer.RowSpacing = GetResponsiveSpacing(isSmallScreen ? 8 : 12);

            for (int i = 0; i < applicantsToShow.Count; i++)
            {
                ApplicantsContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var applicantCard = CreateApplicantCard(applicantsToShow[i]);
                Grid.SetRow(applicantCard, i);
                ApplicantsContainer.Children.Add(applicantCard);
            }
        }

        // MODIFIED to include tap gesture
        private Frame CreateApplicantCard(ApplicantViewModel applicant)
        {
            var cardFrame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Colors.Transparent,
                CornerRadius = (float)(isSmallScreen ? 6 : 8),
                Padding = 0,
                Margin = GetResponsivePadding(0),
                HasShadow = false
            };

            // Set BindingContext for tap gesture access
            cardFrame.BindingContext = applicant;

            var mainGrid = new Grid();
            var borderWidth = GetResponsiveSpacing(isSmallScreen ? 6 : 8);
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(borderWidth) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var leftBorder = new BoxView
            {
                BackgroundColor = Color.FromArgb("#FF6B35"),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };
            Grid.SetColumn(leftBorder, 0);

            var contentContainer = new Grid();
            Grid.SetColumn(contentContainer, 1);

            var contentGrid = new Grid
            {
                Padding = GetResponsivePadding(isSmallScreen ? 12 : 15, isSmallScreen ? 10 : 15),
                RowSpacing = GetResponsiveSpacing(isSmallScreen ? 6 : 8)
            };

            for (int i = 0; i < 5; i++)
            {
                contentGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            var idRow = CreateDetailRow("Applicant Id :", applicant.Id);
            var nameRow = CreateDetailRow("Name :", applicant.Name);
            var addressRow = CreateDetailRow("Address :", applicant.Address);
            var dateRow = CreateDetailRow("Date Of Submission :", applicant.DateOfSubmission);

            Grid.SetRow(idRow, 0);
            Grid.SetRow(nameRow, 1);
            Grid.SetRow(addressRow, 2);
            Grid.SetRow(dateRow, 3);

            contentGrid.Children.Add(idRow);
            contentGrid.Children.Add(nameRow);
            contentGrid.Children.Add(addressRow);
            contentGrid.Children.Add(dateRow);

            var buttonsGrid = CreateActionButtonsGrid(applicant);
            buttonsGrid.Margin = new Thickness(0, GetResponsiveSpacing(isSmallScreen ? 10 : 15), 0, 0);
            Grid.SetRow(buttonsGrid, 4);
            contentGrid.Children.Add(buttonsGrid);

            var statusBadge = CreateStatusBadge(applicant);
            statusBadge.HorizontalOptions = LayoutOptions.End;
            statusBadge.VerticalOptions = LayoutOptions.Start;
            var badgeMargin = GetResponsiveSpacing(isSmallScreen ? -8 : -10);
            var badgeMarginRight = GetResponsiveSpacing(isSmallScreen ? -12 : -16);
            statusBadge.Margin = new Thickness(0, badgeMargin, badgeMarginRight, 0);

            contentContainer.Children.Add(contentGrid);
            contentContainer.Children.Add(statusBadge);

            mainGrid.Children.Add(leftBorder);
            mainGrid.Children.Add(contentContainer);

            cardFrame.Content = mainGrid;

            // ADDED: Add tap gesture to navigate to ApplicantDetailsPage
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnApplicantCardTapped;
            cardFrame.GestureRecognizers.Add(tapGesture);

            return cardFrame;
        }

        // ADDED: Navigation method for applicant card tap
        private async void OnApplicantCardTapped(object sender, EventArgs e)
        {
            try
            {
                if (sender is Frame frame && frame.BindingContext is ApplicantViewModel applicant)
                {
                    // Check if traceability status is unknown/not traceable
                    if (applicant.TraceabilityStatus == "Not Traceable")
                    {
                        var remarks = await ShowRemarksModal("Traceability Status", "📍");
                        if (remarks != null)
                        {
                            // TODO: Save remarks to API if needed
                            System.Diagnostics.Debug.WriteLine($"Traceability Remarks: {remarks}");
                        }
                        return;
                    }

                    int applID = applicant.ApplID;
                    var detailsPage = new ApplicantDetailsPage(applID);
                    await Navigation.PushAsync(detailsPage);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to open applicant details: {ex.Message}", "OK");
            }
        }

        // ADD this new method at the end of DetailsPage class
        private Task<string> ShowRemarksModal(string title, string icon)
        {
            var tcs = new TaskCompletionSource<string>();

            var modal = new AbsoluteLayout
            {
                BackgroundColor = Color.FromArgb("#AA000000"),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            var contentFrame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 15,
                Padding = new Thickness(25),
                WidthRequest = 340,
                HasShadow = true
            };

            var contentStack = new StackLayout { Spacing = 20 };

            // Icon at top
            var iconLabel = new Label
            {
                Text = icon,
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center
            };

            // Heading
            var headingLabel = new Label
            {
                Text = title,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#333333"),
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Remarks textbox
            var remarksEditor = new Editor
            {
                Placeholder = "Enter your remarks here...",
                FontSize = 16,
                HeightRequest = 120,
                BackgroundColor = Color.FromArgb("#F5F5F5")
            };

            // Buttons
            var buttonGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
        },
                ColumnSpacing = 15
            };

            var cancelButton = new Button
            {
                Text = "CANCEL",
                BackgroundColor = Color.FromArgb("#6C757D"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45
            };
            cancelButton.Clicked += (s, e) =>
            {
                RemoveModal(modal);
                tcs.TrySetResult(null);
            };

            var yesButton = new Button
            {
                Text = "YES",
                BackgroundColor = Color.FromArgb("#4CAF50"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45
            };
            yesButton.Clicked += (s, e) =>
            {
                var remarks = remarksEditor.Text;
                RemoveModal(modal);
                tcs.TrySetResult(remarks);
            };

            Grid.SetColumn(cancelButton, 0);
            Grid.SetColumn(yesButton, 1);
            buttonGrid.Children.Add(cancelButton);
            buttonGrid.Children.Add(yesButton);

            contentStack.Children.Add(iconLabel);
            contentStack.Children.Add(headingLabel);
            contentStack.Children.Add(remarksEditor);
            contentStack.Children.Add(buttonGrid);

            contentFrame.Content = contentStack;

            AbsoluteLayout.SetLayoutBounds(contentFrame, new Rect(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(contentFrame, AbsoluteLayoutFlags.PositionProportional);

            modal.Children.Add(contentFrame);

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(modal, 3);
                Grid.SetRow(modal, 0);
                rootGrid.Children.Add(modal);
            }

            return tcs.Task;
        }

        private void RemoveModal(AbsoluteLayout modal)
        {
            if (this.Content is Grid rootGrid)
            {
                rootGrid.Children.Remove(modal);
            }
        }

        private Frame CreateStatusBadge(ApplicantViewModel applicant)
        {
            var badgeFrame = new Frame
            {
                BackgroundColor = applicant.StatusBadgeColor,
                Padding = GetResponsivePadding(isSmallScreen ? 12 : 18, isSmallScreen ? 6 : 8), // Increased mobile padding
                CornerRadius = (float)GetResponsiveSpacing(isSmallScreen ? 15 : 20), // Slightly larger corner radius on mobile
                HasShadow = false,
                BorderColor = Colors.Transparent
            };

            var label = new Label
            {
                Text = applicant.Status,
                TextColor = Colors.White,
                FontSize = GetResponsiveFontSize(isSmallScreen ? 11 : 12), // Increased mobile font size
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, isSmallScreen ? 1 : 3, isSmallScreen ? 5 : 7, 0) // Better mobile margins
            };

            badgeFrame.Content = label;
            return badgeFrame;
        }

        private Grid CreateDetailRow(string label, string value)
        {
            var grid = new Grid();
            var labelWidth = isSmallScreen ? 120 : (isTablet ? 180 : 150);
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(labelWidth * scaleFactor) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var baseFontSize = isSmallScreen ? 12 : (isTablet ? 16 : 14);

            var labelControl = new Label
            {
                Text = label,
                FontSize = GetResponsiveFontSize(baseFontSize),
                FontAttributes = FontAttributes.None,
                TextColor = Color.FromArgb("#666666"),
                VerticalOptions = LayoutOptions.Start,
                LineBreakMode = LineBreakMode.WordWrap
            };

            var valueControl = new Label
            {
                Text = value,
                FontSize = GetResponsiveFontSize(baseFontSize),
                FontAttributes = FontAttributes.None,
                TextColor = Colors.Black,
                VerticalOptions = LayoutOptions.Start,
                LineBreakMode = LineBreakMode.WordWrap
            };

            Grid.SetColumn(labelControl, 0);
            Grid.SetColumn(valueControl, 1);

            grid.Children.Add(labelControl);
            grid.Children.Add(valueControl);

            return grid;
        }

        // MODIFIED: Updated to pass applicant parameter for documents button navigation
        private Grid CreateActionButtonsGrid(ApplicantViewModel applicant)
        {
            var buttonsGrid = new Grid
            {
                ColumnSpacing = GetResponsiveSpacing(isSmallScreen ? 2 : 3),
                HeightRequest = GetResponsiveSpacing(isSmallScreen ? 35 : 45)
            };

            if (isSmallScreen)
            {
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.5, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            else
            {
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            var buttonHeight = GetResponsiveSpacing(isSmallScreen ? 32 : 40);
            var iconSize = GetResponsiveSpacing(isSmallScreen ? 16 : 20);

            // MODIFIED: Pass applicant parameter to CreateImageIconButton for documents button
            var documentsBtn = CreateImageIconButton(applicant.DocumentsIconPath, "#4CAF50", Colors.White, buttonHeight, iconSize, applicant);
            var briefcaseBtn = CreateImageIconButton(applicant.BriefcaseIconPath, "#4CAF50", Colors.White, buttonHeight, iconSize, applicant);
            var traceabilityBtn = CreateTraceabilityButton(applicant.TraceabilityStatus, buttonHeight);
            var locationBtn = CreateImageIconButton("turn_orange.png", "#FF6B35", Colors.White, buttonHeight, iconSize, applicant);
            var phoneBtn = CreateImageIconButton("call_orange.png", "#FF6B35", Colors.White, buttonHeight, iconSize, applicant);

            Grid.SetColumn(documentsBtn, 0);
            Grid.SetColumn(briefcaseBtn, 1);
            Grid.SetColumn(traceabilityBtn, 2);
            Grid.SetColumn(locationBtn, 3);
            Grid.SetColumn(phoneBtn, 4);

            buttonsGrid.Children.Add(documentsBtn);
            buttonsGrid.Children.Add(briefcaseBtn);
            buttonsGrid.Children.Add(traceabilityBtn);
            buttonsGrid.Children.Add(locationBtn);
            buttonsGrid.Children.Add(phoneBtn);

            return buttonsGrid;
        }

        // MODIFIED: Add navigation to BankVerificationPage when documents button is tapped
        private Frame CreateImageIconButton(string imageSource, string tintColor, Color backgroundColor, double height, double iconSize, ApplicantViewModel applicant = null)
        {
            var buttonFrame = new Frame
            {
                BackgroundColor = backgroundColor,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = (float)GetResponsiveSpacing(6),
                Padding = new Thickness(0),
                HasShadow = false,
                HeightRequest = height,
                Content = new Image
                {
                    Source = imageSource,
                    Aspect = Aspect.AspectFit,
                    WidthRequest = iconSize,
                    HeightRequest = iconSize,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            };

            // Add tap gestures for phone and location buttons
            if (applicant != null)
            {
                if (imageSource.Contains("call"))
                {
                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += async (sender, e) => await OnPhoneButtonTapped(applicant);
                    buttonFrame.GestureRecognizers.Add(tapGesture);
                }
                else if (imageSource.Contains("turn"))
                {
                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += async (sender, e) => await OnLocationButtonTapped(applicant);
                    buttonFrame.GestureRecognizers.Add(tapGesture);
                }
                else if (imageSource.Contains("docs"))
                {
                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += async (sender, e) => await OnDocumentsButtonTapped(applicant);
                    buttonFrame.GestureRecognizers.Add(tapGesture);
                }
                else if (imageSource.Contains("brief"))
                {
                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += async (sender, e) => await OnBriefcaseButtonTapped(applicant);
                    buttonFrame.GestureRecognizers.Add(tapGesture);
                }
            }

            return buttonFrame;
        }

        // ADDED: Navigation method for briefcase button tap
        // EXISTING METHOD - Update to pass status
        private async Task OnBriefcaseButtonTapped(ApplicantViewModel applicant)
        {
            try
            {
                _shouldRefreshOnAppearing = true;
                // ✅ Pass the current page's status to UnitVerificationPage
                string badgeStatus = applicant.Status?.Trim() ?? "Pending";
                var unitVerificationPage = new UnitVerificationPage(
                    applicant.ApplID,
                    _status,
                    badgeStatus,
                    applicant.IsUnitVerDone
                );
                await Navigation.PushAsync(unitVerificationPage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to open unit verification: {ex.Message}", "OK");
            }
        }

        // ADDED: Navigation method for documents button tap
        private async Task OnDocumentsButtonTapped(ApplicantViewModel applicant)
        {
            try
            {
                // Navigate to BankVerificationPage with ApplID and Status
                var bankVerificationPage = new BankVerificationPage(applicant.ApplID, applicant.Status);
                await Navigation.PushAsync(bankVerificationPage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to open bank verification: {ex.Message}", "OK");
            }
        }

        private async Task OnPhoneButtonTapped(ApplicantViewModel applicant)
        {
            try
            {
                if (!string.IsNullOrEmpty(applicant.PhoneNumber))
                {
                    // Ensure valid phone number format
                    var cleanNumber = applicant.PhoneNumber.Replace(" ", "").Replace("-", "");

                    // Use "tel:" scheme for iOS and Android
                    var phoneUri = new Uri($"tel:{cleanNumber}");
                    await Launcher.OpenAsync(phoneUri);
                }
                else
                {
                    await DisplayAlert("Error", "Phone number not available", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to open phone dialer: {ex.Message}", "OK");
            }
        }


        private async Task OnLocationButtonTapped(ApplicantViewModel applicant)
        {
            try
            {
                if (!string.IsNullOrEmpty(applicant.UnitFullAddress))
                {
                    var encodedAddress = Uri.EscapeDataString(applicant.UnitFullAddress);

                    // Platform-specific map URLs
                    if (DeviceInfo.Platform == DevicePlatform.Android)
                    {
                        // Open Google Maps on Android
                        await Launcher.OpenAsync($"geo:0,0?q={encodedAddress}");
                    }
                    else if (DeviceInfo.Platform == DevicePlatform.iOS)
                    {
                        // Open Apple Maps on iOS
                        await Launcher.OpenAsync($"http://maps.apple.com/?q={encodedAddress}");
                    }
                    else
                    {
                        // Fallback for other platforms (Windows, etc.)
                        await Launcher.OpenAsync($"https://www.google.com/maps/search/?api=1&query={encodedAddress}");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Address not available", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to open maps: {ex.Message}", "OK");
            }
        }

        private Frame CreateTraceabilityButton(string status, double height)
        {
            // Default settings
            Color backgroundColor = Color.FromArgb("#E8F5E8"); // Light green
            Color textColor = Color.FromArgb("#4CAF50");       // Green
            string iconSource = "geo.png";
            string displayText = "Traceable";
            bool isUnknownStatus = false; // NEW: Track if status is Unknown

            // Apply dynamic styles based on status
            switch (status?.Trim())
            {
                case "Working":
                    backgroundColor = Color.FromArgb("#E8F5E8"); // Light green
                    textColor = Color.FromArgb("#4CAF50");       // Green
                    iconSource = "geo.png";
                    displayText = "Working";
                    break;

                case "Defunct":
                    backgroundColor = Color.FromArgb("#FFE8E8"); // Light red/pink
                    textColor = Color.FromArgb("#F44336");       // Red
                    iconSource = "defunct.png";                  // Optional: use a red variant
                    displayText = "Defunct";
                    break;

                case "Non-Tracable":
                    backgroundColor = Color.FromArgb("#FFF3E0"); // Light orange
                    textColor = Color.FromArgb("#FF6B35");       // Orange
                    iconSource = "geo_orange.png";
                    displayText = "Non-Tracable";
                    break;

                default:
                    backgroundColor = Color.FromArgb("#E0E0E0"); // Neutral gray
                    textColor = Color.FromArgb("#666666");
                    iconSource = "unknown.png";
                    displayText = "Unknown";
                    isUnknownStatus = true; // NEW: Mark as unknown
                    break;
            }

            // Create button frame
            var buttonFrame = new Frame
            {
                BackgroundColor = backgroundColor,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = (float)GetResponsiveSpacing(6),
                Padding = GetResponsivePadding(isSmallScreen ? 6 : 8, 0),
                HasShadow = false,
                HeightRequest = height
            };

            var contentGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                ColumnSpacing = GetResponsiveSpacing(4)
            };

            contentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            contentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var iconSize = GetResponsiveSpacing(isSmallScreen ? 12 : 16);
            var iconImage = new Image
            {
                Source = iconSource,
                Aspect = Aspect.AspectFit,
                WidthRequest = iconSize,
                HeightRequest = iconSize,
                VerticalOptions = LayoutOptions.Center
            };

            var fontSize = GetResponsiveFontSize(isSmallScreen ? 10 : 12);

            var textLabel = new Label
            {
                Text = displayText,
                TextColor = textColor,
                FontSize = fontSize,
                FontAttributes = FontAttributes.None,
                VerticalTextAlignment = TextAlignment.Center
            };

            Grid.SetColumn(iconImage, 0);
            Grid.SetColumn(textLabel, 1);

            contentGrid.Children.Add(iconImage);
            contentGrid.Children.Add(textLabel);
            buttonFrame.Content = contentGrid;

            // NEW: Add tap gesture for Unknown status
            if (isUnknownStatus)
            {
                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += async (s, e) =>
                {
                    var remarks = await ShowRemarksModal("Unknown Traceability Status", "📍");
                    if (remarks != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Unknown Status Remarks: {remarks}");
                        // TODO: Save remarks to API if needed
                    }
                };
                buttonFrame.GestureRecognizers.Add(tapGesture);
            }

            return buttonFrame;
        }


        private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
        {
            // Show loader during search filtering
            ShowLoader();

            _viewModel.SearchText = e.NewTextValue ?? "";
            DisplayApplicants(_viewModel.FilteredApplicants.ToList());

            // Hide loader after filtering is complete
            HideLoader();
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    _viewModel?.Dispose();
        //}
    }
}