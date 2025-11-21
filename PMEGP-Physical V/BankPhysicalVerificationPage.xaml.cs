using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PMEGP_Physical_V
{
    // API Response Models
    public class BankPhysicalVerificationApiResponse
    {
        [JsonPropertyName("applicantData")]
        public BankPhysicalApplicantData ApplicantData { get; set; }

        [JsonPropertyName("bankProcess")]
        public BankPhysicalProcessData BankProcess { get; set; }

        [JsonPropertyName("phyVerificationModel")]
        public BankPhysicalVerificationData PhyVerificationModel { get; set; }

        [JsonPropertyName("phyVerificationDocs")]
        public List<BankPhysicalVerificationDoc> PhyVerificationDocs { get; set; }
    }

    public class BankPhysicalApplicantData
    {
        [JsonPropertyName("ApplID")]
        public int ApplID { get; set; }

        [JsonPropertyName("ApplCode")]
        public string ApplCode { get; set; }

        [JsonPropertyName("ApplName")]
        public string ApplName { get; set; }

        [JsonPropertyName("MobileNo1")]
        public string MobileNo1 { get; set; }

        [JsonPropertyName("UnitActivityName")]
        public string UnitActivityName { get; set; }

        [JsonPropertyName("UnitActivityName2")]
        public string UnitActivityName2 { get; set; }

        [JsonPropertyName("UnitActivityName3")]
        public string UnitActivityName3 { get; set; }

        [JsonPropertyName("UnitAddress")]
        public string UnitAddress { get; set; }

        [JsonPropertyName("UnitPin")]
        public string UnitPin { get; set; }
    }

    public class BankPhysicalProcessData
    {
        [JsonPropertyName("CapitalExpd")]
        public decimal? CapitalExpd { get; set; }

        [JsonPropertyName("WorkingCapital")]
        public decimal? WorkingCapital { get; set; }
    }

    public class BankPhysicalVerificationData
    {
        [JsonPropertyName("NewExistUnit")]
        public string NewExistUnit { get; set; }

        [JsonPropertyName("Latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("Longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("SiteAddress")]
        public string SiteAddress { get; set; }

        [JsonPropertyName("Pincode")]
        public string Pincode { get; set; }

        [JsonPropertyName("VerDate")]
        public string VerDate { get; set; }

        [JsonPropertyName("Premises")]
        public string Premises { get; set; }

        [JsonPropertyName("TypeOfIndustry")]
        public string TypeOfIndustry { get; set; }

        [JsonPropertyName("InfraReqPower")]
        public string InfraReqPower { get; set; }

        [JsonPropertyName("InfraReqSpace")]
        public string InfraReqSpace { get; set; }

        [JsonPropertyName("ObsOfPremises")]
        public string ObsOfPremises { get; set; }

        [JsonPropertyName("DOPPersonName")]
        public string DOPPersonName { get; set; }
    }

    public class BankPhysicalVerificationDoc
    {
        [JsonPropertyName("DocType")]
        public string DocType { get; set; }

        [JsonPropertyName("DocDescription")]
        public string DocDescription { get; set; }

        [JsonPropertyName("DocPath")]
        public string DocPath { get; set; }
    }

    public class DocumentUploadItem
    {
        public string DocType { get; set; }
        public string DocName { get; set; }
        public string FilePath { get; set; }
        public byte[] FileData { get; set; }
    }

    public partial class BankPhysicalVerificationPage : ContentPage
    {
        private int _currentStep = 1;
        private const int TotalSteps = 3;
        private List<ImageButton> _stepButtons = new List<ImageButton>();
        private List<BoxView> _connectorLines = new List<BoxView>();
        private AbsoluteLayout _currentModal = null;
        private int? _verificationStatus = null;

        private BankPhysicalVerificationApiResponse _apiData = null;
        private readonly HttpClient _httpClient;
        private readonly int _applId;
        private readonly string _badgeStatus;
        private bool _isEditable = false;
        private Dictionary<string, object> _formState = new Dictionary<string, object>();
        private List<DocumentUploadItem> _uploadedDocuments = new List<DocumentUploadItem>();

        private readonly Dictionary<int, StepInfo> _stepInfos = new Dictionary<int, StepInfo>
        {
            { 1, new StepInfo { Title = "Applicant Details", Icon = "user_details.png" } },
            { 2, new StepInfo { Title = "Document Upload", Icon = "upload.png" } },
            { 3, new StepInfo { Title = "Summary", Icon = "check.png" } }
        };

        public BankPhysicalVerificationPage(int applId, string badgeStatus = "Pending")
        {
            InitializeComponent();
            _applId = applId;
            _badgeStatus = badgeStatus?.Trim() ?? "Pending";
            _isEditable = !string.Equals(_badgeStatus, "Completed", StringComparison.OrdinalIgnoreCase);

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            InitializeStepNavigation();
            LoadApiDataAsync();
        }

        private async void LoadApiDataAsync()
        {
            try
            {
                var dataResponse = await _httpClient.GetStringAsync($"https://115.124.125.153/MobileApp/GetApplDataForPV?applID={_applId}");
                _apiData = JsonSerializer.Deserialize<BankPhysicalVerificationApiResponse>(dataResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                LoadStepContent(_currentStep);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            }
        }

        private void InitializeStepNavigation()
        {
            StepsContainer.Children.Clear();
            _stepButtons.Clear();
            _connectorLines.Clear();

            for (int i = 1; i <= TotalSteps; i++)
            {
                if (i > 1)
                {
                    var connectorLine = CreateConnectorLine();
                    StepsContainer.Children.Add(connectorLine);
                    _connectorLines.Add(connectorLine);
                }

                var (container, button) = CreateStepButton(i);
                StepsContainer.Children.Add(container);
                _stepButtons.Add(button);
            }

            var totalWidth = (TotalSteps * 45) + ((TotalSteps - 1) * 18);
            StepsContainer.MinimumWidthRequest = totalWidth;
            UpdateStepVisualStates();
        }

        private BoxView CreateConnectorLine()
        {
            return new BoxView
            {
                BackgroundColor = Color.FromArgb("#E0E0E0"),
                WidthRequest = 18,
                HeightRequest = 2,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(2, 0)
            };
        }

        private (View Container, ImageButton Button) CreateStepButton(int stepNumber)
        {
            var stepInfo = _stepInfos[stepNumber];

            var imageButton = new ImageButton
            {
                Source = stepInfo.Icon,
                WidthRequest = 18,
                HeightRequest = 18,
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#E0E0E0"),
                BorderWidth = 1.5,
                CornerRadius = 16,
                ClassId = stepNumber.ToString(),
                Padding = new Thickness(3, 1)
            };

            imageButton.Clicked += OnStepButtonClicked;

            var label = new Label
            {
                Text = stepInfo.Title,
                FontSize = 9,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromArgb("#666666"),
                HorizontalTextAlignment = TextAlignment.Center,
                MaxLines = 2,
                LineBreakMode = LineBreakMode.WordWrap
            };

            var container = new StackLayout
            {
                Spacing = 4,
                Padding = new Thickness(6, 3),
                MinimumWidthRequest = 45,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Children = { imageButton, label }
            };

            return (container, imageButton);
        }

        private void UpdateStepButtonAppearance(ImageButton button, int stepNumber)
        {
            var isCurrentStep = stepNumber == _currentStep;
            var isPastStep = stepNumber < _currentStep;

            if (isCurrentStep)
            {
                button.BackgroundColor = Color.FromArgb("#FF6B35");
                button.BorderColor = Color.FromArgb("#FF6B35");
                var container = button.Parent as StackLayout;
                var label = container?.Children.LastOrDefault() as Label;
                if (label != null)
                    label.TextColor = Color.FromArgb("#FF6B35");
            }
            else if (isPastStep)
            {
                button.BackgroundColor = Color.FromArgb("#4CAF50");
                button.BorderColor = Color.FromArgb("#4CAF50");
                var container = button.Parent as StackLayout;
                var label = container?.Children.LastOrDefault() as Label;
                if (label != null)
                    label.TextColor = Color.FromArgb("#4CAF50");
            }
            else
            {
                button.BackgroundColor = Colors.White;
                button.BorderColor = Color.FromArgb("#E0E0E0");
                var container = button.Parent as StackLayout;
                var label = container?.Children.LastOrDefault() as Label;
                if (label != null)
                    label.TextColor = Color.FromArgb("#666666");
            }

            UpdateConnectorLines();
        }

        private void UpdateConnectorLines()
        {
            for (int i = 0; i < _connectorLines.Count; i++)
            {
                var stepAfterConnector = i + 2;
                if (stepAfterConnector <= _currentStep)
                {
                    _connectorLines[i].BackgroundColor = Color.FromArgb("#4CAF50");
                }
                else
                {
                    _connectorLines[i].BackgroundColor = Color.FromArgb("#E0E0E0");
                }
            }
        }

        private void UpdateStepVisualStates()
        {
            for (int i = 0; i < _stepButtons.Count; i++)
            {
                UpdateStepButtonAppearance(_stepButtons[i], i + 1);
            }
        }

        private async void OnStepButtonClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button)
            {
                var stepNumber = int.Parse(button.ClassId);
                await NavigateToStep(stepNumber);
            }
        }

        private async Task NavigateToStep(int stepNumber)
        {
            if (stepNumber != _currentStep && stepNumber >= 1 && stepNumber <= TotalSteps)
            {
                SaveCurrentStepState();
                _currentStep = stepNumber;
                UpdateStepVisualStates();
                LoadStepContent(_currentStep);
                await Task.Delay(200);
                RestoreStepState();
                await ScrollToStep(stepNumber);
            }
        }

        private async Task ScrollToStep(int stepNumber)
        {
            var stepIndex = stepNumber - 1;
            var buttonWidth = 60;
            var connectorWidth = 30;
            var scrollX = stepIndex * (buttonWidth + connectorWidth) - 100;
            await StepScrollView.ScrollToAsync(Math.Max(0.0, (double)scrollX), 0, true);
        }

        private void SaveCurrentStepState()
        {
            try
            {
                foreach (var child in ContentContainer.Children)
                {
                    if (child is StackLayout stack)
                    {
                        SaveStackLayoutState(stack);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving state: {ex.Message}");
            }
        }

        private void SaveStackLayoutState(StackLayout stack)
        {
            foreach (var item in stack.Children)
            {
                try
                {
                    if (item is Grid grid)
                    {
                        var border = grid.Children.OfType<Border>().FirstOrDefault();
                        if (border?.Content is Grid contentGrid)
                        {
                            var vertStack = contentGrid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                            if (vertStack != null)
                            {
                                var label = vertStack.Children.OfType<Label>().FirstOrDefault();
                                var entry = vertStack.Children.OfType<Entry>().FirstOrDefault();
                                var editor = vertStack.Children.OfType<Editor>().FirstOrDefault();
                                var picker = vertStack.Children.OfType<Picker>().FirstOrDefault();

                                if (label != null)
                                {
                                    string key = NormalizeKey(label.Text);

                                    if (entry != null)
                                    {
                                        _formState[key] = entry.Text ?? "";
                                    }
                                    else if (editor != null)
                                    {
                                        _formState[key] = editor.Text ?? "";
                                    }
                                    else if (picker != null && picker.SelectedItem != null)
                                    {
                                        _formState[key] = picker.SelectedItem.ToString();
                                    }
                                }
                            }
                        }
                    }

                    if (item is StackLayout nestedStack && item != stack)
                    {
                        SaveStackLayoutState(nestedStack);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error processing item: {ex.Message}");
                }
            }
        }

        private void RestoreStepState()
        {
            try
            {
                if (_formState.Count == 0) return;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var child in ContentContainer.Children)
                    {
                        if (child is StackLayout stack)
                        {
                            RestoreStackLayoutState(stack);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error restoring state: {ex.Message}");
            }
        }

        private void RestoreStackLayoutState(StackLayout stack)
        {
            foreach (var item in stack.Children)
            {
                try
                {
                    if (item is Grid grid)
                    {
                        var border = grid.Children.OfType<Border>().FirstOrDefault();
                        if (border?.Content is Grid contentGrid)
                        {
                            var vertStack = contentGrid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                            if (vertStack != null)
                            {
                                var label = vertStack.Children.OfType<Label>().FirstOrDefault();
                                var entry = vertStack.Children.OfType<Entry>().FirstOrDefault();
                                var editor = vertStack.Children.OfType<Editor>().FirstOrDefault();
                                var picker = vertStack.Children.OfType<Picker>().FirstOrDefault();

                                if (label != null)
                                {
                                    string key = NormalizeKey(label.Text);

                                    if (_formState.ContainsKey(key))
                                    {
                                        var savedValue = _formState[key];

                                        if (entry != null && entry.IsEnabled)
                                        {
                                            entry.Text = savedValue?.ToString() ?? "";
                                        }
                                        else if (editor != null && editor.IsEnabled)
                                        {
                                            editor.Text = savedValue?.ToString() ?? "";
                                        }
                                        else if (picker != null && picker.IsEnabled)
                                        {
                                            string savedPickerValue = savedValue?.ToString();
                                            if (!string.IsNullOrEmpty(savedPickerValue) && picker.Items.Contains(savedPickerValue))
                                            {
                                                picker.SelectedItem = savedPickerValue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (item is StackLayout nestedStack && item != stack)
                    {
                        RestoreStackLayoutState(nestedStack);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error processing item during restore: {ex.Message}");
                }
            }
        }

        private string NormalizeKey(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace("*", "").Replace(" ", "").Replace(":", "").Replace("-", "").Replace("?", "").Trim();
        }

        private void LoadStepContent(int step)
        {
            ContentContainer.Children.Clear();

            switch (step)
            {
                case 1:
                    LoadApplicantDetailsContent();
                    break;
                case 2:
                    LoadDocumentUploadContent();
                    break;
                case 3:
                    LoadSummaryContent();
                    break;
            }
        }

        private void LoadApplicantDetailsContent()
        {
            var titleFrame = CreateSectionTitle("Applicant Details", "👤");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                // 1. Whether unit is a new/existing unit?
                form.Children.Add(CreateDropdownEntry("Whether unit is a new/existing unit?*",
                    _apiData.PhyVerificationModel?.NewExistUnit ?? "Please Select",
                    new[] { "Please Select", "New Unit", "Existing Unit" }, _isEditable));

                // 2. Applicant Name (Non-Editable)
                form.Children.Add(CreateFormEntry("Applicant Name*", _apiData.ApplicantData?.ApplName ?? "", false, false, false));

                // 3. Project Name (Can be Applicant Name)
                form.Children.Add(CreateFormEntry("Project Name*", _apiData.ApplicantData?.ApplName ?? "", false, false, _isEditable));

                // 4. GEO-LOCATION Button
                var getLocationButton = CreateActionButton("GET LOCATION", Color.FromArgb("#2196F3"), async () => await GetCurrentLocationAsync(), _isEditable);
                form.Children.Add(getLocationButton);

                // 5. Latitude (Non-Editable)
                form.Children.Add(CreateFormEntry("Latitude*", _apiData.PhyVerificationModel?.Latitude ?? "", false, false, false));

                // 6. Longitude (Non-Editable)
                form.Children.Add(CreateFormEntry("Longitude*", _apiData.PhyVerificationModel?.Longitude ?? "", false, false, false));

                // 7. Site Address
                form.Children.Add(CreateMultilineEntry("Site Address*", _apiData.PhyVerificationModel?.SiteAddress ?? _apiData.ApplicantData?.UnitAddress ?? "", false, _isEditable));

                // 8. Pin code
                form.Children.Add(CreateFormEntry("Pin code*", _apiData.PhyVerificationModel?.Pincode ?? _apiData.ApplicantData?.UnitPin ?? "", false, false, _isEditable));

                // 9. Date of Visit (Non-Editable)
                form.Children.Add(CreateFormEntry("Date of Visit*", DateTime.Now.ToString("dd-MM-yyyy"), false, false, false));

                // 10. Premises
                form.Children.Add(CreateDropdownEntry("Premises*",
                    _apiData.PhyVerificationModel?.Premises ?? "Please Select",
                    new[] { "Please Select", "Owned", "Rented", "Leased" }, _isEditable));

                // 11. Contact Number (Non-Editable)
                form.Children.Add(CreateFormEntry("Contact Number*", _apiData.ApplicantData?.MobileNo1 ?? "", false, false, false));

                // 12. Type of Industry
                form.Children.Add(CreateDropdownEntry("Type of Industry*",
                    _apiData.PhyVerificationModel?.TypeOfIndustry ?? "Please Select",
                    new[] { "Please Select", "Trading", "Manufacturing", "Services" }, _isEditable));

                // 13. Activity Name (Multiline Entry & Non-Editable)
                var activityNames = new List<string>();
                if (!string.IsNullOrEmpty(_apiData.ApplicantData?.UnitActivityName))
                    activityNames.Add(_apiData.ApplicantData.UnitActivityName);
                if (!string.IsNullOrEmpty(_apiData.ApplicantData?.UnitActivityName2))
                    activityNames.Add(_apiData.ApplicantData.UnitActivityName2);
                if (!string.IsNullOrEmpty(_apiData.ApplicantData?.UnitActivityName3))
                    activityNames.Add(_apiData.ApplicantData.UnitActivityName3);

                form.Children.Add(CreateMultilineEntry("Activity Name*", string.Join(", ", activityNames), false, false));

                // 14. Capital Expenditure (Non-Editable)
                form.Children.Add(CreateFormEntry("Capital Expenditure*", _apiData.BankProcess?.CapitalExpd?.ToString("F2") ?? "0.00", false, false, false));

                // 15. Working Capital (Non-Editable)
                form.Children.Add(CreateFormEntry("Working Capital*", _apiData.BankProcess?.WorkingCapital?.ToString("F2") ?? "0.00", false, false, false));

                // 16. Infrastructure Requirements - Power
                form.Children.Add(CreateMultilineEntry("Infrastructure Requirements - Power*", _apiData.PhyVerificationModel?.InfraReqPower ?? "", false, _isEditable));

                // 17. Infrastructure Requirements - Space
                form.Children.Add(CreateMultilineEntry("Infrastructure Requirements - Space*", _apiData.PhyVerificationModel?.InfraReqSpace ?? "", false, _isEditable));

                // 18. Observation of premises
                form.Children.Add(CreateMultilineEntry("Observation of premises*", _apiData.PhyVerificationModel?.ObsOfPremises ?? "", false, _isEditable));

                // 19. DOP Person Name
                // 19. Verification Status
                form.Children.Add(CreateVerificationStatusRadioButtons());
            }

            string nextButtonText = _isEditable ? "SAVE & NEXT" : "NEXT";
            var buttonColor = _isEditable && !_verificationStatus.HasValue
                ? Color.FromArgb("#CCCCCC")
                : Color.FromArgb("#4CAF50");

            var nextButton = CreateNavigationButton(nextButtonText, buttonColor, async () =>
            {
                if (_isEditable) await SaveApplicantDetailsData();
                await NavigateToStep(2);
            });

            if (_isEditable && !_verificationStatus.HasValue)
            {
                nextButton.IsEnabled = false;
                nextButton.Opacity = 0.6;
            }

            form.Children.Add(nextButton);

            ContentContainer.Children.Add(form);
        }

        private async Task GetCurrentLocationAsync()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permission Denied", "Location permission is required", "OK");
                    return;
                }

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(10)
                });

                if (location != null)
                {
                    UpdateLocationFields(location.Latitude, location.Longitude);
                    await DisplayAlert("Success", "Location captured successfully", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
            }
        }

        private void UpdateLocationFields(double latitude, double longitude)
        {
            if (_apiData?.PhyVerificationModel != null)
            {
                _apiData.PhyVerificationModel.Latitude = latitude.ToString("F6");
                _apiData.PhyVerificationModel.Longitude = longitude.ToString("F6");
            }

            _formState["Latitude"] = latitude.ToString("F6");
            _formState["Longitude"] = longitude.ToString("F6");

            LoadStepContent(1);
        }

        private void LoadDocumentUploadContent()
        {
            var titleFrame = CreateSectionTitleWithButton("Document Uploading", "📍", _isEditable);
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            var tableFrame = CreateDocumentTable();
            form.Children.Add(tableFrame);

            string nextButtonText = _isEditable ? "SAVE & NEXT" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(1),
                async () =>
                {
                    await NavigateToStep(3);
                },
                "PREVIOUS",
                nextButtonText
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private Grid CreateVerificationStatusRadioButtons()
        {
            var grid = new Grid
            {
                Margin = new Thickness(0, 12, 0, 0)
            };

            var primaryColor = Color.FromArgb("#1976D2");
            var surfaceColor = _isEditable ? Colors.White : Color.FromArgb("#F5F5F5");
            var outlineColor = _isEditable ? Color.FromArgb("#1976D2") : Color.FromArgb("#BDBDBD");

            var container = new Border
            {
                BackgroundColor = surfaceColor,
                Stroke = outlineColor,
                StrokeThickness = 1.5,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(16, 12, 16, 12),
                MinimumHeightRequest = 80,
                Shadow = _isEditable ? new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#40000000")),
                    Opacity = 0.15f,
                    Radius = 4,
                    Offset = new Point(0, 2)
                } : null
            };

            var mainStack = new VerticalStackLayout
            {
                Spacing = 12
            };

            var label = new Label
            {
                Text = "Verification Status*",
                FontSize = 12,
                TextColor = _isEditable ? primaryColor : Color.FromArgb("#9E9E9E"),
                FontAttributes = FontAttributes.Bold
            };

            var radioStack = new HorizontalStackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.Start
            };

            // Successful Radio Button
            var successfulFrame = new Frame
            {
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(5),
                HasShadow = false,
                IsEnabled = _isEditable
            };

            var successfulStack = new HorizontalStackLayout
            {
                Spacing = 10
            };

            var successfulRadio = new RadioButton
            {
                GroupName = "VerificationStatus",
                Value = "1",
                IsEnabled = _isEditable,
                WidthRequest = 24,
                HeightRequest = 24
            };

            // Apply custom styling for Successful Radio Button
            if (_isEditable)
            {
                successfulRadio.ControlTemplate = new ControlTemplate(() =>
                {
                    var outerBorder = new Border
                    {
                        Stroke = Color.FromArgb("#424242"),
                        StrokeThickness = 2,
                        StrokeShape = new RoundRectangle { CornerRadius = 12 },
                        BackgroundColor = Colors.Transparent,
                        WidthRequest = 24,
                        HeightRequest = 24,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    var innerCircle = new BoxView
                    {
                        Color = Color.FromArgb("#1976D2"),
                        WidthRequest = 12,
                        HeightRequest = 12,
                        CornerRadius = 6,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        IsVisible = false
                    };

                    innerCircle.SetBinding(BoxView.IsVisibleProperty, new Binding("IsChecked", source: RelativeBindingSource.TemplatedParent));

                    var grid = new Grid();
                    grid.Children.Add(outerBorder);
                    grid.Children.Add(innerCircle);

                    return grid;
                });
            }

            var successfulLabel = new Label
            {
                Text = "Successful",
                FontSize = 12,
                TextColor = _isEditable ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E"),
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold
            };

            // Make the entire frame tappable for Successful
            var successfulTapGesture = new TapGestureRecognizer();
            successfulTapGesture.Tapped += (s, e) =>
            {
                if (_isEditable)
                {
                    successfulRadio.IsChecked = true;
                }
            };
            successfulFrame.GestureRecognizers.Add(successfulTapGesture);

            successfulStack.Children.Add(successfulRadio);
            successfulStack.Children.Add(successfulLabel);
            successfulFrame.Content = successfulStack;

            // Unsuccessful Radio Button
            var unsuccessfulFrame = new Frame
            {
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.Transparent,
                Padding = new Thickness(5),
                HasShadow = false,
                IsEnabled = _isEditable
            };

            var unsuccessfulStack = new HorizontalStackLayout
            {
                Spacing = 10
            };

            var unsuccessfulRadio = new RadioButton
            {
                GroupName = "VerificationStatus",
                Value = "0",
                IsEnabled = _isEditable,
                WidthRequest = 24,
                HeightRequest = 24
            };

            // Apply custom styling for Unsuccessful Radio Button
            if (_isEditable)
            {
                unsuccessfulRadio.ControlTemplate = new ControlTemplate(() =>
                {
                    var outerBorder = new Border
                    {
                        Stroke = Color.FromArgb("#424242"),
                        StrokeThickness = 2,
                        StrokeShape = new RoundRectangle { CornerRadius = 12 },
                        BackgroundColor = Colors.Transparent,
                        WidthRequest = 24,
                        HeightRequest = 24,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    var innerCircle = new BoxView
                    {
                        Color = Color.FromArgb("#1976D2"),
                        WidthRequest = 12,
                        HeightRequest = 12,
                        CornerRadius = 6,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        IsVisible = false
                    };

                    innerCircle.SetBinding(BoxView.IsVisibleProperty, new Binding("IsChecked", source: RelativeBindingSource.TemplatedParent));

                    var grid = new Grid();
                    grid.Children.Add(outerBorder);
                    grid.Children.Add(innerCircle);

                    return grid;
                });
            }

            var unsuccessfulLabel = new Label
            {
                Text = "Un-Successful",
                FontSize = 12,
                TextColor = _isEditable ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E"),
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold
            };

            // Make the entire frame tappable for Unsuccessful
            var unsuccessfulTapGesture = new TapGestureRecognizer();
            unsuccessfulTapGesture.Tapped += (s, e) =>
            {
                if (_isEditable)
                {
                    unsuccessfulRadio.IsChecked = true;
                }
            };
            unsuccessfulFrame.GestureRecognizers.Add(unsuccessfulTapGesture);

            unsuccessfulStack.Children.Add(unsuccessfulRadio);
            unsuccessfulStack.Children.Add(unsuccessfulLabel);
            unsuccessfulFrame.Content = unsuccessfulStack;

            // Event Handlers
            successfulRadio.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                {
                    _verificationStatus = 1;
                    _formState["VerificationStatus"] = 1;
                    UpdateSaveButtonState();
                }
            };

            unsuccessfulRadio.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                {
                    _verificationStatus = 0;
                    _formState["VerificationStatus"] = 0;
                    UpdateSaveButtonState();
                }
            };

            radioStack.Children.Add(successfulFrame);
            radioStack.Children.Add(unsuccessfulFrame);

            mainStack.Children.Add(label);
            mainStack.Children.Add(radioStack);

            container.Content = mainStack;
            grid.Children.Add(container);

            return grid;
        }
        private void UpdateSaveButtonState()
        {
            // Find the SAVE & NEXT button in ContentContainer and update its state
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    foreach (var item in stack.Children)
                    {
                        if (item is Button button && button.Text == "SAVE & NEXT")
                        {
                            button.IsEnabled = _verificationStatus.HasValue;
                            button.BackgroundColor = _verificationStatus.HasValue
                                ? Color.FromArgb("#4CAF50")
                                : Color.FromArgb("#CCCCCC");
                            button.Opacity = _verificationStatus.HasValue ? 1.0 : 0.6;
                        }
                    }
                }
            }
        }

        private Frame CreateSectionTitleWithButton(string title, string icon, bool showButton)
        {
            var titleFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F0F8F0"),
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 12,
                Padding = new Thickness(20, 15),
                Margin = new Thickness(0, 0, 0, 20),
                HasShadow = false
            };

            var titleGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };

            var titleStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center
            };

            var iconLabel = new Label
            {
                Text = icon,
                FontSize = 20,
                VerticalOptions = LayoutOptions.Center
            };

            var titleLabel = new Label
            {
                Text = title,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#2E7D32"),
                VerticalOptions = LayoutOptions.Center
            };

            titleStack.Children.Add(iconLabel);
            titleStack.Children.Add(titleLabel);

            Grid.SetColumn(titleStack, 0);
            titleGrid.Children.Add(titleStack);

            if (showButton)
            {
                var uploadButton = new Frame
                {
                    BackgroundColor = Color.FromArgb("#FF6B35"),
                    CornerRadius = 20,
                    WidthRequest = 40,
                    HeightRequest = 40,
                    Padding = 0,
                    HasShadow = true,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End
                };

                var uploadIcon = new Image
                {
                    Source = "upload.png",
                    WidthRequest = 24,
                    HeightRequest = 24,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                uploadButton.Content = uploadIcon;

                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += OnOpenDocumentUploadModal;
                uploadButton.GestureRecognizers.Add(tapGesture);

                Grid.SetColumn(uploadButton, 1);
                titleGrid.Children.Add(uploadButton);
            }

            titleFrame.Content = titleGrid;
            return titleFrame;
        }

        private async void OnOpenDocumentUploadModal(object sender, EventArgs e)
        {
            CloseCurrentModal();

            var modal = CreateDocumentUploadModal();
            _currentModal = modal;

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(modal, 3);
                Grid.SetRow(modal, 0);
                rootGrid.Children.Add(modal);
            }
        }

        private AbsoluteLayout CreateDocumentUploadModal()
        {
            var modalOverlay = new AbsoluteLayout
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
                Padding = new Thickness(20),
                WidthRequest = 340,
                HeightRequest = 480,
                HasShadow = true
            };

            var contentStack = new StackLayout { Spacing = 20 };

            var headerLabel = new Label
            {
                Text = "Document Upload Form",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#333333"),
                HorizontalTextAlignment = TextAlignment.Center
            };

            var docTypePicker = new Picker
            {
                Title = "Document Type*",
                FontSize = 16,
                BackgroundColor = Colors.White,
                HeightRequest = 50
            };
            docTypePicker.Items.Add("Photo of Land with Applicant");
            docTypePicker.Items.Add("Photo of Land Documents");
            docTypePicker.Items.Add("Others");

            var docNameEntry = new Entry
            {
                Placeholder = "Document Name*",
                FontSize = 16,
                BackgroundColor = Colors.White,
                HeightRequest = 50
            };

            var filePickerFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F5F5F5"),
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 8,
                Padding = new Thickness(10),
                HeightRequest = 50
            };

            var filePickerGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Star }
                }
            };

            var chooseFileButton = new Button
            {
                Text = "Choose File",
                BackgroundColor = Color.FromArgb("#2196F3"),
                TextColor = Colors.White,
                FontSize = 12,
                CornerRadius = 6,
                HeightRequest = 35,
                WidthRequest = 100,
                Padding = new Thickness(5, 0)
            };

            var fileNameLabel = new Label
            {
                Text = "No file chosen",
                FontSize = 14,
                TextColor = Color.FromArgb("#666666"),
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            chooseFileButton.Clicked += async (s, e) =>
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select Document",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    fileNameLabel.Text = result.FileName;
                    fileNameLabel.ClassId = result.FullPath;
                }
            };

            Grid.SetColumn(chooseFileButton, 0);
            Grid.SetColumn(fileNameLabel, 1);
            filePickerGrid.Children.Add(chooseFileButton);
            filePickerGrid.Children.Add(fileNameLabel);
            filePickerFrame.Content = filePickerGrid;

            var uploadButton = new Button
            {
                Text = "DOCUMENT UPLOAD",
                BackgroundColor = Color.FromArgb("#4CAF50"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45,
                FontSize = 16
            };

            uploadButton.Clicked += async (s, e) =>
            {
                if (docTypePicker.SelectedIndex < 0)
                {
                    await DisplayAlert("Validation", "Please select document type", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(docNameEntry.Text))
                {
                    await DisplayAlert("Validation", "Please enter document name", "OK");
                    return;
                }

                if (fileNameLabel.Text == "No file chosen")
                {
                    await DisplayAlert("Validation", "Please choose a file", "OK");
                    return;
                }

                try
                {
                    var filePath = fileNameLabel.ClassId;
                    byte[] fileBytes;

                    using (var stream = File.OpenRead(filePath))
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }

                    var uploadItem = new DocumentUploadItem
                    {
                        DocType = docTypePicker.SelectedItem.ToString(),
                        DocName = docNameEntry.Text,
                        FilePath = filePath,
                        FileData = fileBytes
                    };

                    _uploadedDocuments.Add(uploadItem);
                    await DisplayAlert("Success", "Document uploaded successfully", "OK");
                    CloseCurrentModal();
                    LoadStepContent(2);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Failed to upload document: {ex.Message}", "OK");
                }
            };

            var closeButton = new Button
            {
                Text = "CANCEL",
                BackgroundColor = Color.FromArgb("#6C757D"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45,
                FontSize = 16
            };
            closeButton.Clicked += OnCloseModalClicked;

            contentStack.Children.Add(headerLabel);
            contentStack.Children.Add(docTypePicker);
            contentStack.Children.Add(docNameEntry);
            contentStack.Children.Add(filePickerFrame);
            contentStack.Children.Add(uploadButton);
            contentStack.Children.Add(closeButton);

            contentFrame.Content = contentStack;

            AbsoluteLayout.SetLayoutBounds(contentFrame, new Rect(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(contentFrame, AbsoluteLayoutFlags.PositionProportional);

            modalOverlay.Children.Add(contentFrame);

            return modalOverlay;
        }

        private Frame CreateDocumentTable()
        {
            var tableFrame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 12,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 15),
                HasShadow = false
            };

            var mainLayout = new StackLayout { Spacing = 0 };

            var headerGrid = new Grid
            {
                BackgroundColor = Color.FromArgb("#FF6B35"),
                Padding = new Thickness(15, 12),
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1.2, GridUnitType.Star) }
                }
            };

            var docTypeHeader = new Label
            {
                Text = "Document Type",
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var docNameHeader = new Label
            {
                Text = "Document Name",
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var docActionHeader = new Label
            {
                Text = "Actions",
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Grid.SetColumn(docTypeHeader, 0);
            Grid.SetColumn(docNameHeader, 1);
            Grid.SetColumn(docActionHeader, 2);

            headerGrid.Children.Add(docTypeHeader);
            headerGrid.Children.Add(docNameHeader);
            headerGrid.Children.Add(docActionHeader);

            mainLayout.Children.Add(headerGrid);

            var allDocuments = new List<object>();

            if (_apiData?.PhyVerificationDocs != null)
            {
                allDocuments.AddRange(_apiData.PhyVerificationDocs);
            }

            if (_isEditable && _uploadedDocuments != null)
            {
                allDocuments.AddRange(_uploadedDocuments);
            }

            for (int i = 0; i < allDocuments.Count; i++)
            {
                var doc = allDocuments[i];

                string docType, docName;
                bool isUploadedDoc = doc is DocumentUploadItem;

                if (isUploadedDoc)
                {
                    var uploadDoc = doc as DocumentUploadItem;
                    docType = uploadDoc.DocType;
                    docName = uploadDoc.DocName;
                }
                else
                {
                    var apiDoc = doc as BankPhysicalVerificationDoc;
                    docType = apiDoc.DocType ?? "Document";
                    docName = apiDoc.DocDescription ?? "Document";
                }

                var rowGrid = new Grid
                {
                    BackgroundColor = i % 2 == 0 ? Color.FromArgb("#F9F9F9") : Colors.White,
                    Padding = new Thickness(15, 15),
                    ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1.2, GridUnitType.Star) }
                    }
                };

                var docTypeLabel = new Label
                {
                    Text = docType,
                    TextColor = Color.FromArgb("#333333"),
                    FontSize = 14,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };

                var docNameLabel = new Label
                {
                    Text = docName,
                    TextColor = Color.FromArgb("#333333"),
                    FontSize = 14,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };

                var actionStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 8,
                    HorizontalOptions = LayoutOptions.Center
                };

                var viewButton = new Button
                {
                    Text = "View",
                    BackgroundColor = Color.FromArgb("#4CAF50"),
                    TextColor = Colors.White,
                    FontAttributes = FontAttributes.Bold,
                    CornerRadius = 8,
                    HeightRequest = 35,
                    WidthRequest = 60,
                    FontSize = 12,
                    ClassId = i.ToString()
                };
                viewButton.Clicked += OnViewDocumentClicked;

                actionStack.Children.Add(viewButton);

                if (_isEditable && isUploadedDoc)
                {
                    var deleteButton = new ImageButton
                    {
                        Source = "delete.png",
                        BackgroundColor = Color.FromArgb("#FFFFFF"),
                        CornerRadius = 8,
                        HeightRequest = 35,
                        WidthRequest = 35,
                        Padding = new Thickness(8),
                        ClassId = i.ToString()
                    };
                    deleteButton.Clicked += async (s, e) =>
                    {
                        bool confirm = await DisplayAlert("Confirm", "Delete this document?", "Yes", "No");
                        if (confirm)
                        {
                            _uploadedDocuments.RemoveAt(int.Parse(deleteButton.ClassId));
                            LoadStepContent(2);
                        }
                    };
                    actionStack.Children.Add(deleteButton);
                }

                Grid.SetColumn(docTypeLabel, 0);
                Grid.SetColumn(docNameLabel, 1);
                Grid.SetColumn(actionStack, 2);

                rowGrid.Children.Add(docTypeLabel);
                rowGrid.Children.Add(docNameLabel);
                rowGrid.Children.Add(actionStack);

                mainLayout.Children.Add(rowGrid);
            }

            tableFrame.Content = mainLayout;
            return tableFrame;
        }

        private async void OnViewDocumentClicked(object sender, EventArgs e)
        {
            await DisplayAlert("View Document", "Document preview feature coming soon", "OK");
        }

        private void LoadSummaryContent()
        {
            var titleFrame = CreateSectionTitle("Summary", "🏆");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            var completionMessage = new Frame
            {
                BackgroundColor = Color.FromArgb("#E8F5E8"),
                BorderColor = Color.FromArgb("#4CAF50"),
                CornerRadius = 10,
                Padding = new Thickness(20),
                Margin = new Thickness(0, 20)
            };

            var messageLabel = new Label
            {
                Text = "Review all the information before final submission.",
                FontSize = 16,
                TextColor = Color.FromArgb("#2E7D32"),
                HorizontalTextAlignment = TextAlignment.Center,
                LineHeight = 1.4
            };

            completionMessage.Content = messageLabel;
            form.Children.Add(completionMessage);

            form.Children.Add(CreateCollapsibleSection("Applicant Details", "👤", CreateApplicantDetailsSummary()));

            var finalSubmitButton = CreateNavigationButton("FINAL SUBMIT", Color.FromArgb("#FF6B35"), async () => await FinalSubmit());
            form.Children.Add(finalSubmitButton);

            var previousButton = CreateNavigationButton("PREVIOUS", Color.FromArgb("#6C757D"), async () => await NavigateToStep(2));
            form.Children.Add(previousButton);

            ContentContainer.Children.Add(form);
        }

        private StackLayout CreateApplicantDetailsSummary()
        {
            var summary = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Whether unit is a new/existing unit?*",
                    _formState.ContainsKey("Whetherunitisanew/existingunit") ? _formState["Whetherunitisanew/existingunit"].ToString() :
                    _apiData.PhyVerificationModel?.NewExistUnit ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Applicant Name*", _apiData.ApplicantData?.ApplName ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Project Name*",
                    _formState.ContainsKey("ProjectName") ? _formState["ProjectName"].ToString() :
                    _apiData.ApplicantData?.ApplName ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Latitude*",
                    _formState.ContainsKey("Latitude") ? _formState["Latitude"].ToString() :
                    _apiData.PhyVerificationModel?.Latitude ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Longitude*",
                    _formState.ContainsKey("Longitude") ? _formState["Longitude"].ToString() :
                    _apiData.PhyVerificationModel?.Longitude ?? "", false, false, false, true));

                summary.Children.Add(CreateMultilineEntry("Site Address*",
                    _formState.ContainsKey("SiteAddress") ? _formState["SiteAddress"].ToString() :
                    _apiData.PhyVerificationModel?.SiteAddress ?? "", false, false, true));

                summary.Children.Add(CreateFormEntry("Pin code*",
                    _formState.ContainsKey("Pincode") ? _formState["Pincode"].ToString() :
                    _apiData.PhyVerificationModel?.Pincode ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Date of Visit*", DateTime.Now.ToString("dd-MM-yyyy"), false, false, false, true));

                summary.Children.Add(CreateFormEntry("Premises*",
                    _formState.ContainsKey("Premises") ? _formState["Premises"].ToString() :
                    _apiData.PhyVerificationModel?.Premises ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Contact Number*", _apiData.ApplicantData?.MobileNo1 ?? "", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Type of Industry*",
                    _formState.ContainsKey("TypeofIndustry") ? _formState["TypeofIndustry"].ToString() :
                    _apiData.PhyVerificationModel?.TypeOfIndustry ?? "", false, false, false, true));

                var activityNames = new List<string>();
                if (!string.IsNullOrEmpty(_apiData.ApplicantData?.UnitActivityName))
                    activityNames.Add(_apiData.ApplicantData.UnitActivityName);
                if (!string.IsNullOrEmpty(_apiData.ApplicantData?.UnitActivityName2))
                    activityNames.Add(_apiData.ApplicantData.UnitActivityName2);
                if (!string.IsNullOrEmpty(_apiData.ApplicantData?.UnitActivityName3))
                    activityNames.Add(_apiData.ApplicantData.UnitActivityName3);

                summary.Children.Add(CreateMultilineEntry("Activity Name*", string.Join(", ", activityNames), false, false, true));

                summary.Children.Add(CreateFormEntry("Capital Expenditure*", _apiData.BankProcess?.CapitalExpd?.ToString("F2") ?? "0.00", false, false, false, true));

                summary.Children.Add(CreateFormEntry("Working Capital*", _apiData.BankProcess?.WorkingCapital?.ToString("F2") ?? "0.00", false, false, false, true));

                summary.Children.Add(CreateMultilineEntry("Infrastructure Requirements - Power*",
                    _formState.ContainsKey("InfrastructureRequirements-Power") ? _formState["InfrastructureRequirements-Power"].ToString() :
                    _apiData.PhyVerificationModel?.InfraReqPower ?? "", false, false, true));

                summary.Children.Add(CreateMultilineEntry("Infrastructure Requirements - Space*",
                    _formState.ContainsKey("InfrastructureRequirements-Space") ? _formState["InfrastructureRequirements-Space"].ToString() :
                    _apiData.PhyVerificationModel?.InfraReqSpace ?? "", false, false, true));

                summary.Children.Add(CreateMultilineEntry("Observation of premises*",
                    _formState.ContainsKey("Observationofpremises") ? _formState["Observationofpremises"].ToString() :
                    _apiData.PhyVerificationModel?.ObsOfPremises ?? "", false, false, true));

                // Verification Status
                string verificationStatusText = "Not Selected";
                if (_formState.ContainsKey("VerificationStatus"))
                {
                    var status = _formState["VerificationStatus"];
                    verificationStatusText = status?.ToString() == "1" ? "Successful" :
                                            status?.ToString() == "0" ? "Un-Successful" : "Not Selected";
                }
                summary.Children.Add(CreateFormEntry("Verification Status*", verificationStatusText, false, false, false, true));
            }

            return summary;
        }

        private Frame _currentlyOpenSection = null;

        private Frame CreateCollapsibleSection(string title, string icon, StackLayout content)
        {
            var sectionFrame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 12,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 8),
                HasShadow = false
            };

            var mainLayout = new StackLayout { Spacing = 0 };

            var headerFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F0F8F0"),
                BorderColor = Colors.Transparent,
                CornerRadius = 12,
                Padding = new Thickness(20, 15),
                Margin = new Thickness(0),
                HasShadow = false
            };

            var headerStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center
            };

            var iconLabel = new Label
            {
                Text = icon,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center
            };

            var titleLabel = new Label
            {
                Text = title,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#2E7D32"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var chevronLabel = new Label
            {
                Text = "▼",
                FontSize = 14,
                TextColor = Color.FromArgb("#666666"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                ClassId = "chevron"
            };

            headerStack.Children.Add(iconLabel);
            headerStack.Children.Add(titleLabel);
            headerStack.Children.Add(chevronLabel);

            headerFrame.Content = headerStack;

            var contentFrame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Colors.Transparent,
                CornerRadius = 0,
                Padding = new Thickness(20),
                Margin = new Thickness(0),
                HasShadow = false,
                IsVisible = false,
                Content = content
            };

            mainLayout.Children.Add(headerFrame);
            mainLayout.Children.Add(contentFrame);

            sectionFrame.Content = mainLayout;

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (sender, e) =>
            {
                if (_currentlyOpenSection != null && _currentlyOpenSection != sectionFrame)
                {
                    var currentContent = ((StackLayout)_currentlyOpenSection.Content).Children[1] as Frame;
                    var currentChevron = FindChevronInFrame(_currentlyOpenSection);
                    if (currentContent != null && currentChevron != null)
                    {
                        currentContent.IsVisible = false;
                        currentChevron.Text = "▼";
                    }
                }

                var isCurrentlyOpen = contentFrame.IsVisible;
                contentFrame.IsVisible = !isCurrentlyOpen;
                chevronLabel.Text = contentFrame.IsVisible ? "▲" : "▼";

                _currentlyOpenSection = contentFrame.IsVisible ? sectionFrame : null;
            };

            headerFrame.GestureRecognizers.Add(tapGesture);

            return sectionFrame;
        }

        private Label FindChevronInFrame(Frame frame)
        {
            if (frame.Content is StackLayout mainStack && mainStack.Children.Count > 0)
            {
                if (mainStack.Children[0] is Frame headerFrame &&
                    headerFrame.Content is StackLayout headerStack)
                {
                    return headerStack.Children.FirstOrDefault(c => c is Label l && l.ClassId == "chevron") as Label;
                }
            }
            return null;
        }

        private async Task SaveApplicantDetailsData()
        {
            try
            {
                var payload = new
                {
                    ApplID = _applId,
                    NewExistUnit = FindPickerValue("Whetherunitisanew/existingunit"),
                    ProjectName = FindEntryValue("ProjectName"),
                    Latitude = FindEntryValue("Latitude"),
                    Longitude = FindEntryValue("Longitude"),
                    SiteAddress = FindEditorValue("SiteAddress"),
                    Pincode = FindEntryValue("Pincode"),
                    VerDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    Premises = FindPickerValue("Premises"),
                    TypeOfIndustry = FindPickerValue("TypeofIndustry"),
                    InfraReqPower = FindEditorValue("InfrastructureRequirements-Power"),
                    InfraReqSpace = FindEditorValue("InfrastructureRequirements-Space"),
                    ObsOfPremises = FindEditorValue("Observationofpremises"),
                    VerificationStatus = _verificationStatus
                };

                await CallSaveApi("https://115.124.125.153/MobileApp/Insert_BankPVData", payload);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save: {ex.Message}", "OK");
            }
        }

        private async Task FinalSubmit()
        {
            try
            {
                bool confirm = await DisplayAlert(
                    "Confirm Submission",
                    "Are you sure you want to submit? This action cannot be undone.",
                    "Yes, Submit",
                    "Cancel"
                );

                if (!confirm) return;

                await SaveApplicantDetailsData();
                await DisplayAlert("Success", "Verification completed successfully!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Final submission failed: {ex.Message}", "OK");
            }
        }

        private async Task CallSaveApi(string url, object payload)
        {
            try
            {
                var jsonPayload = JsonSerializer.Serialize(payload);
                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Save failed: {ex.Message}");
            }
        }

        private string FindEntryValue(string placeholder)
        {
            var normalizedPlaceholder = NormalizeKey(placeholder);

            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var result = FindEntryInStack(stack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            if (_formState.ContainsKey(normalizedPlaceholder))
            {
                return _formState[normalizedPlaceholder]?.ToString() ?? "";
            }

            return "";
        }

        private string FindEntryInStack(StackLayout stack, string normalizedPlaceholder)
        {
            foreach (var item in stack.Children)
            {
                if (item is Grid grid)
                {
                    var border = grid.Children.OfType<Border>().FirstOrDefault();
                    if (border?.Content is Grid contentGrid)
                    {
                        var vertStack = contentGrid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                        if (vertStack != null)
                        {
                            var label = vertStack.Children.OfType<Label>().FirstOrDefault();
                            var entry = vertStack.Children.OfType<Entry>().FirstOrDefault();

                            if (label != null && entry != null)
                            {
                                var normalizedLabel = NormalizeKey(label.Text);
                                if (normalizedLabel == normalizedPlaceholder)
                                {
                                    return entry.Text ?? "";
                                }
                            }
                        }
                    }
                }

                if (item is StackLayout nestedStack)
                {
                    var result = FindEntryInStack(nestedStack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            return "";
        }

        private string FindEditorValue(string placeholder)
        {
            var normalizedPlaceholder = NormalizeKey(placeholder);

            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var result = FindEditorInStack(stack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            if (_formState.ContainsKey(normalizedPlaceholder))
            {
                return _formState[normalizedPlaceholder]?.ToString() ?? "";
            }

            return "";
        }

        private string FindEditorInStack(StackLayout stack, string normalizedPlaceholder)
        {
            foreach (var item in stack.Children)
            {
                if (item is Grid grid)
                {
                    var border = grid.Children.OfType<Border>().FirstOrDefault();

                    if (border?.Content is VerticalStackLayout vertStack)
                    {
                        var label = vertStack.Children.OfType<Label>().FirstOrDefault();
                        var editor = vertStack.Children.OfType<Editor>().FirstOrDefault();

                        if (label != null && editor != null)
                        {
                            var normalizedLabel = NormalizeKey(label.Text);
                            if (normalizedLabel == normalizedPlaceholder)
                            {
                                return editor.Text ?? "";
                            }
                        }
                    }

                    if (border?.Content is Grid contentGrid)
                    {
                        var verticalStack = contentGrid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                        if (verticalStack != null)
                        {
                            var label = verticalStack.Children.OfType<Label>().FirstOrDefault();
                            var editor = verticalStack.Children.OfType<Editor>().FirstOrDefault();

                            if (label != null && editor != null)
                            {
                                var normalizedLabel = NormalizeKey(label.Text);
                                if (normalizedLabel == normalizedPlaceholder)
                                {
                                    return editor.Text ?? "";
                                }
                            }
                        }
                    }
                }

                if (item is StackLayout nestedStack)
                {
                    var result = FindEditorInStack(nestedStack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            return "";
        }

        private string FindPickerValue(string placeholder)
        {
            var normalizedPlaceholder = NormalizeKey(placeholder);

            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var result = FindPickerInStack(stack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            if (_formState.ContainsKey(normalizedPlaceholder))
            {
                return _formState[normalizedPlaceholder]?.ToString() ?? "";
            }

            return "";
        }

        private string FindPickerInStack(StackLayout stack, string normalizedPlaceholder)
        {
            foreach (var item in stack.Children)
            {
                if (item is Grid grid)
                {
                    var border = grid.Children.OfType<Border>().FirstOrDefault();
                    if (border?.Content is Grid contentGrid)
                    {
                        var vertStack = contentGrid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                        if (vertStack != null)
                        {
                            var label = vertStack.Children.OfType<Label>().FirstOrDefault();
                            var picker = vertStack.Children.OfType<Picker>().FirstOrDefault();

                            if (label != null && picker != null)
                            {
                                var normalizedLabel = NormalizeKey(label.Text);
                                if (normalizedLabel == normalizedPlaceholder && picker.SelectedItem != null)
                                {
                                    return picker.SelectedItem.ToString();
                                }
                            }
                        }
                    }
                }

                if (item is StackLayout nestedStack)
                {
                    var result = FindPickerInStack(nestedStack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            return "";
        }

        // UI Helper Methods
        private Frame CreateSectionTitle(string title, string icon)
        {
            var titleFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F0F8F0"),
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 12,
                Padding = new Thickness(20, 15),
                Margin = new Thickness(0, 0, 0, 20),
                HasShadow = false
            };

            var titleStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center
            };

            var iconLabel = new Label
            {
                Text = icon,
                FontSize = 20,
                VerticalOptions = LayoutOptions.Center
            };

            var titleLabel = new Label
            {
                Text = title,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#2E7D32"),
                VerticalOptions = LayoutOptions.Center
            };

            titleStack.Children.Add(iconLabel);
            titleStack.Children.Add(titleLabel);
            titleFrame.Content = titleStack;

            return titleFrame;
        }

        private Grid CreateFormEntry(string placeholder, string text = "", bool isDateField = false, bool isFirstField = false, bool forceEditable = false, bool forceReadOnly = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0, 12, 0, 0)
            };

            bool isReadOnly = forceReadOnly || !(_isEditable || forceEditable);

            var primaryColor = Color.FromArgb("#1976D2");
            var surfaceColor = !isReadOnly ? Colors.White : Color.FromArgb("#F5F5F5");
            var onSurfaceColor = !isReadOnly ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E");
            var outlineColor = !isReadOnly ? Color.FromArgb("#1976D2") : Color.FromArgb("#BDBDBD");

            var container = new Border
            {
                BackgroundColor = surfaceColor,
                Stroke = outlineColor,
                StrokeThickness = 1.5,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(16, 4, 12, 4),
                MinimumHeightRequest = 64,
                Shadow = !isReadOnly ? new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#40000000")),
                    Opacity = 0.15f,
                    Radius = 4,
                    Offset = new Point(0, 2)
                } : null
            };

            var mainGrid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                RowSpacing = 0
            };

            var textStack = new VerticalStackLayout
            {
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center
            };

            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = !isReadOnly ? primaryColor : Color.FromArgb("#9E9E9E"),
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 0, 0)
            };

            var entry = new Entry
            {
                Text = text,
                FontSize = 16,
                TextColor = onSurfaceColor,
                BackgroundColor = Colors.Transparent,
                IsReadOnly = isReadOnly,
                IsEnabled = !isReadOnly,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -4, 0, 0),
                VerticalTextAlignment = TextAlignment.Center
            };

            entry.Focused += (s, e) =>
            {
                container.Stroke = primaryColor;
                container.StrokeThickness = 2.5;
            };

            entry.Unfocused += (s, e) =>
            {
                container.Stroke = outlineColor;
                container.StrokeThickness = 1.5;
            };

            textStack.Children.Add(label);
            textStack.Children.Add(entry);

            Grid.SetColumn(textStack, 0);
            mainGrid.Children.Add(textStack);

            if (!isReadOnly)
            {
                var editIconBorder = new Border
                {
                    BackgroundColor = Color.FromArgb("#E8F5E9"),
                    StrokeThickness = 0,
                    StrokeShape = new RoundRectangle { CornerRadius = 20 },
                    Padding = new Thickness(8),
                    WidthRequest = 40,
                    HeightRequest = 40,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(8, 0, 0, 0)
                };

                var editIcon = new Label
                {
                    Text = "✏️",
                    FontSize = 18,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                editIconBorder.Content = editIcon;
                Grid.SetColumn(editIconBorder, 1);
                mainGrid.Children.Add(editIconBorder);
            }

            container.Content = mainGrid;
            grid.Children.Add(container);

            return grid;
        }

        private Grid CreateMultilineEntry(string placeholder, string text, bool isFirstField = false, bool forceEditable = false, bool forceReadOnly = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0, 12, 0, 0)
            };

            bool isReadOnly = forceReadOnly || !(_isEditable || forceEditable);

            var primaryColor = Color.FromArgb("#1976D2");
            var surfaceColor = !isReadOnly ? Colors.White : Color.FromArgb("#F5F5F5");
            var onSurfaceColor = !isReadOnly ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E");
            var outlineColor = !isReadOnly ? Color.FromArgb("#1976D2") : Color.FromArgb("#BDBDBD");

            var container = new Border
            {
                BackgroundColor = surfaceColor,
                Stroke = outlineColor,
                StrokeThickness = 1.5,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(16, 8, 16, 8),
                MinimumHeightRequest = 100,
                Shadow = !isReadOnly ? new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#40000000")),
                    Opacity = 0.15f,
                    Radius = 4,
                    Offset = new Point(0, 2)
                } : null
            };

            var textStack = new VerticalStackLayout
            {
                Spacing = 4
            };

            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = !isReadOnly ? primaryColor : Color.FromArgb("#9E9E9E"),
                FontAttributes = FontAttributes.Bold
            };

            var editor = new Editor
            {
                Text = text,
                FontSize = 15,
                TextColor = onSurfaceColor,
                BackgroundColor = Colors.Transparent,
                IsReadOnly = isReadOnly,
                IsEnabled = !isReadOnly,
                MinimumHeightRequest = 60,
                AutoSize = EditorAutoSizeOption.TextChanges,
                VerticalOptions = LayoutOptions.Fill
            };

            editor.Focused += (s, e) =>
            {
                container.Stroke = primaryColor;
                container.StrokeThickness = 2.5;
            };

            editor.Unfocused += (s, e) =>
            {
                container.Stroke = outlineColor;
                container.StrokeThickness = 1.5;
            };

            textStack.Children.Add(label);
            textStack.Children.Add(editor);

            container.Content = textStack;
            grid.Children.Add(container);

            return grid;
        }

        private Grid CreateDropdownEntry(string placeholder, string selectedValue = "", string[] items = null, bool isEditable = false)
        {
            var grid = new Grid
            {
                Margin = new Thickness(0, 12, 0, 0)
            };

            var primaryColor = Color.FromArgb("#1976D2");
            var surfaceColor = isEditable ? Colors.White : Color.FromArgb("#F5F5F5");
            var onSurfaceColor = isEditable ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E");
            var outlineColor = isEditable ? Color.FromArgb("#1976D2") : Color.FromArgb("#BDBDBD");

            var container = new Border
            {
                BackgroundColor = surfaceColor,
                Stroke = outlineColor,
                StrokeThickness = 1.5,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(16, 4, 16, 4),
                MinimumHeightRequest = 64,
                Shadow = isEditable ? new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#40000000")),
                    Opacity = 0.15f,
                    Radius = 4,
                    Offset = new Point(0, 2)
                } : null
            };

            var textStack = new VerticalStackLayout
            {
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center
            };

            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = isEditable ? primaryColor : Color.FromArgb("#9E9E9E"),
                FontAttributes = FontAttributes.Bold
            };

            var picker = new Picker
            {
                FontSize = 16,
                TextColor = onSurfaceColor,
                BackgroundColor = Colors.Transparent,
                IsEnabled = isEditable,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -4, 0, 0)
            };

            if (items != null)
            {
                foreach (var item in items)
                {
                    picker.Items.Add(item);
                }
            }

            if (!string.IsNullOrEmpty(selectedValue))
            {
                picker.SelectedItem = selectedValue;
            }

            picker.Focused += (s, e) =>
            {
                container.Stroke = primaryColor;
                container.StrokeThickness = 2.5;
            };

            picker.Unfocused += (s, e) =>
            {
                container.Stroke = outlineColor;
                container.StrokeThickness = 1.5;
            };

            textStack.Children.Add(label);
            textStack.Children.Add(picker);

            container.Content = textStack;
            grid.Children.Add(container);

            return grid;
        }

        private Button CreateNavigationButton(string text, Color backgroundColor, Func<Task> action)
        {
            var button = new Button
            {
                Text = text,
                BackgroundColor = backgroundColor,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 50,
                Margin = new Thickness(0, 25, 0, 0),
                FontSize = 16
            };
            button.Clicked += async (s, e) => await action();
            return button;
        }

        private Button CreateActionButton(string text, Color backgroundColor, Func<Task> asyncAction, bool enableButton = false)
        {
            var button = new Button
            {
                Text = text,
                BackgroundColor = backgroundColor,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45,
                Margin = new Thickness(0, 15, 0, 10),
                FontSize = 14,
                IsEnabled = enableButton,
                Opacity = enableButton ? 1.0 : 0.6
            };

            if (enableButton)
            {
                button.Clicked += async (s, e) => await asyncAction();
            }

            return button;
        }

        private Grid CreateDualNavigationButtons(Func<Task> previousAction, Func<Task> nextAction, string previousText = "PREVIOUS", string nextText = "NEXT")
        {
            var buttonGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                ColumnSpacing = 15,
                Margin = new Thickness(0, 25, 0, 0)
            };

            var previousButton = CreateNavigationButton(previousText, Color.FromArgb("#6C757D"), previousAction);
            var nextButton = CreateNavigationButton(nextText, Color.FromArgb("#4CAF50"), nextAction);

            Grid.SetColumn(previousButton, 0);
            Grid.SetColumn(nextButton, 1);

            buttonGrid.Children.Add(previousButton);
            buttonGrid.Children.Add(nextButton);

            return buttonGrid;
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnCloseModalClicked(object sender, EventArgs e)
        {
            CloseCurrentModal();
        }

        private void CloseCurrentModal()
        {
            if (_currentModal != null)
            {
                if (this.Content is Grid rootGrid)
                {
                    rootGrid.Children.Remove(_currentModal);
                }
                _currentModal = null;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _httpClient?.Dispose();
        }

        private class StepInfo
        {
            public string Title { get; set; } = string.Empty;
            public string Icon { get; set; } = string.Empty;
        }
    }
}