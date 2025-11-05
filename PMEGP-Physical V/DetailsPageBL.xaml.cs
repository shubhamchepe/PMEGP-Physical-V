F#nullable enable

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PMEGP_Physical_V
{
    // API Models for Bank Login
    public class BankApiRequest
    {
        [JsonPropertyName("bankIfsc")]
        public string BankIfsc { get; set; } = string.Empty;
    }

    public class BankApiResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("BankIFSC")]
        public string? BankIFSC { get; set; }

        [JsonPropertyName("UnderProcess")]
        public List<BankApplicantData> UnderProcess { get; set; } = new();

        [JsonPropertyName("Completed")]
        public List<BankApplicantData> Completed { get; set; } = new();
    }

    public class BankApplicantData
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

        [JsonPropertyName("MobileNo1")]
        public string MobileNo1 { get; set; } = string.Empty;
    }

    // View Model for Bank Applicant
    public class BankApplicantViewModel : INotifyPropertyChanged
    {
        public int ApplID { get; set; }
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DateOfSubmission { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DetailsPageBLViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "https://115.124.125.153/MobileApp/GetBankApplicationData";

        private ObservableCollection<BankApplicantViewModel> _applicants = new();
        private ObservableCollection<BankApplicantViewModel> _filteredApplicants = new();
        private bool _isLoading;
        private string _errorMessage = string.Empty;
        private string _searchText = string.Empty;

        public ObservableCollection<BankApplicantViewModel> Applicants
        {
            get => _applicants;
            set
            {
                _applicants = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BankApplicantViewModel> FilteredApplicants
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

        public DetailsPageBLViewModel()
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

        public async Task LoadDataAsync(string bankIfsc, string status)
        {
            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                // Build API URL with query parameter
                string apiUrl = $"{API_URL}?bankIfsc={bankIfsc}";

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
                        PropertyNameCaseInsensitive = true,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    };

                    var apiResponse = JsonSerializer.Deserialize<BankApiResponse>(jsonString, options);

                    if (apiResponse?.Success == true)
                    {
                        // Select the correct list based on status
                        List<BankApplicantData> dataList;
                        if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
                            status.Equals("PendingApplications", StringComparison.OrdinalIgnoreCase))
                        {
                            dataList = apiResponse.UnderProcess;
                        }
                        else // Completed
                        {
                            dataList = apiResponse.Completed;
                        }

                        var applicantViewModels = dataList.Select(MapToViewModel).ToList();

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

        private BankApplicantViewModel MapToViewModel(BankApplicantData data)
        {
            var viewModel = new BankApplicantViewModel
            {
                ApplID = data.ApplID,
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

    public partial class DetailsPageBL : ContentPage
    {
        private readonly DetailsPageBLViewModel _viewModel;
        private double screenWidth;
        private double screenHeight;
        private double scaleFactor;
        private bool isSmallScreen;
        private bool isTablet;

        public DetailsPageBL(string bankIfsc, string status)
        {
            InitializeComponent();

            _viewModel = new DetailsPageBLViewModel();
            BindingContext = _viewModel;

            InitializeResponsiveDesign();
            _ = LoadDataAsync(bankIfsc, status);

            if (SearchEntry != null)
            {
                SearchEntry.TextChanged += OnSearchTextChanged;
            }
        }

        private async Task LoadDataAsync(string bankIfsc, string status)
        {
            await _viewModel.LoadDataAsync(bankIfsc, status);

            if (!_viewModel.IsLoading && string.IsNullOrEmpty(_viewModel.ErrorMessage))
            {
                DisplayApplicants(_viewModel.FilteredApplicants.ToList());
            }
            else if (!string.IsNullOrEmpty(_viewModel.ErrorMessage))
            {
                await DisplayAlert("Error", _viewModel.ErrorMessage, "OK");
            }
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

        private double GetResponsiveFontSize(double baseSize) => baseSize * scaleFactor;
        private double GetResponsiveSpacing(double baseSpacing) => baseSpacing * scaleFactor;
        private Thickness GetResponsivePadding(double basePadding) => new Thickness(basePadding * scaleFactor);
        private Thickness GetResponsivePadding(double horizontal, double vertical) => new Thickness(horizontal * scaleFactor, vertical * scaleFactor);

        private void DisplayApplicants(List<BankApplicantViewModel> applicantsToShow)
        {
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

        private Frame CreateApplicantCard(BankApplicantViewModel applicant)
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

            for (int i = 0; i < 4; i++)
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

            contentContainer.Children.Add(contentGrid);

            mainGrid.Children.Add(leftBorder);
            mainGrid.Children.Add(contentContainer);

            cardFrame.Content = mainGrid;

            // Add tap gesture to navigate to ApplicantDetailsPage
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnApplicantCardTapped;
            cardFrame.GestureRecognizers.Add(tapGesture);

            return cardFrame;
        }

        private async void OnApplicantCardTapped(object sender, EventArgs e)
        {
            try
            {
                if (sender is Frame frame && frame.BindingContext is BankApplicantViewModel applicant)
                {
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

        private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
        {
            _viewModel.SearchText = e.NewTextValue ?? "";
            DisplayApplicants(_viewModel.FilteredApplicants.ToList());
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel?.Dispose();
        }
    }
}