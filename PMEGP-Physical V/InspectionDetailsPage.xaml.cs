using Microsoft.Maui.Controls.Shapes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PMEGP_Physical_V
{
    public class InspectionApiResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<InspectionData> Data { get; set; }
    }

    public class InspectionData
    {
        [JsonPropertyName("ApplName")]
        public string ApplName { get; set; }

        [JsonPropertyName("ContactNo")]
        public string ContactNo { get; set; }

        [JsonPropertyName("SiteAddress")]
        public string SiteAddress { get; set; }

        [JsonPropertyName("Infra_space")]
        public decimal Infra_space { get; set; }

        [JsonPropertyName("PremisesIs")]
        public int? PremisesIs { get; set; }

        [JsonPropertyName("IndustryType")]
        public int? IndustryType { get; set; }

        [JsonPropertyName("ActivityName")]
        public string ActivityName { get; set; }

        [JsonPropertyName("WhetherUnitIs")]
        public int? WhetherUnitIs { get; set; }

        [JsonPropertyName("DateOfVisit")]
        public string DateOfVisit { get; set; }

        [JsonPropertyName("PostalPreVarDet_ID")]
        public int? PostalPreVarDet_ID { get; set; }
    }

    public class DigiPinResponse
    {
        [JsonPropertyName("digipin")]
        public string Digipin { get; set; }
    }


    public class FinalSubmitRequest
    {
        [JsonPropertyName("ApplID")]
        public int ApplID { get; set; }

        [JsonPropertyName("DateOfVisit")]
        public string DateOfVisit { get; set; }

        [JsonPropertyName("Observation")]
        public string Observation { get; set; }

        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }

        [JsonPropertyName("PostalPreVarDet_ID")]
        public int PostalPreVarDet_ID { get; set; }

        [JsonPropertyName("IsPostalPreVerificationDone")]
        public int IsPostalPreVerificationDone { get; set; }

        [JsonPropertyName("docs")]
        public List<DocumentSubmitItem> Docs { get; set; }
    }



    public class DocumentSubmitItem
    {
        [JsonPropertyName("Base64File")]
        public string Base64File { get; set; }

        [JsonPropertyName("FileExtension")]
        public string FileExtension { get; set; }

        [JsonPropertyName("DocName")]
        public string DocName { get; set; }

        [JsonPropertyName("DocDescription")]
        public string DocDescription { get; set; }

        [JsonPropertyName("filePath")]
        public string FilePath { get; set; }

        [JsonPropertyName("ApplID")]
        public int ApplID { get; set; }

        [JsonPropertyName("PostalPreVarDet_ID")]
        public int PostalPreVarDet_ID { get; set; }
    }

    // ADD THIS NEW CLASS WITH A DIFFERENT NAME
    public class InspectionDocumentItem
    {
        public string DocType { get; set; } = string.Empty;
        public string DocName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public byte[] FileData { get; set; } = Array.Empty<byte>();
        public string Base64Data { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
    }




    public partial class InspectionDetailsPage : ContentPage
    {
        private int _currentStep = 1;
        private const int TotalSteps = 3;
        private List<ImageButton> _stepButtons = new List<ImageButton>();
        private List<BoxView> _connectorLines = new List<BoxView>();
        private readonly HttpClient _httpClient;
        private readonly int _applId;
        private InspectionData _apiData = null;
        private Dictionary<string, object> _formState = new Dictionary<string, object>();
        private double? _latitude = null;
        private double? _longitude = null;
        private string _digiPin = "";
        private List<InspectionDocumentItem> _uploadedDocuments = new List<InspectionDocumentItem>();
        private int _postalPreVarDetId = 0;

        private readonly Dictionary<int, StepInfo> _stepInfos = new Dictionary<int, StepInfo>
        {
            { 1, new StepInfo { Title = "Inspection Details", Icon = "user_details.png" } },
            { 2, new StepInfo { Title = "Document Upload", Icon = "upload.png" } },
            { 3, new StepInfo { Title = "Summary", Icon = "check.png" } }
        };

        public InspectionDetailsPage(int applId)
        {
            InitializeComponent();
            _applId = applId;

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
                var requestPayload = new { applID = _applId };
                var json = JsonSerializer.Serialize(requestPayload);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://115.124.125.153/MobileApp/GetPrePostalVerificationDetailsByApplID", content);
                var jsonString = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<InspectionApiResponse>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (apiResponse?.Success == true && apiResponse.Data?.Count > 0)
                {
                    _apiData = apiResponse.Data[0];

                    if (_apiData.PostalPreVarDet_ID.HasValue)
                    {
                        _postalPreVarDetId = _apiData.PostalPreVarDet_ID.Value;
                    }

                    LoadStepContent(_currentStep);
                }
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
                _currentStep = stepNumber;
                UpdateStepVisualStates();
                LoadStepContent(_currentStep);
                await Task.Delay(200);
            }
        }

        private void LoadStepContent(int step)
        {
            ContentContainer.Children.Clear();

            switch (step)
            {
                case 1:
                    LoadInspectionDetailsContent();
                    break;
                case 2:
                    LoadDocumentUploadContent();
                    break;
                case 3:
                    LoadSummaryContent();
                    break;
            }
        }

        private void LoadInspectionDetailsContent()
        {
            var titleFrame = CreateSectionTitle("Inspection Details", "👤");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Name of the Applicant*", _apiData.ApplName ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Contact Number of Applicant*", _apiData.ContactNo ?? "", false, false, false));
                form.Children.Add(CreateMultilineEntry("Unit Address*", _apiData.SiteAddress ?? "", false, false));

                var geoTagButton = CreateActionButtonWithLoader("GEO TAG", Color.FromArgb("#2196F3"), async (btn, indicator) => await GetGeoLocationAsync(btn, indicator), true);
                form.Children.Add(geoTagButton);

                var generateDigiPinButton = CreateActionButtonWithLoader("GENERATE DIGIPIN", Color.FromArgb("#2196F3"), async (btn, indicator) => await GenerateDigiPinAsync(btn, indicator), _latitude.HasValue && _longitude.HasValue);
                generateDigiPinButton.ClassId = "GenerateDigiPinButton";
                form.Children.Add(generateDigiPinButton);

                form.Children.Add(CreateFormEntry("Digi PIN*", _digiPin, false, false, false));
                form.Children.Add(CreateFormEntry("Area (in sq. ft) of the proposed unit*", _apiData.Infra_space.ToString(), false, false, false));
                form.Children.Add(CreateFormEntry("Ownership Status*", GetOwnershipStatus(_apiData.PremisesIs), false, false, false));
                form.Children.Add(CreateFormEntry("Type of Industry (Manufacturing/Service)*", GetIndustryType(_apiData.IndustryType), false, false, false));
                form.Children.Add(CreateFormEntry("Activity Name (as per NIC code)*", _apiData.ActivityName ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Whether the unit is New or Existing*", GetUnitStatus(_apiData.WhetherUnitIs), false, false, false));
                form.Children.Add(CreateFormEntry("Date and Time of Visit*", FormatDate(_apiData.DateOfVisit), false, false, false));
                form.Children.Add(CreateMultilineEntry("Observation*", "", false, true));
            }

            var nextButton = CreateNavigationButton("NEXT", Color.FromArgb("#4CAF50"), async () => await NavigateToStep(2));
            form.Children.Add(nextButton);

            ContentContainer.Children.Add(form);
        }

        private async Task GetGeoLocationAsync(Grid buttonGrid, ActivityIndicator loadingIndicator)
        {
            try
            {
                loadingIndicator.IsVisible = true;
                loadingIndicator.IsRunning = true;

                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                {
                    loadingIndicator.IsVisible = false;
                    loadingIndicator.IsRunning = false;
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
                    _latitude = location.Latitude;
                    _longitude = location.Longitude;

                    loadingIndicator.IsVisible = false;
                    loadingIndicator.IsRunning = false;

                    await DisplayAlert("Success", $"Location captured: {_latitude:F6}, {_longitude:F6}", "OK");
                    UpdateGenerateDigiPinButtonState(true);
                }
                else
                {
                    loadingIndicator.IsVisible = false;
                    loadingIndicator.IsRunning = false;
                }
            }
            catch (Exception ex)
            {
                loadingIndicator.IsVisible = false;
                loadingIndicator.IsRunning = false;
                await DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
            }
        }

        private async Task GenerateDigiPinAsync(Grid buttonGrid, ActivityIndicator loadingIndicator)
        {
            if (!_latitude.HasValue || !_longitude.HasValue)
            {
                await DisplayAlert("Error", "Please capture location first", "OK");
                return;
            }

            try
            {
                loadingIndicator.IsVisible = true;
                loadingIndicator.IsRunning = true;

                var requestPayload = new { lati = _latitude.Value, longti = _longitude.Value };
                var json = JsonSerializer.Serialize(requestPayload);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                System.Diagnostics.Debug.WriteLine($"DigiPin Request: {json}");

                var response = await _httpClient.PostAsync("https://115.124.125.153/MobileApp/DigiPinEncodeAsync", content);
                var jsonString = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine($"DigiPin Response: {jsonString}");

                if (response.IsSuccessStatusCode)
                {
                    var digiPinResponse = JsonSerializer.Deserialize<DigiPinResponse>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (digiPinResponse != null && !string.IsNullOrEmpty(digiPinResponse.Digipin))
                    {
                        _digiPin = digiPinResponse.Digipin;
                        _formState["DigiPIN"] = _digiPin;

                        loadingIndicator.IsVisible = false;
                        loadingIndicator.IsRunning = false;

                        LoadStepContent(1);
                        await DisplayAlert("Success", $"Digi PIN generated: {_digiPin}", "OK");
                    }
                    else
                    {
                        loadingIndicator.IsVisible = false;
                        loadingIndicator.IsRunning = false;
                        await DisplayAlert("Error", "Failed to parse Digi PIN from response", "OK");
                    }
                }
                else
                {
                    loadingIndicator.IsVisible = false;
                    loadingIndicator.IsRunning = false;
                    await DisplayAlert("Error", $"API returned error: {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                loadingIndicator.IsVisible = false;
                loadingIndicator.IsRunning = false;
                System.Diagnostics.Debug.WriteLine($"DigiPin Error: {ex.Message}");
                await DisplayAlert("Error", $"Failed to generate Digi PIN: {ex.Message}", "OK");
            }
        }

        private void UpdateGenerateDigiPinButtonState(bool enabled)
        {
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    foreach (var item in stack.Children)
                    {
                        if (item is Grid containerGrid && containerGrid.Children.Count > 0)
                        {
                            if (containerGrid.Children[0] is Frame buttonFrame && buttonFrame.ClassId == "GenerateDigiPinButton")
                            {
                                buttonFrame.BackgroundColor = enabled ? Color.FromArgb("#2196F3") : Color.FromArgb("#CCCCCC");

                                buttonFrame.GestureRecognizers.Clear();

                                if (enabled)
                                {
                                    var contentStack = buttonFrame.Content as HorizontalStackLayout;
                                    var loadingIndicator = contentStack?.Children.OfType<ActivityIndicator>().FirstOrDefault();

                                    var tapGesture = new TapGestureRecognizer();
                                    tapGesture.Tapped += async (s, e) =>
                                    {
                                        if (loadingIndicator != null && !loadingIndicator.IsRunning)
                                        {
                                            await GenerateDigiPinAsync(containerGrid, loadingIndicator);
                                        }
                                    };
                                    buttonFrame.GestureRecognizers.Add(tapGesture);
                                }
                            }
                        }
                    }
                }
            }
        }

        private string FormatDate(string? dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            try
            {
                if (dateString.StartsWith("/Date("))
                {
                    var timestamp = dateString.Replace("/Date(", "").Replace(")/", "");
                    if (long.TryParse(timestamp, out long milliseconds))
                    {
                        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        var date = epoch.AddMilliseconds(milliseconds);
                        return date.ToString("dd-MM-yyyy HH:mm:ss");
                    }
                }
                return dateString;
            }
            catch
            {
                return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            }
        }

        private void LoadDocumentUploadContent()
        {
            var titleFrame = CreateSectionTitleWithButton("Document Uploading", "📍", true);
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            var tableFrame = CreateDocumentTable();
            form.Children.Add(tableFrame);

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(1),
                async () => await NavigateToStep(3),
                "PREVIOUS",
                "NEXT"
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
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
            try
            {
                var action = await DisplayActionSheet("Select Photo Source", "Cancel", null, "Take Photo", "Choose from Gallery");

                FileResult result = null;

                if (action == "Take Photo")
                {
                    if (MediaPicker.Default.IsCaptureSupported)
                    {
                        result = await MediaPicker.Default.CapturePhotoAsync();
                    }
                    else
                    {
                        await DisplayAlert("Not Supported", "Camera is not available on this device", "OK");
                        return;
                    }
                }
                else if (action == "Choose from Gallery")
                {
                    result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
                    {
                        Title = "Select a photo"
                    });
                }

                if (result != null)
                {
                    var docName = await DisplayPromptAsync("Document Name", "Enter document name:");
                    if (!string.IsNullOrEmpty(docName))
                    {
                        using (var stream = await result.OpenReadAsync())
                        using (var memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            var fileBytes = memoryStream.ToArray();
                            var base64String = Convert.ToBase64String(fileBytes);
                            var fileExtension = System.IO.Path.GetExtension(result.FullPath);

                            _uploadedDocuments.Add(new InspectionDocumentItem
                            {
                                DocType = "Photo",
                                DocName = docName,
                                FilePath = result.FullPath,
                                FileData = fileBytes,
                                Base64Data = base64String,
                                FileExtension = fileExtension
                            });
                        }
                        LoadStepContent(2);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to select photo: {ex.Message}", "OK");
            }
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

            for (int i = 0; i < _uploadedDocuments.Count; i++)
            {
                var doc = _uploadedDocuments[i];

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
                    Text = doc.DocType,
                    TextColor = Color.FromArgb("#333333"),
                    FontSize = 14,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };

                var docNameLabel = new Label
                {
                    Text = doc.DocName,
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
                    FontSize = 12
                };

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

                deleteButton.Clicked += (s, e) =>
                {
                    _uploadedDocuments.RemoveAt(int.Parse(deleteButton.ClassId));
                    LoadStepContent(2);
                };

                actionStack.Children.Add(viewButton);
                actionStack.Children.Add(deleteButton);

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

        private void LoadSummaryContent()
        {
            var titleFrame = CreateSectionTitle("Summary", "🏆");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Name of the Applicant*", _apiData.ApplName ?? "", false, false, false, true));
                form.Children.Add(CreateFormEntry("Contact Number of Applicant*", _apiData.ContactNo ?? "", false, false, false, true));
                form.Children.Add(CreateMultilineEntry("Unit Address*", _apiData.SiteAddress ?? "", false, false, true));
                form.Children.Add(CreateFormEntry("Digi PIN*", _digiPin, false, false, false, true));
                form.Children.Add(CreateFormEntry("Area (in sq. ft) of the proposed unit*", _apiData.Infra_space.ToString(), false, false, false, true));
                form.Children.Add(CreateFormEntry("Ownership Status*", GetOwnershipStatus(_apiData.PremisesIs), false, false, false, true));
                form.Children.Add(CreateFormEntry("Type of Industry (Manufacturing/Service)*", GetIndustryType(_apiData.IndustryType), false, false, false, true));
                form.Children.Add(CreateFormEntry("Activity Name (as per NIC code)*", _apiData.ActivityName ?? "", false, false, false, true));
                form.Children.Add(CreateFormEntry("Whether the unit is New or Existing*", GetUnitStatus(_apiData.WhetherUnitIs), false, false, false, true));
                form.Children.Add(CreateFormEntry("Date and Time of Visit*", FormatDate(_apiData.DateOfVisit), false, false, false, true));
                form.Children.Add(CreateMultilineEntry("Observation*", _formState.ContainsKey("Observation") ? _formState["Observation"].ToString() : "", false, false, true));
            }

            var finalSubmitButton = CreateNavigationButton("FINAL SUBMIT", Color.FromArgb("#FF6B35"), async () => await FinalSubmit());
            form.Children.Add(finalSubmitButton);

            var previousButton = CreateNavigationButton("PREVIOUS", Color.FromArgb("#6C757D"), async () => await NavigateToStep(2));
            form.Children.Add(previousButton);

            ContentContainer.Children.Add(form);
        }

        private async Task FinalSubmit()
        {
            bool confirm = await DisplayAlert("Confirm Submission", "Are you sure you want to submit?", "Yes", "No");
            if (!confirm) return;

            try
            {
                // Get observation from form state
                var observation = _formState.ContainsKey("Observation") ? _formState["Observation"].ToString() : "";

                // Prepare current date time
                var currentDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                // Prepare documents list
                var docsList = new List<DocumentSubmitItem>();
                foreach (var doc in _uploadedDocuments)
                {
                    docsList.Add(new DocumentSubmitItem
                    {
                        Base64File = doc.Base64Data,
                        FileExtension = doc.FileExtension,
                        DocName = doc.DocName,
                        DocDescription = doc.DocType,
                        FilePath = doc.FilePath ?? "",
                        ApplID = _applId,
                        PostalPreVarDet_ID = _postalPreVarDetId
                    });
                }

                // Create request payload
                var submitRequest = new FinalSubmitRequest
                {
                    ApplID = _applId,
                    DateOfVisit = currentDateTime,
                    Observation = observation,
                    CreatedDate = currentDateTime,
                    PostalPreVarDet_ID = _postalPreVarDetId,
                    IsPostalPreVerificationDone = 1,
                    Docs = docsList
                };

                var json = JsonSerializer.Serialize(submitRequest);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                System.Diagnostics.Debug.WriteLine($"Final Submit Request: {json}");

                var response = await _httpClient.PostAsync("https://115.124.125.153/MobileApp/UpdatePostalPreVarDetails", content);
                var responseString = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine($"Final Submit Response: {responseString}");

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Inspection completed successfully!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", $"Submission failed: {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Final Submit Error: {ex.Message}");
                await DisplayAlert("Error", $"Failed to submit: {ex.Message}", "OK");
            }
        }

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

            bool isReadOnly = forceReadOnly || !forceEditable;

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
                MinimumHeightRequest = 64
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

            textStack.Children.Add(label);
            textStack.Children.Add(entry);

            Grid.SetColumn(textStack, 0);
            mainGrid.Children.Add(textStack);

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

            bool isReadOnly = forceReadOnly || !forceEditable;

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
                MinimumHeightRequest = 100
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

            editor.TextChanged += (s, e) =>
            {
                _formState["Observation"] = e.NewTextValue ?? "";
            };

            textStack.Children.Add(label);
            textStack.Children.Add(editor);

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

        private Grid CreateActionButtonWithLoader(string text, Color backgroundColor, Func<Grid, ActivityIndicator, Task> asyncAction, bool enableButton = false)
        {
            var containerGrid = new Grid
            {
                Margin = new Thickness(0, 15, 0, 10)
            };

            var buttonFrame = new Frame
            {
                BackgroundColor = enableButton ? backgroundColor : Color.FromArgb("#CCCCCC"),
                HeightRequest = 45,
                Padding = new Thickness(15, 0),
                CornerRadius = 10,
                HasShadow = false,
                BorderColor = Colors.Transparent
            };

            var contentStack = new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10
            };

            var buttonLabel = new Label
            {
                Text = text,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                VerticalOptions = LayoutOptions.Center
            };

            var loadingIndicator = new ActivityIndicator
            {
                Color = Colors.White,
                WidthRequest = 20,
                HeightRequest = 20,
                IsVisible = false,
                IsRunning = false,
                VerticalOptions = LayoutOptions.Center
            };

            contentStack.Children.Add(buttonLabel);
            contentStack.Children.Add(loadingIndicator);

            buttonFrame.Content = contentStack;

            var tapGesture = new TapGestureRecognizer();
            if (enableButton)
            {
                tapGesture.Tapped += async (s, e) =>
                {
                    if (loadingIndicator.IsRunning) return;
                    await asyncAction(containerGrid, loadingIndicator);
                };
            }
            buttonFrame.GestureRecognizers.Add(tapGesture);

            buttonFrame.ClassId = text.Contains("GENERATE") ? "GenerateDigiPinButton" : "";

            containerGrid.Children.Add(buttonFrame);
            return containerGrid;
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
        private string GetOwnershipStatus(int? value)
        {
            return value switch
            {
                1 => "Owned",
                2 => "Rented",
                3 => "Leased",
                _ => "Not Specified"
            };
        }

        private string GetIndustryType(int? value)
        {
            return value switch
            {
                1 => "Manufacturing",
                2 => "Service",
                3 => "Trading",
                _ => "Not Specified"
            };
        }

        private string GetUnitStatus(int? value)
        {
            return value switch
            {
                1 => "New Unit",
                2 => "Existing Unit",
                _ => "Not Specified"
            };
        }
    }
}