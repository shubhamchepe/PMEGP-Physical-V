#nullable enable

using System.Text.Json;
using System.Text.Json.Serialization;

namespace PMEGP_Physical_V
{
    // ... (Keep all your existing model classes exactly as they are)

    public partial class ApplicantDetailsPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        private readonly int _applID;
        private const string API_URL = "https://115.124.125.153/MobileApp/GetApplDataForPV";
        private const string IMAGE_API_URL = "https://115.124.125.153/MobileApp/GetApplicantImage";

        // Responsive design properties
        private double screenWidth;
        private double screenHeight;
        private double scaleFactor = 1.0;
        private bool isInitialized = false;

        // Base dimensions for scaling calculations (based on design width ~400px)
        private const double BASE_DESIGN_WIDTH = 400.0;

        // Dropdown state - default to opened
        private bool isDetailsExpanded = true;

        public ApplicantDetailsPage(int applID)
        {
            InitializeComponent();
            _applID = applID;

            // Initialize HttpClient with SSL bypass
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            InitializeDropdownState();
            _ = LoadApplicantDataAsync();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > 0 && height > 0 && (!isInitialized || Math.Abs(screenWidth - width) > 10))
            {
                screenWidth = width;
                screenHeight = height;

                // Calculate scale factor based on screen width vs base design width
                scaleFactor = Math.Max(0.6, Math.Min(1.4, width / BASE_DESIGN_WIDTH));

                ApplyResponsiveStyling();
                isInitialized = true;
            }
        }

        private void ApplyResponsiveStyling()
        {
            try
            {
                // Calculate responsive sizes
                var headerPadding = Math.Max(8, 15 * scaleFactor);
                var cardMargin = Math.Max(6, 10 * scaleFactor);
                var cardPadding = Math.Max(8, 15 * scaleFactor);
                var elementSpacing = Math.Max(4, 8 * scaleFactor);

                // Font sizes
                var headerFontSize = Math.Max(12, 16 * scaleFactor);
                var nameFontSize = Math.Max(12, 16 * scaleFactor);
                var codeFontSize = Math.Max(9, 12 * scaleFactor);
                var labelFontSize = Math.Max(9, 12 * scaleFactor);
                var valueFontSize = Math.Max(10, 13 * scaleFactor);
                var buttonFontSize = Math.Max(10, 12 * scaleFactor);
                var initialsFontSize = Math.Max(14, 18 * scaleFactor);
                var backButtonFontSize = Math.Max(16, 24 * scaleFactor);
                var dropdownFontSize = Math.Max(12, 16 * scaleFactor);

                // Button and element sizes
                var backButtonSize = Math.Max(25, 35 * scaleFactor);
                var dropdownButtonSize = Math.Max(20, 25 * scaleFactor);
                var avatarSize = Math.Max(30, 45 * scaleFactor);
                var buttonHeight = Math.Max(30, 40 * scaleFactor);
                var buttonSpacing = Math.Max(5, 8 * scaleFactor);

                // Image dimensions
                var imageWidth = Math.Max(60, 80 * scaleFactor);
                var imageHeight = Math.Max(70, 95 * scaleFactor);
                var imageCornerRadius = Math.Max(4, 6 * scaleFactor);
                var avatarCornerRadius = avatarSize / 2;

                // Label width for consistent alignment
                var titleLabelWidth = Math.Max(80, 110 * scaleFactor);

                // Apply header styling
                if (HeaderGrid != null)
                    HeaderGrid.Padding = new Thickness(headerPadding, headerPadding * 0.7, headerPadding, headerPadding * 0.7);

                if (HeaderTitle != null)
                    HeaderTitle.FontSize = headerFontSize;

                if (BackButton != null)
                {
                    BackButton.FontSize = backButtonFontSize;
                    BackButton.WidthRequest = backButtonSize;
                    BackButton.HeightRequest = backButtonSize;
                }

                // Apply card margins and padding
                if (ProfileHeaderFrame != null)
                {
                    ProfileHeaderFrame.Margin = new Thickness(cardMargin, cardMargin, cardMargin, 0);
                    ProfileHeaderFrame.Padding = new Thickness(cardPadding);
                }

                if (DetailsFrame != null)
                {
                    DetailsFrame.Margin = new Thickness(cardMargin, cardMargin * 0.8, cardMargin, 0);
                }

                if (DetailsGrid != null)
                    DetailsGrid.Padding = new Thickness(cardPadding);

                if (DetailsStack != null)
                    DetailsStack.Spacing = elementSpacing;

                if (ButtonsGrid != null)
                {
                    ButtonsGrid.Margin = new Thickness(cardPadding, 0, cardPadding, cardPadding);
                    ButtonsGrid.ColumnSpacing = buttonSpacing;
                }

                // Apply dropdown button styling
                if (DropdownButton != null)
                {
                    DropdownButton.FontSize = dropdownFontSize;
                    DropdownButton.WidthRequest = dropdownButtonSize;
                    DropdownButton.HeightRequest = dropdownButtonSize;
                    DropdownButton.Margin = new Thickness(0, 0, elementSpacing, 0);
                }

                // Apply profile avatar styling
                if (ProfileAvatarFrame != null)
                {
                    ProfileAvatarFrame.WidthRequest = avatarSize;
                    ProfileAvatarFrame.HeightRequest = avatarSize;
                    ProfileAvatarFrame.CornerRadius = (float)avatarCornerRadius;
                }

                if (ProfileInitials != null)
                    ProfileInitials.FontSize = initialsFontSize;

                if (NameStack != null)
                    NameStack.Margin = new Thickness(elementSpacing * 1.5, 0, 0, 0);

                // Apply name and code styling
                if (ApplicantNameLabel != null)
                    ApplicantNameLabel.FontSize = nameFontSize;

                if (ApplicantCodeLabel != null)
                    ApplicantCodeLabel.FontSize = codeFontSize;

                // Apply profile image styling
                if (ImageContainer != null)
                    ImageContainer.Margin = new Thickness(elementSpacing, 0, 0, 0);

                if (ProfileImageFrame != null)
                {
                    ProfileImageFrame.WidthRequest = imageWidth;
                    ProfileImageFrame.HeightRequest = imageHeight;
                    ProfileImageFrame.CornerRadius = (float)imageCornerRadius;
                }

                if (ImageFallbackLabel != null)
                    ImageFallbackLabel.FontSize = Math.Max(8, 10 * scaleFactor);

                // Apply button styling
                if (BankVerificationButton != null)
                {
                    BankVerificationButton.FontSize = buttonFontSize;
                    BankVerificationButton.HeightRequest = buttonHeight;
                }

                if (UnitVerificationButton != null)
                {
                    UnitVerificationButton.FontSize = buttonFontSize;
                    UnitVerificationButton.HeightRequest = buttonHeight;
                }

                // Apply error layout styling
                if (ErrorLayout != null)
                    ErrorLayout.Padding = new Thickness(cardPadding);

                if (ErrorLabel != null)
                    ErrorLabel.FontSize = Math.Max(11, 14 * scaleFactor);

                if (RetryButton != null)
                {
                    RetryButton.FontSize = buttonFontSize;
                    RetryButton.Padding = new Thickness(cardPadding, elementSpacing);
                }

                if (LoadingIndicator != null)
                    LoadingIndicator.Margin = new Thickness(0, cardMargin * 2, 0, cardMargin * 2);

                // Apply styling to all detail rows
                ApplyDetailRowStyling(titleLabelWidth, labelFontSize, valueFontSize);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error applying responsive styling: {ex.Message}");
            }
        }

        private void ApplyDetailRowStyling(double titleWidth, double labelFontSize, double valueFontSize)
        {
            // Helper method to apply styling to detail row elements
            var singleLineRows = new[]
            {
                (AadhaarTitleLabel, AadhaarLabel),
                (PanTitleLabel, PanLabel),
                (DobTitleLabel, DobLabel),
                (SubmissionTitleLabel, SubmissionDateLabel),
                (GenderTitleLabel, GenderLabel),
                (UnitLocationTitleLabel, UnitLocationLabel),
                (CategoryTitleLabel, CategoryLabel),
                (MobileTitleLabel, MobileLabel),
                (EducationTitleLabel, EducationLabel),
                (EdpTrainingTitleLabel, EdpTrainingLabel)
            };

            // Multi-line capable rows (email and special category)
            var multiLineRows = new[]
            {
                (SpecialCategoryTitleLabel, SpecialCategoryLabel),
                (EmailTitleLabel, EmailLabel)
            };

            // Apply styling to single-line rows
            foreach (var (titleLabel, valueLabel) in singleLineRows)
            {
                if (titleLabel != null)
                {
                    titleLabel.FontSize = labelFontSize;
                    titleLabel.WidthRequest = titleWidth;
                }

                if (valueLabel != null)
                    valueLabel.FontSize = valueFontSize;
            }

            // Apply styling to multi-line rows with slightly smaller font for better fit
            foreach (var (titleLabel, valueLabel) in multiLineRows)
            {
                if (titleLabel != null)
                {
                    titleLabel.FontSize = labelFontSize;
                    titleLabel.WidthRequest = titleWidth;
                }

                if (valueLabel != null)
                {
                    // Slightly smaller font for multi-line text to fit better
                    valueLabel.FontSize = Math.Max(9, valueFontSize * 0.9);
                }
            }
        }

        private void InitializeDropdownState()
        {
            if (DropdownButton != null)
                DropdownButton.Rotation = 180;

            if (DetailsFrame != null)
                DetailsFrame.IsVisible = true;
        }

        // ... (Keep all your existing API and data loading methods exactly as they are)

        private async Task LoadApplicantDataAsync()
        {
            try
            {
                ShowLoading();

                var response = await _httpClient.GetAsync($"{API_URL}?applID={_applID}");

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

                    var apiResponse = JsonSerializer.Deserialize<ApplicantDetailResponse>(jsonString, options);

                    if (apiResponse?.ApplicantData != null)
                    {
                        PopulateUI(apiResponse);
                        ShowContent();
                        _ = LoadProfileImageAsync(_applID);
                    }
                    else
                    {
                        throw new Exception("No applicant data found");
                    }
                }
                else
                {
                    throw new Exception($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                ShowError($"Network error: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                ShowError("Request timeout. Please check your internet connection.");
            }
            catch (JsonException ex)
            {
                ShowError($"Failed to parse server response: {ex.Message}");
            }
            catch (Exception ex)
            {
                ShowError($"Failed to load applicant data: {ex.Message}");
            }
        }

        private async Task LoadProfileImageAsync(int applId)
        {
            try
            {
                ImageLoadingIndicator.IsVisible = true;
                ImageLoadingIndicator.IsRunning = true;
                ProfileImage.IsVisible = false;
                ImageFallbackLabel.IsVisible = false;

                var imageRequest = new ImageRequest { ApplId = applId };
                var jsonRequest = JsonSerializer.Serialize(imageRequest);
                var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(IMAGE_API_URL, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                        };

                        var imageResponse = JsonSerializer.Deserialize<ImageResponse>(jsonString, options);

                        if (imageResponse?.Success == true && !string.IsNullOrEmpty(imageResponse.ApplicantPhotoBase64))
                        {
                            var imageBytes = Convert.FromBase64String(imageResponse.ApplicantPhotoBase64);
                            var imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                            ProfileImage.Source = imageSource;
                            ProfileImage.IsVisible = true;
                            ImageLoadingIndicator.IsVisible = false;
                            ImageLoadingIndicator.IsRunning = false;
                        }
                        else
                        {
                            ShowImageFallback();
                        }
                    }
                    else
                    {
                        ShowImageFallback();
                    }
                }
                else
                {
                    ShowImageFallback();
                }
            }
            catch (Exception)
            {
                ShowImageFallback();
            }
        }

        private void ShowImageFallback()
        {
            ImageLoadingIndicator.IsVisible = false;
            ImageLoadingIndicator.IsRunning = false;
            ProfileImage.IsVisible = false;
            ImageFallbackLabel.IsVisible = true;
        }

        private void PopulateUI(ApplicantDetailResponse response)
        {
            var data = response.ApplicantData!;

            // Profile header
            ProfileInitials.Text = GetInitials(data.ApplName);
            ApplicantNameLabel.Text = data.ApplName;
            ApplicantCodeLabel.Text = data.ApplCode;

            // Basic details
            AadhaarLabel.Text = data.AadharNo;
            PanLabel.Text = string.IsNullOrEmpty(data.PANNo) ? "Not Provided" : data.PANNo;
            DobLabel.Text = ParseDateFromJson(data.DateofBirth);
            GenderLabel.Text = GetGenderDisplay(data.Gender);
            UnitLocationLabel.Text = string.IsNullOrEmpty(data.UnitLocation) ? "Not Specified" : data.UnitLocation;
            CategoryLabel.Text = data.SocialCatID;
            SpecialCategoryLabel.Text = data.SpecialCatID;
            MobileLabel.Text = data.MobileNo1;
            EmailLabel.Text = string.IsNullOrEmpty(data.EMail) ? "Not Provided" : data.EMail;
            EducationLabel.Text = string.IsNullOrEmpty(data.QualDesc) ? "Not Provided" : data.QualDesc;

            var submissionDate = !string.IsNullOrEmpty(data.FinalSubDate) ?
                ParseDateFromJson(data.FinalSubDate) :
                (!string.IsNullOrEmpty(data.CreatedOn) ? ParseDateFromJson(data.CreatedOn) : "Not Available");

            SubmissionDateLabel.Text = submissionDate;

            var edpStatus = response.EdpTrainingModel?.TrainingMode == true ? "DONE" : "PENDING";
            EdpTrainingLabel.Text = edpStatus;

            UpdateButtonStates(response.PhyVerificationModel);
        }

        private void UpdateButtonStates(PhysicalVerificationData? phyData)
        {
            if (phyData?.IsBankVerDone == true)
            {
                BankVerificationButton.BackgroundColor = Color.FromArgb("#FF6B35");
                BankVerificationButton.Text = "Bank Verification";
            }
            else
            {
                BankVerificationButton.BackgroundColor = Color.FromArgb("#FF6B35");
                BankVerificationButton.Text = "Bank Verification";
            }

            if (phyData?.IsUnitVerDone == true)
            {
                UnitVerificationButton.BackgroundColor = Color.FromArgb("#BAD99E");
                UnitVerificationButton.TextColor = Color.FromArgb("#FF6B35");
                UnitVerificationButton.Text = "Unit Verification";
            }
            else
            {
                UnitVerificationButton.BackgroundColor = Color.FromArgb("#E0E0E0");
                UnitVerificationButton.TextColor = Color.FromArgb("#000000");
                UnitVerificationButton.Text = "Unit Verification";
            }
        }

        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "NA";

            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                return $"{parts[0][0]}{parts[1][0]}".ToUpper();
            }
            else if (parts.Length == 1 && parts[0].Length >= 2)
            {
                return parts[0].Substring(0, 2).ToUpper();
            }

            return fullName.Substring(0, Math.Min(2, fullName.Length)).ToUpper();
        }

        private string GetGenderDisplay(string gender)
        {
            return gender?.ToUpper() switch
            {
                "M" => "Male",
                "F" => "Female",
                "T" => "Transgender",
                _ => gender ?? "Not Specified"
            };
        }

        private string ParseDateFromJson(string jsonDate)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonDate))
                    return "Not Available";

                if (jsonDate.StartsWith("/Date(") && jsonDate.EndsWith(")/"))
                {
                    var timestampStr = jsonDate.Substring(6, jsonDate.Length - 8);
                    if (long.TryParse(timestampStr, out var timestamp))
                    {
                        var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
                        return dateTime.DateTime.ToString("dd-MM-yyyy");
                    }
                }

                if (DateTime.TryParse(jsonDate, out var parsedDate))
                {
                    return parsedDate.ToString("dd-MM-yyyy");
                }

                return "Invalid Date";
            }
            catch
            {
                return "Invalid Date";
            }
        }

        private async void OnDropdownClicked(object sender, EventArgs e)
        {
            isDetailsExpanded = !isDetailsExpanded;

            var rotation = isDetailsExpanded ? 180 : 270;
            await DropdownButton.RotateTo(rotation, 200);

            DetailsFrame.IsVisible = isDetailsExpanded;
        }

        private void ShowLoading()
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;
            ContentLayout.IsVisible = false;
            ErrorLayout.IsVisible = false;
        }

        private void ShowContent()
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
            ContentLayout.IsVisible = true;
            ErrorLayout.IsVisible = false;
        }

        private void ShowError(string message)
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
            ContentLayout.IsVisible = false;
            ErrorLayout.IsVisible = true;
            ErrorLabel.Text = message;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnRetryButtonClicked(object sender, EventArgs e)
        {
            await LoadApplicantDataAsync();
        }

        private async void OnBankVerificationClicked(object sender, EventArgs e)
        {
            try
            {
                // Navigate to BankVerificationPage and pass the applID
                var bankVerificationPage = new BankVerificationPage(_applID);
                await Navigation.PushAsync(bankVerificationPage);
            }
            catch (Exception ex)
            {
                // Handle navigation error gracefully
                await DisplayAlert("Error", $"Failed to open Bank Verification page: {ex.Message}", "OK");
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }

        private async void OnUnitVerificationClicked(object sender, EventArgs e)
        {
            try
            {
                // Navigate to UnitVerificationPage and pass the applID
                var unitVerificationPage = new UnitVerificationPage(_applID);
                await Navigation.PushAsync(unitVerificationPage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to open Unit Verification page: {ex.Message}", "OK");
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _httpClient?.Dispose();
        }
    }

    // API Models (keep your existing model classes unchanged)
    public class ApplicantDetailResponse
    {
        [JsonPropertyName("applicantData")]
        public ApplicantDetailData? ApplicantData { get; set; }

        [JsonPropertyName("bankProcess")]
        public BankProcessData? BankProcess { get; set; }

        [JsonPropertyName("phyVerificationModel")]
        public PhysicalVerificationData? PhyVerificationModel { get; set; }

        [JsonPropertyName("edpTrainingModel")]
        public EdpTrainingData? EdpTrainingModel { get; set; }
    }

    public class ApplicantDetailData
    {
        [JsonPropertyName("ApplID")]
        public int ApplID { get; set; }

        [JsonPropertyName("ApplCode")]
        public string ApplCode { get; set; } = string.Empty;

        [JsonPropertyName("ApplName")]
        public string ApplName { get; set; } = string.Empty;

        [JsonPropertyName("AadharNo")]
        public string AadharNo { get; set; } = string.Empty;

        [JsonPropertyName("PANNo")]
        public string PANNo { get; set; } = string.Empty;

        [JsonPropertyName("DateofBirth")]
        public string DateofBirth { get; set; } = string.Empty;

        [JsonPropertyName("Gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("UnitLocation")]
        public string UnitLocation { get; set; } = string.Empty;

        [JsonPropertyName("SocialCatID")]
        public string SocialCatID { get; set; } = string.Empty;

        [JsonPropertyName("SpecialCatID")]
        public string SpecialCatID { get; set; } = string.Empty;

        [JsonPropertyName("MobileNo1")]
        public string MobileNo1 { get; set; } = string.Empty;

        [JsonPropertyName("eMail")]
        public string EMail { get; set; } = string.Empty;

        [JsonPropertyName("QualDesc")]
        public string QualDesc { get; set; } = string.Empty;

        [JsonPropertyName("CreatedOn")]
        public string CreatedOn { get; set; } = string.Empty;

        [JsonPropertyName("FinalSubDate")]
        public string FinalSubDate { get; set; } = string.Empty;
    }

    public class BankProcessData
    {
        [JsonPropertyName("DepDate")]
        public string DepDate { get; set; } = string.Empty;

        [JsonPropertyName("SancDate")]
        public string SancDate { get; set; } = string.Empty;
    }

    public class PhysicalVerificationData
    {
        [JsonPropertyName("isBankVerDone")]
        public bool? IsBankVerDone { get; set; }

        [JsonPropertyName("isUnitVerDone")]
        public bool? IsUnitVerDone { get; set; }
    }

    public class EdpTrainingData
    {
        [JsonPropertyName("TrainingMode")]
        public bool TrainingMode { get; set; }

        [JsonPropertyName("CertIssueDate")]
        public string CertIssueDate { get; set; } = string.Empty;
    }

    public class ImageRequest
    {
        [JsonPropertyName("appliid")]
        public int ApplId { get; set; }
    }

    public class ImageResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("appliid")]
        public int ApplId { get; set; }

        [JsonPropertyName("applicantPhotoBase64")]
        public string ApplicantPhotoBase64 { get; set; } = string.Empty;
    }
}