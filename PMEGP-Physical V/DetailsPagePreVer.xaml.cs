using Microsoft.Maui.Layouts;

namespace PMEGP_Physical_V
{
    public class PreVerApplicant
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DateOfSubmission { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty; // ADD THIS LINE
    }

    public class PreVerApiResponse
    {
        public bool Success { get; set; }
        public List<PreVerApiData>? Data { get; set; }
    }

    public class PreVerApiData
    {
        public int ApplID { get; set; }
        public string? ApplCode { get; set; }
        public string? ApplName { get; set; }
        public string? UnitAddress { get; set; }
        public string? MobileNo1 { get; set; }
        public string? FinalSubDate { get; set; }
        // Add other fields as needed from API response
    }

    public partial class DetailsPagePreVer : ContentPage
    {
        private readonly string _status;
        private double screenWidth;
        private double screenHeight;
        private double scaleFactor;
        private bool isSmallScreen;
        private bool isTablet;
        private List<PreVerApplicant> _allApplicants = new List<PreVerApplicant>();
        private readonly HttpClient _httpClient;
        private List<int> _applIds = new List<int>();

        public DetailsPagePreVer(string status)
        {
            InitializeComponent();
            _status = status;

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

            InitializeResponsiveDesign();

            if (SearchEntry != null)
            {
                SearchEntry.TextChanged += OnSearchTextChanged;
            }

            // Load data from API instead of hardcoded
            LoadDataFromApi();
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

        private async void LoadDataFromApi()
        {
            try
            {
                const string API_URL = "https://115.124.125.153/MobileApp/GetPrePostalVerificationList";

                var requestPayload = new
                {
                    userName = "Test",
                    status = _status.ToLower() // "pending" or "completed"
                };

                var json = System.Text.Json.JsonSerializer.Serialize(requestPayload);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(API_URL, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(jsonString))
                    {
                        await DisplayAlert("Error", "Empty response from server", "OK");
                        return;
                    }

                    var options = new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var apiResponse = System.Text.Json.JsonSerializer.Deserialize<PreVerApiResponse>(jsonString, options);

                    if (apiResponse?.Success == true && apiResponse.Data != null)
                    {
                        _allApplicants = apiResponse.Data.Select(item => new PreVerApplicant
                        {
                            Id = item.ApplCode ?? "",
                            Name = item.ApplName ?? "",
                            Address = item.UnitAddress ?? "",
                            DateOfSubmission = FormatDate(item.FinalSubDate),
                            Status = _status,
                            PhoneNumber = item.MobileNo1 ?? ""
                        }).ToList();

                        _applIds = apiResponse.Data.Select(item => item.ApplID).ToList();

                        DisplayApplicants(_allApplicants);
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to load data", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", $"HTTP Error: {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"API Error: {ex.Message}");
                await DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            }
        }

        private string FormatDate(string? dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return "N/A";

            try
            {
                // Handle /Date(timestamp)/ format
                if (dateString.StartsWith("/Date("))
                {
                    var timestamp = dateString.Replace("/Date(", "").Replace(")/", "");
                    if (long.TryParse(timestamp, out long milliseconds))
                    {
                        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        var date = epoch.AddMilliseconds(milliseconds);
                        return date.ToString("dd-MM-yyyy");
                    }
                }
                return dateString;
            }
            catch
            {
                return "N/A";
            }
        }

        private void DisplayApplicants(List<PreVerApplicant> applicants)
        {
            ApplicantsContainer.IsVisible = true;

            if (ApplicantsContainer == null) return;

            ApplicantsContainer.Children.Clear();
            ApplicantsContainer.RowDefinitions.Clear();
            ApplicantsContainer.RowSpacing = GetResponsiveSpacing(isSmallScreen ? 8 : 12);

            for (int i = 0; i < applicants.Count; i++)
            {
                ApplicantsContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var applicantCard = CreateApplicantCard(applicants[i]);
                Grid.SetRow(applicantCard, i);
                ApplicantsContainer.Children.Add(applicantCard);
            }
        }

        private Frame CreateApplicantCard(PreVerApplicant applicant)
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

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) =>
            {
                var index = _allApplicants.IndexOf(applicant);
                if (index >= 0 && index < _applIds.Count)
                {
                    await Navigation.PushAsync(new InspectionDetailsPage(_applIds[index]));
                }
            };
            cardFrame.GestureRecognizers.Add(tapGesture);

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

            var statusBadge = CreateStatusBadge(applicant.Status);
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

            return cardFrame;
        }

        private Frame CreateStatusBadge(string status)
        {
            var badgeColor = status == "Pending" ? Color.FromArgb("#F44336") : Color.FromArgb("#4CAF50");

            var badgeFrame = new Frame
            {
                BackgroundColor = badgeColor,
                Padding = GetResponsivePadding(isSmallScreen ? 12 : 18, isSmallScreen ? 6 : 8),
                CornerRadius = (float)GetResponsiveSpacing(isSmallScreen ? 15 : 20),
                HasShadow = false,
                BorderColor = Colors.Transparent
            };

            var label = new Label
            {
                Text = status,
                TextColor = Colors.White,
                FontSize = GetResponsiveFontSize(isSmallScreen ? 11 : 12),
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, isSmallScreen ? 1 : 3, isSmallScreen ? 5 : 7, 0)
            };

            badgeFrame.Content = label;
            return badgeFrame;
        }

        private Grid CreateActionButtonsGrid(PreVerApplicant applicant)
        {
            var buttonsGrid = new Grid
            {
                ColumnSpacing = GetResponsiveSpacing(isSmallScreen ? 8 : 12),
                HeightRequest = GetResponsiveSpacing(isSmallScreen ? 35 : 45)
            };

            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var buttonHeight = GetResponsiveSpacing(isSmallScreen ? 32 : 40);
            var iconSize = GetResponsiveSpacing(isSmallScreen ? 16 : 20);

            var callBtn = CreateImageIconButton("call_orange.png", "#FF6B35", Colors.White, buttonHeight, iconSize, applicant);
            var phoneBtn = CreateImageIconButton("call_logs.png", "#FF6B35", Colors.White, buttonHeight, iconSize, applicant);
            var smsBtn = CreateImageIconButton("sms.png", "#FF6B35", Colors.White, buttonHeight, iconSize, applicant);

            Grid.SetColumn(callBtn, 0);
            Grid.SetColumn(phoneBtn, 1);
            Grid.SetColumn(smsBtn, 2);

            buttonsGrid.Children.Add(callBtn);
            buttonsGrid.Children.Add(phoneBtn);
            buttonsGrid.Children.Add(smsBtn);

            return buttonsGrid;
        }

        private Frame CreateImageIconButton(string imageSource, string tintColor, Color backgroundColor, double height, double iconSize, PreVerApplicant applicant)
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

            var tapGesture = new TapGestureRecognizer();

            if (imageSource.Contains("call_orange.png") && !imageSource.Contains("call_logs"))
            {
                tapGesture.Tapped += async (sender, e) => await OnCallButtonTapped(applicant);
            }
            else if (imageSource.Contains("call_logs"))
            {
                tapGesture.Tapped += async (sender, e) => await OnPhoneButtonTapped(applicant);
            }
            else if (imageSource.Contains("sms"))
            {
                tapGesture.Tapped += async (sender, e) => await OnSmsButtonTapped(applicant);
            }

            buttonFrame.GestureRecognizers.Add(tapGesture);

            return buttonFrame;
        }

        private async Task OnCallButtonTapped(PreVerApplicant applicant)
        {
            try
            {
                var phoneNumber = applicant.PhoneNumber;

                if (string.IsNullOrEmpty(phoneNumber))
                {
                    await DisplayAlert("Error", "Phone number not available", "OK");
                    return;
                }

                if (PhoneDialer.IsSupported)
                {
                    PhoneDialer.Open(phoneNumber);
                }
                else
                {
                    await DisplayAlert("Not Supported", "Phone dialer is not supported on this device", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to open dialer: {ex.Message}", "OK");
            }
        }

        private async Task OnPhoneButtonTapped(PreVerApplicant applicant)
        {
            try
            {
                var phoneNumber = applicant.PhoneNumber;

                if (string.IsNullOrEmpty(phoneNumber))
                {
                    await DisplayAlert("Error", "Phone number not available", "OK");
                    return;
                }

                // Request call log permissions
                var status = await Permissions.RequestAsync<CallLogPermission>();

                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permission Denied", "Call log access is required to view call history.", "OK");
                    return;
                }

                // Fetch call logs for this phone number
                var callLogs = await GetCallLogsForNumber(phoneNumber);

                if (callLogs == null || callLogs.Count == 0)
                {
                    await DisplayAlert("No Call Logs", $"No call logs found for {phoneNumber}", "OK");
                    return;
                }

                // Navigate to call log details page
                await Navigation.PushAsync(new CallLogDetailsPage(applicant, callLogs));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to fetch call logs: {ex.Message}", "OK");
            }
        }

        private async Task<List<CallLogEntry>> GetCallLogsForNumber(string phoneNumber)
        {
            var callLogs = new List<CallLogEntry>();

            try
            {
                var cleanNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace("+", "");

#if ANDROID
        var contentResolver = Android.App.Application.Context.ContentResolver;
        var uri = Android.Provider.CallLog.Calls.ContentUri;
        
        string[] projection = new string[]
        {
            Android.Provider.CallLog.Calls.Number,
            Android.Provider.CallLog.Calls.Type,
            Android.Provider.CallLog.Calls.Date,
            Android.Provider.CallLog.Calls.Duration
        };

        var cursor = contentResolver.Query(uri, projection, null, null, Android.Provider.CallLog.Calls.Date + " DESC");

        if (cursor != null && cursor.MoveToFirst())
        {
            do
            {
                var number = cursor.GetString(cursor.GetColumnIndex(Android.Provider.CallLog.Calls.Number));
                var cleanLogNumber = number?.Replace(" ", "").Replace("-", "").Replace("+", "") ?? "";

                if (cleanLogNumber.Contains(cleanNumber) || cleanNumber.Contains(cleanLogNumber))
                {
                    var type = cursor.GetInt(cursor.GetColumnIndex(Android.Provider.CallLog.Calls.Type));
                    var dateMillis = cursor.GetLong(cursor.GetColumnIndex(Android.Provider.CallLog.Calls.Date));
                    var duration = cursor.GetInt(cursor.GetColumnIndex(Android.Provider.CallLog.Calls.Duration));

                    var callType = type switch
                    {
                        (int)Android.Provider.CallType.Incoming => "Incoming",
                        (int)Android.Provider.CallType.Outgoing => "Outgoing",
                        (int)Android.Provider.CallType.Missed => "Missed",
                        (int)Android.Provider.CallType.Rejected => "Rejected",
                        _ => "Unknown"
                    };

                    var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(dateMillis).LocalDateTime;

                    callLogs.Add(new CallLogEntry
                    {
                        PhoneNumber = number,
                        CallType = callType,
                        DateTime = dateTime,
                        Duration = duration
                    });
                }
            }
            while (cursor.MoveToNext());

            cursor.Close();
        }
#elif IOS
        // iOS implementation using CallKit
        var callObserver = new CallKit.CXCallObserver();
        // Note: iOS doesn't provide direct access to call logs due to privacy restrictions
        // This is a placeholder - actual implementation would require CallKit framework
        await DisplayAlert("iOS Limitation", "iOS does not provide direct access to call logs. Please use Android device.", "OK");
#endif
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching call logs: {ex.Message}");
            }

            return callLogs;
        }

        private async Task OnSmsButtonTapped(PreVerApplicant applicant)
        {
            try
            {
                var shouldSend = await ShowSmsConfirmationModal();

                if (shouldSend)
                {
                    var phoneNumber = applicant.PhoneNumber; // Now uses actual data

                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        var message = "Dear Applicant, We tried to contact you for the Pre-Disbursement Physical Inspection of your unit. Kindly connect with us for completion of the Inspection.";
                        var smsUri = new Uri($"sms:{phoneNumber}?body={Uri.EscapeDataString(message)}");
                        await Launcher.OpenAsync(smsUri);
                    }
                    else
                    {
                        await DisplayAlert("Error", "Phone number not available", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to send SMS: {ex.Message}", "OK");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _httpClient?.Dispose();
        }

        private Task<bool> ShowSmsConfirmationModal()
        {
            var tcs = new TaskCompletionSource<bool>();

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
                Text = "💬",
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center
            };

            // Heading
            var headingLabel = new Label
            {
                Text = "Send SMS Notification",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#333333"),
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Message preview
            var messageFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F5F5F5"),
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 10,
                Padding = new Thickness(15),
                HasShadow = false
            };

            var messageLabel = new Label
            {
                Text = "Dear Applicant, We tried to contact you for the Pre-Disbursement Physical Inspection of your unit. Kindly connect with us for completion of the Inspection.",
                FontSize = 14,
                TextColor = Color.FromArgb("#333333"),
                LineBreakMode = LineBreakMode.WordWrap
            };

            messageFrame.Content = messageLabel;

            // Confirmation text
            var confirmLabel = new Label
            {
                Text = "Do you want to send this SMS?",
                FontSize = 14,
                TextColor = Color.FromArgb("#666666"),
                HorizontalTextAlignment = TextAlignment.Center
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
                tcs.TrySetResult(false);
            };

            var sendButton = new Button
            {
                Text = "SEND SMS",
                BackgroundColor = Color.FromArgb("#4CAF50"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45
            };
            sendButton.Clicked += (s, e) =>
            {
                RemoveModal(modal);
                tcs.TrySetResult(true);
            };

            Grid.SetColumn(cancelButton, 0);
            Grid.SetColumn(sendButton, 1);
            buttonGrid.Children.Add(cancelButton);
            buttonGrid.Children.Add(sendButton);

            contentStack.Children.Add(iconLabel);
            contentStack.Children.Add(headingLabel);
            contentStack.Children.Add(messageFrame);
            contentStack.Children.Add(confirmLabel);
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
            var searchText = e.NewTextValue ?? "";

            if (string.IsNullOrWhiteSpace(searchText))
            {
                DisplayApplicants(_allApplicants);
            }
            else
            {
                var filtered = _allApplicants.Where(a =>
                    a.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    a.Id.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                DisplayApplicants(filtered);
            }
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private double GetResponsiveFontSize(double baseSize) => baseSize * scaleFactor;
        private double GetResponsiveSpacing(double baseSpacing) => baseSpacing * scaleFactor;
        private Thickness GetResponsivePadding(double basePadding) => new Thickness(basePadding * scaleFactor);
        private Thickness GetResponsivePadding(double horizontal, double vertical) => new Thickness(horizontal * scaleFactor, vertical * scaleFactor);

    }
}