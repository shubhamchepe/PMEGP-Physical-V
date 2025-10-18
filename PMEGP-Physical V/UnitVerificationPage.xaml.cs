using Microsoft.Maui.Layouts;
using PMEGP_Physical_V.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PMEGP_Physical_V
{
    public class UnitVerificationApiResponse
    {
        [JsonPropertyName("applicantData")]
        public UnitApplicantData applicantData { get; set; }

        [JsonPropertyName("phyVerificationModel")]
        public PhyVerificationModel phyVerificationModel { get; set; }

        [JsonPropertyName("edpTrainingModel")]
        public EdpTrainingModel edpTrainingModel { get; set; }

        [JsonPropertyName("bankProcess")]
        public BankProcess bankProcess { get; set; }

        [JsonPropertyName("AgencyOffDetailModel")]
        public AgencyOffDetailModel AgencyOffDetailModel { get; set; }

        [JsonPropertyName("phyVerificationDocs")]
        public List<PhyVerificationDoc> phyVerificationDocs { get; set; }
    }

    public class UnitApplicantData
    {
        [JsonPropertyName("ApplCode")]
        public string ApplCode { get; set; }

        [JsonPropertyName("ApplName")]
        public string ApplName { get; set; }

        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("SocialCatID")]
        public string SocialCatID { get; set; }

        [JsonPropertyName("SpecialCatID")]
        public string SpecialCatID { get; set; }

        [JsonPropertyName("eMail")]
        public string eMail { get; set; }

        [JsonPropertyName("MobileNo1")]
        public string MobileNo1 { get; set; }

        [JsonPropertyName("AgencyCode")]
        public string AgencyCode { get; set; }

        [JsonPropertyName("UnitAddress")]
        public string UnitAddress { get; set; }

        [JsonPropertyName("UnitTaluka")]
        public string UnitTaluka { get; set; }

        [JsonPropertyName("UnitDistrict")]
        public string UnitDistrict { get; set; }

        [JsonPropertyName("StateName")]
        public string StateName { get; set; }


        [JsonPropertyName("UnitPin")]
        public string UnitPin { get; set; }

        [JsonPropertyName("SchemeID")]
        [JsonConverter(typeof(JsonStringConverter))]
        public string SchemeID { get; set; }


        [JsonPropertyName("UnitActivityName")]
        public string UnitActivityName { get; set; }

        [JsonPropertyName("UnitActivityName2")]
        public string UnitActivityName2 { get; set; }

        [JsonPropertyName("UnitActivityName3")]
        public string UnitActivityName3 { get; set; }

        [JsonPropertyName("ProdDescr")]
        public string ProdDescr { get; set; }

        [JsonPropertyName("ProdDescr2")]
        public string ProdDescr2 { get; set; }

        [JsonPropertyName("FinBank1")]
        public string FinBank1 { get; set; }

        [JsonPropertyName("BankBranch1")]
        public string BankBranch1 { get; set; }

        [JsonPropertyName("BankAddress1")]
        public string BankAddress1 { get; set; }

        [JsonPropertyName("BankIFSC1")]
        public string BankIFSC1 { get; set; }
    }

    public class PhyVerificationModel
    {
        [JsonPropertyName("UnitName")]
        public string UnitName { get; set; }

        [JsonPropertyName("UnitAddr")]
        public string UnitAddr { get; set; }

        [JsonPropertyName("EDPPeriod")]
        public string EDPPeriod { get; set; }

        [JsonPropertyName("VeriStatus")]
        public string VeriStatus { get; set; }

        [JsonPropertyName("UnitEstDate")]
        public string UnitEstDate { get; set; }

        [JsonPropertyName("UnitGSTNo")]
        public string UnitGSTNo { get; set; }

        [JsonPropertyName("UnitUdyamRegNo")]
        public string UnitUdyamRegNo { get; set; }

        [JsonPropertyName("UnitLocation")]
        public string UnitLocation { get; set; }

        [JsonPropertyName("Longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("Latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("GeoTagID")]
        public string GeoTagID { get; set; }

        [JsonPropertyName("SanctionedScheme")]
        public string SanctionedScheme { get; set; }

        [JsonPropertyName("AnlProdVal")]
        public decimal? AnlProdVal { get; set; }

        [JsonPropertyName("AnlSaleVal")]
        public decimal? AnlSaleVal { get; set; }

        [JsonPropertyName("ExportDetails")]
        public decimal? ExportDetails { get; set; }

        [JsonPropertyName("ExportDetCount")]
        public string ExportDetCount { get; set; }

        [JsonPropertyName("EmpMale")]
        public int? EmpMale { get; set; }

        [JsonPropertyName("EmpFemale")]
        public int? EmpFemale { get; set; }

        [JsonPropertyName("EmpTransgender")]
        public int? EmpTransgender { get; set; }

        [JsonPropertyName("EmpGEN")]
        public int? EmpGEN { get; set; }

        [JsonPropertyName("EmpSC")]
        public int? EmpSC { get; set; }

        [JsonPropertyName("EmpST")]
        public int? EmpST { get; set; }

        [JsonPropertyName("EmpOBC")]
        public int? EmpOBC { get; set; }

        [JsonPropertyName("EmpMinority")]
        public int? EmpMinority { get; set; }

        [JsonPropertyName("TotalEMP")]
        public int? TotalEMP { get; set; }

        [JsonPropertyName("AvgWgPaidPerMonth")]
        public decimal? AvgWgPaidPerMonth { get; set; }

        [JsonPropertyName("VerDate")]
        public string VerDate { get; set; }

        [JsonPropertyName("VerAgencyName")]
        public string VerAgencyName { get; set; }

        [JsonPropertyName("EnumRem")]
        public string EnumRem { get; set; }

        [JsonPropertyName("IsSignBoardIns")]
        public bool? IsSignBoardIns { get; set; }
    }

    public class EdpTrainingModel
    {
        [JsonPropertyName("TrDateTo")]
        public string TrDateTo { get; set; }

        [JsonPropertyName("EDPTCName")]
        public string EDPTCName { get; set; }

        [JsonPropertyName("EDPAddress")]
        public string EDPAddress { get; set; }
    }

    public class ImageApiResponse
    {
        [JsonPropertyName("applicantData")]
        public UnitApplicantData applicantData { get; set; }

        [JsonPropertyName("phyVerificationModel")]
        public PhyVerificationModel phyVerificationModel { get; set; }

        [JsonPropertyName("edpTrainingModel")]
        public EdpTrainingModel edpTrainingModel { get; set; }

        [JsonPropertyName("bankProcess")]
        public BankProcess bankProcess { get; set; }

        [JsonPropertyName("AgencyOffDetailModel")]
        public AgencyOffDetailModel AgencyOffDetailModel { get; set; }

        [JsonPropertyName("phyVerificationDocs")]
        public List<PhyVerificationDoc> phyVerificationDocs { get; set; }
    }

    public class BankProcess
    {
        [JsonPropertyName("SancDate")]
        public string SancDate { get; set; }

        [JsonPropertyName("CapitalExpd")]
        public decimal? CapitalExpd { get; set; }

        [JsonPropertyName("WorkingCapital")]
        public decimal? WorkingCapital { get; set; }

        [JsonPropertyName("DepAmount")]
        public decimal? DepAmount { get; set; }

        [JsonPropertyName("TotalProjectCost")]
        public decimal? TotalProjectCost { get; set; }
    }

    public class AgencyOffDetailModel
    {
        [JsonPropertyName("AgencyOffName")]
        public string AgencyOffName { get; set; }
    }

    public class PhyVerificationDoc
    {
        [JsonPropertyName("DocType")]
        public string DocType { get; set; }

        [JsonPropertyName("DocDescription")]
        public string DocDescription { get; set; }

        [JsonPropertyName("DocPath")]
        public string DocPath { get; set; }
    }
    public partial class UnitVerificationPage : ContentPage
    {
        private int _currentStep = 1;
        private const int TotalSteps = 10;
        private List<ImageButton> _stepButtons = new List<ImageButton>();
        private List<BoxView> _connectorLines = new List<BoxView>();
        private AbsoluteLayout _currentModal = null;

        // Add fields to store API data
        private UnitVerificationApiResponse _apiData = null;

        private readonly HttpClient _httpClient;
        private readonly int _applId;
        private ImageApiResponse _imageData = null;

        private readonly Dictionary<int, StepInfo> _stepInfos = new Dictionary<int, StepInfo>
        {
            { 1, new StepInfo { Title = "Beneficiary", Icon = "home.png" } },
            { 2, new StepInfo { Title = "Unit Detail", Icon = "factory.png" } },
            { 3, new StepInfo { Title = "EDP Training Detail", Icon = "briefcase.png" } },
            { 4, new StepInfo { Title = "Project Detail", Icon = "drawer.png" } },
            { 5, new StepInfo { Title = "Finance Bank Detail", Icon = "institution.png" } },
            { 6, new StepInfo { Title = "Product And Sales", Icon = "reports.png" } },
            { 7, new StepInfo { Title = "Employment Detail", Icon = "user_details.png" } },
            { 8, new StepInfo { Title = "Document Uploading", Icon = "upload.png" } },
            { 9, new StepInfo { Title = "Verification Details", Icon = "verification.png" } },
            { 10, new StepInfo { Title = "Summary", Icon = "check.png" } }
        };

        // Modified constructor to accept ApplID
        public UnitVerificationPage(int applId)
        {
            InitializeComponent();
            _applId = applId;

            var handler = new HttpClientHandler
            {
                // 🚨 Development only: ignore certificate validation
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            InitializeStepNavigation();
            LoadApiDataAsync();
        }



        // Add method to load API data
        private async void LoadApiDataAsync()
        {
            try
            {
                // Load general data from GetApplDataForPV API
                var dataResponse = await _httpClient.GetStringAsync($"https://115.124.125.153/MobileApp/GetApplDataForPV?applID={_applId}");
                _apiData = JsonSerializer.Deserialize<UnitVerificationApiResponse>(dataResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Load images from GetSavedPVData API
                var imageResponse = await _httpClient.GetStringAsync($"https://115.124.125.153/MobileApp/GetSavedPVData?applID={_applId}");
                var imageData = JsonSerializer.Deserialize<ImageApiResponse>(imageResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Combine the data
                if (_apiData != null && imageData != null)
                {
                    _imageData = imageData;
                }

                // Load the first step content after data is loaded
                LoadStepContent(_currentStep);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            }
        }

        // Add this method anywhere in the class
        private string ConvertNumberToWords(decimal number)
        {
            if (number == 0) return "Zero";

            var units = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            var teens = new[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tens = new[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string ConvertHundreds(int num)
            {
                var result = "";
                if (num >= 100)
                {
                    result += units[num / 100] + " Hundred ";
                    num %= 100;
                }
                if (num >= 20)
                {
                    result += tens[num / 10] + " ";
                    num %= 10;
                }
                else if (num >= 10)
                {
                    result += teens[num - 10] + " ";
                    num = 0;
                }
                if (num > 0)
                    result += units[num] + " ";
                return result;
            }

            var intPart = (long)number;
            var result = "";

            if (intPart >= 10000000) // Crore
            {
                result += ConvertHundreds((int)(intPart / 10000000)) + "Crore ";
                intPart %= 10000000;
            }
            if (intPart >= 100000) // Lakh
            {
                result += ConvertHundreds((int)(intPart / 100000)) + "Lakh ";
                intPart %= 100000;
            }
            if (intPart >= 1000) // Thousand
            {
                result += ConvertHundreds((int)(intPart / 1000)) + "Thousand ";
                intPart %= 1000;
            }
            if (intPart > 0)
            {
                result += ConvertHundreds((int)intPart);
            }

            return "Rupees " + result.Trim() + " Only";
        }

        // Helper method to convert Unix timestamp to readable date
        private string ConvertUnixToDate(string unixTimestamp)
        {
            if (string.IsNullOrEmpty(unixTimestamp) || !unixTimestamp.StartsWith("/Date("))
                return "";

            try
            {
                var timestamp = unixTimestamp.Replace("/Date(", "").Replace(")/", "");
                var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(timestamp));
                return dateTime.ToString("dd MMM yyyy");
            }
            catch
            {
                return "";
            }
        }

        // Helper method to get gender display text
        private string GetGenderDisplay(string gender)
        {
            return gender switch
            {
                "M" => "Male",
                "F" => "Female",
                _ => gender ?? ""
            };
        }

        // Helper method to get verification status display
        private string GetVerificationStatus(string status)
        {
            return status == "WR" ? "Working" : status ?? "";
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
                _currentStep = stepNumber;
                UpdateStepVisualStates();
                LoadStepContent(_currentStep);
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

        private void LoadStepContent(int step)
        {
            ContentContainer.Children.Clear();

            switch (step)
            {
                case 1:
                    LoadBeneficiaryContent();
                    break;
                case 2:
                    LoadUnitDetailContent();
                    break;
                case 3:
                    LoadEDPTrainingContent();
                    break;
                case 4:
                    LoadProjectDetailContent();
                    break;
                case 5:
                    LoadFinanceContent();
                    break;
                case 6:
                    LoadProductAndSalesContent();
                    break;
                case 7:
                    LoadEmploymentContent();
                    break;
                case 8:
                    LoadDocUploadContent();
                    break;
                case 9:
                    LoadVerificationContent();
                    break;
                case 10:
                    LoadSummaryContent();
                    break;
            }
        }

        private void LoadBeneficiaryContent()
        {
            var titleFrame = CreateSectionTitle("Beneficiary", "👤");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Beneficiary ID*", _apiData.applicantData?.ApplCode ?? "", false, true));
                form.Children.Add(CreateFormEntry("Beneficiary Name*", _apiData.applicantData?.ApplName ?? ""));
                form.Children.Add(CreateFormEntry("Gender*", GetGenderDisplay(_apiData.applicantData?.Gender)));
                form.Children.Add(CreateFormEntry("Social Category*", _apiData.applicantData?.SocialCatID ?? ""));
                form.Children.Add(CreateFormEntry("Special Category*", _apiData.applicantData?.SpecialCatID ?? ""));
                form.Children.Add(CreateFormEntry("Email ID*", _apiData.applicantData?.eMail ?? ""));
                form.Children.Add(CreateFormEntry("Mobile Number*", _apiData.applicantData?.MobileNo1 ?? ""));
            }
            else
            {
                // Show loading or default values
                form.Children.Add(CreateFormEntry("Loading...", "", false, true));
            }

            var nextButton = CreateNavigationButton("NEXT", Color.FromArgb("#4CAF50"), async () => await NavigateToStep(2));
            form.Children.Add(nextButton);

            ContentContainer.Children.Add(form);
        }

        private void LoadUnitDetailContent()
        {
            var titleFrame = CreateSectionTitle("Unit Detail", "🏭");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Unit Name*", _apiData.phyVerificationModel?.UnitName ?? "", false, true));
                form.Children.Add(CreateFormEntry("Updated Unit Address*", _apiData.phyVerificationModel?.UnitAddr ?? ""));

                var statusSection = CreateVerificationStatusSection(_apiData.phyVerificationModel?.VeriStatus);
                form.Children.Add(statusSection);

                form.Children.Add(CreateFormEntry("Unit Establishment Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.UnitEstDate), true));
                form.Children.Add(CreateFormEntry("GST Registration Number*", _apiData.phyVerificationModel?.UnitGSTNo ?? ""));
                form.Children.Add(CreateFormEntry("Udyam Registration Number", _apiData.phyVerificationModel?.UnitUdyamRegNo ?? ""));
                form.Children.Add(CreateFormEntry("Unit Location*", _apiData.phyVerificationModel?.UnitLocation ?? ""));
                form.Children.Add(CreateFormEntry("Unit Sponsored By*", _apiData.applicantData?.AgencyCode ?? ""));
                form.Children.Add(CreateFormEntry("Agency Office Name*", _apiData.AgencyOffDetailModel?.AgencyOffName ?? ""));
                form.Children.Add(CreateFormEntry("Address*", _apiData.applicantData?.UnitAddress ?? ""));
                form.Children.Add(CreateFormEntry("Taluka/Block*", _apiData.applicantData?.UnitTaluka ?? ""));
                form.Children.Add(CreateFormEntry("District*", _apiData.applicantData?.UnitDistrict ?? ""));
                form.Children.Add(CreateFormEntry("State*", _apiData.applicantData?.StateName ?? ""));
                form.Children.Add(CreateFormEntry("Pincode*", _apiData.applicantData?.UnitPin ?? ""));
                string industryType = _apiData.applicantData?.SchemeID == "1" ? "Manufacturing" : "Service";
                form.Children.Add(CreateFormEntry("Industry Type*", industryType));

                var activityNames = new List<string>();
                if (!string.IsNullOrEmpty(_apiData.applicantData?.UnitActivityName))
                    activityNames.Add(_apiData.applicantData.UnitActivityName);
                if (!string.IsNullOrEmpty(_apiData.applicantData?.UnitActivityName2))
                    activityNames.Add(_apiData.applicantData.UnitActivityName2);
                if (!string.IsNullOrEmpty(_apiData.applicantData?.UnitActivityName3))
                    activityNames.Add(_apiData.applicantData.UnitActivityName3);

                form.Children.Add(CreateFormEntry("Industry Activity*", string.Join(", ", activityNames)));

                var prodDescriptions = new List<string>();
                if (!string.IsNullOrEmpty(_apiData.applicantData?.ProdDescr))
                    prodDescriptions.Add(_apiData.applicantData.ProdDescr);
                if (!string.IsNullOrEmpty(_apiData.applicantData?.ProdDescr2))
                    prodDescriptions.Add(_apiData.applicantData.ProdDescr2);

                // Change this to use CreateMultilineEntry like Address of Institute
                var productDescFrame = CreateMultilineEntry("Product Description*", string.Join(", ", prodDescriptions));
                form.Children.Add(productDescFrame);

                var getLocationButton = CreateActionButton("GET LOCATION", Color.FromArgb("#2196F3"), () => GetCurrentLocation());
                form.Children.Add(getLocationButton);

                form.Children.Add(CreateFormEntry("Longitude*", _apiData.phyVerificationModel?.Longitude ?? ""));
                form.Children.Add(CreateFormEntry("Latitude*", _apiData.phyVerificationModel?.Latitude ?? ""));
                form.Children.Add(CreateFormEntry("Geo Tagging ID*", _apiData.phyVerificationModel?.GeoTagID ?? ""));
            }

            // Replace CreateMapPlaceholder() with CreateGoogleMap()
            var mapFrame = CreateGoogleMap();
            form.Children.Add(mapFrame);

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(1),
                async () => await NavigateToStep(3)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private Frame CreateGoogleMap()
        {
            var mapFrame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#2196F3"),
                CornerRadius = 12,
                HeightRequest = 300,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 15),
                HasShadow = true
            };

            try
            {
                if (_apiData?.phyVerificationModel?.Latitude != null &&
                    _apiData?.phyVerificationModel?.Longitude != null &&
                    double.TryParse(_apiData.phyVerificationModel.Latitude, out double lat) &&
                    double.TryParse(_apiData.phyVerificationModel.Longitude, out double lng))
                {
                    var mapWebView = new WebView
                    {
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill
                    };

                    // Create HTML with embedded Google Maps
                    var htmlSource = new HtmlWebViewSource
                    {
                        Html = $@"
                        <!DOCTYPE html>
                        <html>
                        <head>
                            <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no'>
                            <style>
                                * {{
                                    margin: 0;
                                    padding: 0;
                                }}
                                body, html {{
                                    height: 100%;
                                    width: 100%;
                                    overflow: hidden;
                                }}
                                #map {{
                                    height: 100%;
                                    width: 100%;
                                }}
                            </style>
                        </head>
                        <body>
                            <iframe 
                                id='map'
                                frameborder='0' 
                                style='border:0'
                                src='https://www.google.com/maps?q={lat},{lng}&z=15&output=embed'
                                allowfullscreen>
                            </iframe>
                        </body>
                        </html>"
                    };

                    mapWebView.Source = htmlSource;
                    mapFrame.Content = mapWebView;

                    // Add tap gesture to open in full maps app
                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += async (s, e) =>
                    {
                        await OpenMapsApplication(lat, lng, _apiData.phyVerificationModel.UnitName);
                    };
                    mapFrame.GestureRecognizers.Add(tapGesture);
                }
                else
                {
                    var mapContent = new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Spacing = 10,
                        Padding = new Thickness(20)
                    };

                    var mapIcon = new Label
                    {
                        Text = "🗺️",
                        FontSize = 40,
                        HorizontalOptions = LayoutOptions.Center
                    };

                    var mapLabel = new Label
                    {
                        Text = "Location data not available",
                        FontSize = 14,
                        TextColor = Color.FromArgb("#1976D2"),
                        HorizontalTextAlignment = TextAlignment.Center
                    };

                    mapContent.Children.Add(mapIcon);
                    mapContent.Children.Add(mapLabel);
                    mapFrame.Content = mapContent;
                }
            }
            catch
            {
                mapFrame.Content = new Label
                {
                    Text = "Unable to load map",
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = Color.FromArgb("#1976D2"),
                    Padding = new Thickness(20)
                };
            }

            return mapFrame;
        }

        private async Task OpenMapsApplication(double latitude, double longitude, string locationName)
        {
            try
            {
                var location = new Location(latitude, longitude);
                var options = new MapLaunchOptions { Name = locationName ?? "Unit Location" };

                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception)
            {
                try
                {
                    string uri;
                    if (DeviceInfo.Platform == DevicePlatform.iOS)
                    {
                        uri = $"http://maps.apple.com/?q={latitude},{longitude}";
                    }
                    else
                    {
                        uri = $"https://www.google.com/maps/search/?api=1&query={latitude},{longitude}";
                    }

                    await Launcher.OpenAsync(new Uri(uri));
                }
                catch (Exception)
                {
                    await DisplayAlert("Error", "Could not open maps application", "OK");
                }
            }
        }

        private void LoadEDPTrainingContent()
        {
            var titleFrame = CreateSectionTitle("EDP Training Detail", "🎓");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("EDP Completed*", ConvertUnixToDate(_apiData.edpTrainingModel?.TrDateTo), true, true));
                form.Children.Add(CreateFormEntry("EDP Training Period*", _apiData.phyVerificationModel?.EDPPeriod ?? ""));
                form.Children.Add(CreateFormEntry("Name of Institute*", _apiData.edpTrainingModel?.EDPTCName ?? ""));

                var addressFrame = CreateMultilineEntry("Address of Institute*", _apiData.edpTrainingModel?.EDPAddress ?? "");
                form.Children.Add(addressFrame);
            }

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(2),
                async () => await NavigateToStep(4)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadProjectDetailContent()
        {
            var titleFrame = CreateSectionTitle("Project Detail", "📋");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Project Sanctioned Date*", ConvertUnixToDate(_apiData.bankProcess?.SancDate), true, true));
                form.Children.Add(CreateFormEntry("Scheme under which project got sanctioned*", _apiData.phyVerificationModel?.SanctionedScheme ?? ""));
                form.Children.Add(CreateFormEntry("Capital Expenditure*", _apiData.bankProcess?.CapitalExpd?.ToString("F2") ?? ""));
                form.Children.Add(CreateFormEntry("Working Capital*", _apiData.bankProcess?.WorkingCapital?.ToString("F2") ?? ""));

                // Own Contribution with number-to-words
                var ownContribution = CreateFormEntry("Own Contribution*", _apiData.bankProcess?.DepAmount?.ToString("F2") ?? "");
                form.Children.Add(ownContribution);

                if (_apiData.bankProcess?.DepAmount.HasValue == true)
                {
                    var ownContributionWords = new Label
                    {
                        Text = ConvertNumberToWords(_apiData.bankProcess.DepAmount.Value),
                        FontSize = 11,
                        TextColor = Color.FromArgb("#666666"),
                        Margin = new Thickness(0, -10, 0, 5),
                        FontAttributes = FontAttributes.Italic
                    };
                    form.Children.Add(ownContributionWords);
                }

                // Total with number-to-words
                var total = CreateFormEntry("Total*", _apiData.bankProcess?.TotalProjectCost?.ToString("F2") ?? "");
                form.Children.Add(total);

                if (_apiData.bankProcess?.TotalProjectCost.HasValue == true)
                {
                    var totalWords = new Label
                    {
                        Text = ConvertNumberToWords(_apiData.bankProcess.TotalProjectCost.Value),
                        FontSize = 11,
                        TextColor = Color.FromArgb("#666666"),
                        Margin = new Thickness(0, -10, 0, 5),
                        FontAttributes = FontAttributes.Italic
                    };
                    form.Children.Add(totalWords);
                }
            }

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(3),
                async () => await NavigateToStep(5)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadFinanceContent()
        {
            var titleFrame = CreateSectionTitle("Finance Bank Detail", "💰");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Financing Bank*", _apiData.applicantData?.FinBank1 ?? "", false, true));
                form.Children.Add(CreateFormEntry("Bank Branch*", _apiData.applicantData?.BankBranch1 ?? ""));

                var bankAddressFrame = CreateMultilineEntry("Bank Address*", _apiData.applicantData?.BankAddress1 ?? "");
                form.Children.Add(bankAddressFrame);

                form.Children.Add(CreateFormEntry("IFSC code*", _apiData.applicantData?.BankIFSC1 ?? ""));
            }

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(4),
                async () => await NavigateToStep(6)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadProductAndSalesContent()
        {
            var titleFrame = CreateSectionTitle("Product And Sales", "📄");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                var annualProductionFrame = CreateFormEntry("Annual Production-Value", _apiData.phyVerificationModel?.AnlProdVal?.ToString("F2") ?? "", false, true);
                form.Children.Add(annualProductionFrame);

                var annualSalesFrame = CreateFormEntry("Annual Sales-Value", _apiData.phyVerificationModel?.AnlSaleVal?.ToString("F2") ?? "");
                form.Children.Add(annualSalesFrame);

                var productDetailLabel = new Label
                {
                    Text = "Product Details-Main Product",
                    FontSize = 14,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.FromArgb("#333333"),
                    Margin = new Thickness(0, 10, 0, 5)
                };
                form.Children.Add(productDetailLabel);

                var productDescFrame = CreateMultilineEntry("", _apiData.applicantData?.ProdDescr2 ?? "");
                form.Children.Add(productDescFrame);

                var exportValueFrame = CreateFormEntry("Export Detail - value*", _apiData.phyVerificationModel?.ExportDetails?.ToString("F2") ?? "");
                form.Children.Add(exportValueFrame);

                form.Children.Add(CreateFormEntry("Export Detail - Country of Export*", _apiData.phyVerificationModel?.ExportDetCount ?? ""));
            }

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(5),
                async () => await NavigateToStep(7)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadEmploymentContent()
        {
            var titleFrame = CreateSectionTitle("Employment Detail", "📊");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Male*", _apiData.phyVerificationModel?.EmpMale?.ToString() ?? "", false, true));
                form.Children.Add(CreateFormEntry("Female*", _apiData.phyVerificationModel?.EmpFemale?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("Transgender*", _apiData.phyVerificationModel?.EmpTransgender?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("General*", _apiData.phyVerificationModel?.EmpGEN?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("SC*", _apiData.phyVerificationModel?.EmpSC?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("ST*", _apiData.phyVerificationModel?.EmpST?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("OBC*", _apiData.phyVerificationModel?.EmpOBC?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("Minority*", _apiData.phyVerificationModel?.EmpMinority?.ToString() ?? ""));
                form.Children.Add(CreateFormEntry("Total Number Of Employees*", _apiData.phyVerificationModel?.TotalEMP?.ToString() ?? ""));

                // Average Wages with number-to-words
                var wagesFrame = CreateFormEntry("Average Wages paid per employee per month", _apiData.phyVerificationModel?.AvgWgPaidPerMonth?.ToString("F2") ?? "");
                form.Children.Add(wagesFrame);

                if (_apiData.phyVerificationModel?.AvgWgPaidPerMonth.HasValue == true)
                {
                    var wagesWords = new Label
                    {
                        Text = ConvertNumberToWords(_apiData.phyVerificationModel.AvgWgPaidPerMonth.Value),
                        FontSize = 11,
                        TextColor = Color.FromArgb("#666666"),
                        Margin = new Thickness(0, -10, 0, 5),
                        FontAttributes = FontAttributes.Italic
                    };
                    form.Children.Add(wagesWords);
                }
            }

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(6),
                async () => await NavigateToStep(8)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadDocUploadContent()
        {
            var titleFrame = CreateSectionTitle("Document Uploading", "📍");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            var tableFrame = CreateDocumentTable();
            form.Children.Add(tableFrame);

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(7),
                async () => await NavigateToStep(9)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
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
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
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

            var docFileHeader = new Label
            {
                Text = "Document File",
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Grid.SetColumn(docTypeHeader, 0);
            Grid.SetColumn(docNameHeader, 1);
            Grid.SetColumn(docFileHeader, 2);

            headerGrid.Children.Add(docTypeHeader);
            headerGrid.Children.Add(docNameHeader);
            headerGrid.Children.Add(docFileHeader);

            mainLayout.Children.Add(headerGrid);

            // Use _imageData instead of _apiData for documents
            if (_imageData?.phyVerificationDocs != null && _imageData.phyVerificationDocs.Any())
            {
                for (int i = 0; i < _imageData.phyVerificationDocs.Count; i++)
                {
                    var doc = _imageData.phyVerificationDocs[i];
                    var rowGrid = new Grid
                    {
                        BackgroundColor = i % 2 == 0 ? Color.FromArgb("#F9F9F9") : Colors.White,
                        Padding = new Thickness(15, 15),
                        ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
                    };

                    var docTypeLabel = new Label
                    {
                        Text = doc.DocType ?? "Document",
                        TextColor = Color.FromArgb("#333333"),
                        FontSize = 14,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    };

                    var docNameLabel = new Label
                    {
                        Text = doc.DocDescription ?? "Document",
                        TextColor = Color.FromArgb("#333333"),
                        FontSize = 14,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    };

                    var viewButton = new Button
                    {
                        Text = "View",
                        BackgroundColor = Color.FromArgb("#4CAF50"),
                        TextColor = Colors.White,
                        FontAttributes = FontAttributes.Bold,
                        CornerRadius = 8,
                        HeightRequest = 35,
                        FontSize = 12,
                        HorizontalOptions = LayoutOptions.Center,
                        ClassId = i.ToString()
                    };
                    viewButton.Clicked += OnViewDocumentClicked;

                    Grid.SetColumn(docTypeLabel, 0);
                    Grid.SetColumn(docNameLabel, 1);
                    Grid.SetColumn(viewButton, 2);

                    rowGrid.Children.Add(docTypeLabel);
                    rowGrid.Children.Add(docNameLabel);
                    rowGrid.Children.Add(viewButton);

                    mainLayout.Children.Add(rowGrid);
                }
            }

            tableFrame.Content = mainLayout;
            return tableFrame;
        }

        private async void OnViewDocumentClicked(object sender, EventArgs e)
        {
            CloseCurrentModal();

            var button = sender as Button;
            if (button?.ClassId == null || _imageData?.phyVerificationDocs == null) return;

            var docIndex = int.Parse(button.ClassId);
            if (docIndex < 0 || docIndex >= _imageData.phyVerificationDocs.Count) return;

            var document = _imageData.phyVerificationDocs[docIndex];
            var modal = CreateDocumentPreviewModal(document);
            _currentModal = modal;

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(modal, 3);
                Grid.SetRow(modal, 0);
                rootGrid.Children.Add(modal);
            }
        }

        private AbsoluteLayout CreateDocumentPreviewModal(PhyVerificationDoc document)
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
                WidthRequest = 320,
                HeightRequest = 450,
                HasShadow = true
            };

            var contentStack = new StackLayout { Spacing = 20 };

            var headerLabel = new Label
            {
                Text = document.DocType ?? "Document Preview",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#333333"),
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Document image from base64
            var imageFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F5F5F5"),
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 10,
                HeightRequest = 200,
                Padding = new Thickness(10)
            };

            try
            {
                if (!string.IsNullOrEmpty(document.DocPath))
                {
                    // Convert base64 to image
                    var imageBytes = Convert.FromBase64String(document.DocPath);
                    var imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                    var documentImage = new Image
                    {
                        Source = imageSource,
                        Aspect = Aspect.AspectFit,
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill
                    };

                    imageFrame.Content = documentImage;
                }
                else
                {
                    // Show placeholder if no image
                    var placeholderContent = new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Spacing = 10
                    };

                    var documentIcon = new Label
                    {
                        Text = "📄",
                        FontSize = 40,
                        HorizontalOptions = LayoutOptions.Center
                    };

                    var imageLabel = new Label
                    {
                        Text = "Document Preview\nNot Available",
                        FontSize = 14,
                        TextColor = Color.FromArgb("#666666"),
                        HorizontalTextAlignment = TextAlignment.Center,
                        LineHeight = 1.3
                    };

                    placeholderContent.Children.Add(documentIcon);
                    placeholderContent.Children.Add(imageLabel);
                    imageFrame.Content = placeholderContent;
                }
            }
            catch (Exception)
            {
                // Show error placeholder
                var errorContent = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Spacing = 10
                };

                var errorIcon = new Label
                {
                    Text = "❌",
                    FontSize = 40,
                    HorizontalOptions = LayoutOptions.Center
                };

                var errorLabel = new Label
                {
                    Text = "Error Loading\nDocument",
                    FontSize = 14,
                    TextColor = Color.FromArgb("#666666"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    LineHeight = 1.3
                };

                errorContent.Children.Add(errorIcon);
                errorContent.Children.Add(errorLabel);
                imageFrame.Content = errorContent;
            }

            var closeButton = new Button
            {
                Text = "CLOSE",
                BackgroundColor = Color.FromArgb("#4CAF50"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45,
                FontSize = 16
            };
            closeButton.Clicked += OnCloseModalClicked;

            contentStack.Children.Add(headerLabel);
            contentStack.Children.Add(imageFrame);
            contentStack.Children.Add(closeButton);

            contentFrame.Content = contentStack;

            AbsoluteLayout.SetLayoutBounds(contentFrame, new Rect(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(contentFrame, AbsoluteLayoutFlags.PositionProportional);

            modalOverlay.Children.Add(contentFrame);

            return modalOverlay;
        }

        private void LoadVerificationContent()
        {
            var titleFrame = CreateSectionTitle("Verification Details", "✅");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                var verificationStatusFrame = CreateDropdownEntry("Verification Status*",
                    _apiData.phyVerificationModel?.VeriStatus == "WR" ? "Completed" : "Pending",
                    false, true, true);
                form.Children.Add(verificationStatusFrame);

                form.Children.Add(CreateFormEntry("Verification Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.VerDate), true));
                form.Children.Add(CreateFormEntry("Verification Agency Name*", _apiData.phyVerificationModel?.VerAgencyName ?? ""));

                var enumeratorRemarkFrame = CreateMultilineEntry("Enumerator Remark*", _apiData.phyVerificationModel?.EnumRem ?? "");
                form.Children.Add(enumeratorRemarkFrame);

                var signBoardSection = CreateSwitchSection("Prominent Sign Board installed", _apiData.phyVerificationModel?.IsSignBoardIns ?? false);
                form.Children.Add(signBoardSection);
            }

            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(8),
                async () => await NavigateToStep(10)
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
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
                Text = "Congratulations!\n\nYou have successfully completed all verification steps. Please review all the information and submit for final approval.",
                FontSize = 16,
                TextColor = Color.FromArgb("#2E7D32"),
                HorizontalTextAlignment = TextAlignment.Center,
                LineHeight = 1.4
            };

            completionMessage.Content = messageLabel;
            form.Children.Add(completionMessage);

            // Create collapsible summary sections with API data
            form.Children.Add(CreateCollapsibleSection("Beneficiary", "👤", CreateBeneficiarySummary()));
            form.Children.Add(CreateCollapsibleSection("Unit Detail", "🏭", CreateUnitDetailSummary()));
            form.Children.Add(CreateCollapsibleSection("EDP Training Detail", "🎓", CreateEDPTrainingSummary()));
            form.Children.Add(CreateCollapsibleSection("Project Detail", "📋", CreateProjectDetailSummary()));
            form.Children.Add(CreateCollapsibleSection("Finance Bank Detail", "💰", CreateFinanceSummary()));
            form.Children.Add(CreateCollapsibleSection("Product And Sales", "📄", CreateProductSalesSummary()));
            form.Children.Add(CreateCollapsibleSection("Employment Detail", "📊", CreateEmploymentSummary()));
            form.Children.Add(CreateCollapsibleSection("Document Uploading", "📍", CreateDocumentSummary()));
            form.Children.Add(CreateCollapsibleSection("Verification Details", "✅", CreateVerificationSummary()));

            var previousButton = CreateNavigationButton("PREVIOUS", Color.FromArgb("#6C757D"), async () => await NavigateToStep(9));
            form.Children.Add(previousButton);

            ContentContainer.Children.Add(form);
        }

        private StackLayout CreateVerificationStatusSection(string veriStatus = null)
        {
            var section = new StackLayout { Spacing = 12 };

            var statusLabel = new Label
            {
                Text = "Verification Status",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#2E7D32"),
                Margin = new Thickness(0, 10, 0, 5)
            };
            section.Children.Add(statusLabel);

            var radioGroup = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 25,
                Margin = new Thickness(10, 5)
            };

            var isWorking = veriStatus == "WR";
            var isDefunct = veriStatus == "DF";
            var isNonTraceable = veriStatus == "NT";

            radioGroup.Children.Add(CreateRadioButton("Working", isWorking));
            radioGroup.Children.Add(CreateRadioButton("Defunct", isDefunct));
            radioGroup.Children.Add(CreateRadioButton("Non-Traceable", isNonTraceable));

            section.Children.Add(radioGroup);
            return section;
        }

        // Update all summary methods to use API data
        private StackLayout CreateBeneficiarySummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Beneficiary ID*", _apiData.applicantData?.ApplCode ?? "", false, true));
                summary.Children.Add(CreateFormEntry("Beneficiary Name*", _apiData.applicantData?.ApplName ?? ""));
                summary.Children.Add(CreateFormEntry("Gender*", GetGenderDisplay(_apiData.applicantData?.Gender)));
                summary.Children.Add(CreateFormEntry("Social Category*", _apiData.applicantData?.SocialCatID ?? ""));
                summary.Children.Add(CreateFormEntry("Special Category*", _apiData.applicantData?.SpecialCatID ?? ""));
                summary.Children.Add(CreateFormEntry("Email ID*", _apiData.applicantData?.eMail ?? ""));
                summary.Children.Add(CreateFormEntry("Mobile Number*", _apiData.applicantData?.MobileNo1 ?? ""));
            }
            return summary;
        }

        private StackLayout CreateUnitDetailSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Unit Name*", _apiData.phyVerificationModel?.UnitName ?? "", false, true));
                summary.Children.Add(CreateFormEntry("Updated Unit Address*", _apiData.phyVerificationModel?.UnitAddr ?? ""));
                summary.Children.Add(CreateVerificationStatusSection(_apiData.phyVerificationModel?.VeriStatus));
                summary.Children.Add(CreateFormEntry("Unit Establishment Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.UnitEstDate), true));
                summary.Children.Add(CreateFormEntry("GST Registration Number*", _apiData.phyVerificationModel?.UnitGSTNo ?? ""));
                summary.Children.Add(CreateFormEntry("Udyam Registration Number", _apiData.phyVerificationModel?.UnitUdyamRegNo ?? ""));
                summary.Children.Add(CreateFormEntry("Unit Location*", _apiData.phyVerificationModel?.UnitLocation ?? ""));
                summary.Children.Add(CreateFormEntry("Unit Sponsored By*", _apiData.applicantData?.AgencyCode ?? ""));
                summary.Children.Add(CreateFormEntry("Longitude*", _apiData.phyVerificationModel?.Longitude ?? ""));
                string industryType = _apiData.applicantData?.SchemeID == "1" ? "Manufacturing" : "Service";
                summary.Children.Add(CreateFormEntry("Industry Type*", industryType));
                summary.Children.Add(CreateFormEntry("Latitude*", _apiData.phyVerificationModel?.Latitude ?? ""));
                summary.Children.Add(CreateFormEntry("Geo Tagging ID*", _apiData.phyVerificationModel?.GeoTagID ?? ""));
            }
            return summary;
        }

        private StackLayout CreateEDPTrainingSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("EDP Completed*", ConvertUnixToDate(_apiData.edpTrainingModel?.TrDateTo), true, true));
                summary.Children.Add(CreateFormEntry("EDP Training Period*", _apiData.phyVerificationModel?.EDPPeriod ?? ""));
                summary.Children.Add(CreateFormEntry("Name of Institute*", _apiData.edpTrainingModel?.EDPTCName ?? ""));
                var addressFrame = CreateMultilineEntry("Address of Institute*", _apiData.edpTrainingModel?.EDPAddress ?? "");
                summary.Children.Add(addressFrame);
            }
            return summary;
        }

        private StackLayout CreateProjectDetailSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Project Sanctioned Date*", ConvertUnixToDate(_apiData.bankProcess?.SancDate), true, true));
                summary.Children.Add(CreateFormEntry("Scheme under which project got sanctioned*", _apiData.phyVerificationModel?.SanctionedScheme ?? ""));
                summary.Children.Add(CreateFormEntry("Capital Expenditure*", _apiData.bankProcess?.CapitalExpd?.ToString("F2") ?? ""));
                summary.Children.Add(CreateFormEntry("Working Capital*", _apiData.bankProcess?.WorkingCapital?.ToString("F2") ?? ""));
                summary.Children.Add(CreateFormEntry("Own Contribution*", _apiData.bankProcess?.DepAmount?.ToString("F2") ?? ""));
                summary.Children.Add(CreateFormEntry("Total*", _apiData.bankProcess?.TotalProjectCost?.ToString("F2") ?? ""));
            }
            return summary;
        }

        private StackLayout CreateFinanceSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Financing Bank*", _apiData.applicantData?.FinBank1 ?? "", false, true));
                summary.Children.Add(CreateFormEntry("Bank Branch*", _apiData.applicantData?.BankBranch1 ?? ""));
                var bankAddressFrame = CreateMultilineEntry("Bank Address*", _apiData.applicantData?.BankAddress1 ?? "");
                summary.Children.Add(bankAddressFrame);
                summary.Children.Add(CreateFormEntry("IFSC code*", _apiData.applicantData?.BankIFSC1 ?? ""));
            }
            return summary;
        }

        private StackLayout CreateProductSalesSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                var annualProductionFrame = CreateFormEntry("Annual Production-Value", _apiData.phyVerificationModel?.AnlProdVal?.ToString("F2") ?? "", false, true);
                summary.Children.Add(annualProductionFrame);
                var annualSalesFrame = CreateFormEntry("Annual Sales-Value", _apiData.phyVerificationModel?.AnlSaleVal?.ToString("F2") ?? "");
                summary.Children.Add(annualSalesFrame);
                var productDescFrame = CreateMultilineEntry("Product Details-Main Product", _apiData.applicantData?.ProdDescr2 ?? "");
                summary.Children.Add(productDescFrame);
                var exportValueFrame = CreateFormEntry("Export Detail - value*", _apiData.phyVerificationModel?.ExportDetails?.ToString("F2") ?? "");
                summary.Children.Add(exportValueFrame);
                summary.Children.Add(CreateFormEntry("Export Detail - Country of Export*", _apiData.phyVerificationModel?.ExportDetCount ?? ""));
            }
            return summary;
        }

        private StackLayout CreateEmploymentSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Male*", _apiData.phyVerificationModel?.EmpMale?.ToString() ?? "", false, true));
                summary.Children.Add(CreateFormEntry("Female*", _apiData.phyVerificationModel?.EmpFemale?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("Transgender*", _apiData.phyVerificationModel?.EmpTransgender?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("General*", _apiData.phyVerificationModel?.EmpGEN?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("SC*", _apiData.phyVerificationModel?.EmpSC?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("ST*", _apiData.phyVerificationModel?.EmpST?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("OBC*", _apiData.phyVerificationModel?.EmpOBC?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("Minority*", _apiData.phyVerificationModel?.EmpMinority?.ToString() ?? ""));
                summary.Children.Add(CreateFormEntry("Total Number Of Employees*", _apiData.phyVerificationModel?.TotalEMP?.ToString() ?? ""));
                var wagesFrame = CreateFormEntry("Average Wages paid per employee per month", _apiData.phyVerificationModel?.AvgWgPaidPerMonth?.ToString("F2") ?? "");
                summary.Children.Add(wagesFrame);
            }
            return summary;
        }

        private StackLayout CreateDocumentSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            var tableFrame = CreateDocumentTable();
            summary.Children.Add(tableFrame);
            return summary;
        }

        private StackLayout CreateVerificationSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                var verificationStatusFrame = CreateDropdownEntry("Verification Status*",
                    _apiData.phyVerificationModel?.VeriStatus == "WR" ? "Completed" : "Pending",
                    false, true, true);
                summary.Children.Add(verificationStatusFrame);
                summary.Children.Add(CreateFormEntry("Verification Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.VerDate), true));
                summary.Children.Add(CreateFormEntry("Verification Agency Name*", _apiData.phyVerificationModel?.VerAgencyName ?? ""));
                var enumeratorRemarkFrame = CreateMultilineEntry("Enumerator Remark*", _apiData.phyVerificationModel?.EnumRem ?? "");
                summary.Children.Add(enumeratorRemarkFrame);
                var signBoardSection = CreateSwitchSection("Prominent Sign Board installed", _apiData.phyVerificationModel?.IsSignBoardIns ?? false);
                summary.Children.Add(signBoardSection);
            }
            return summary;
            // Missing closing brace and remaining methods for UnitVerificationPage class

        }

        // Helper methods for creating UI elements
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

        // Updated CreateFormEntry to be non-editable
        private Grid CreateFormEntry(string placeholder, string text = "", bool isDateField = false, bool isFirstField = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0)
            };

            var entry = new Entry
            {
                Text = text,
                FontSize = 16,
                TextColor = Colors.Black,
                BackgroundColor = Color.FromArgb("#F8F8F8"), // Light gray background for non-editable
                IsReadOnly = true, // Make non-editable
                IsEnabled = false, // Disable interaction
                HeightRequest = 56,
                VerticalOptions = LayoutOptions.Center
            };

            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = Color.FromArgb("#666666"),
                BackgroundColor = Colors.White,
                Padding = new Thickness(4, 0),
                Margin = new Thickness(16, -6, 0, 0),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            grid.Children.Add(entry);
            grid.Children.Add(label);

            if (isDateField)
            {
                var dateIcon = new Label
                {
                    Text = "📅",
                    FontSize = 16,
                    TextColor = Color.FromArgb("#999999"), // Dimmed icon for disabled state
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End,
                    Margin = new Thickness(0, 0, 16, 0)
                };
                grid.Children.Add(dateIcon);
            }

            return grid;
        }

        // Updated CreateMultilineEntry to be non-editable
        private Grid CreateMultilineEntry(string placeholder, string text, bool isFirstField = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0)
            };

            var editor = new Editor
            {
                Text = text,
                FontSize = 16,
                TextColor = Colors.Black,
                BackgroundColor = Color.FromArgb("#F8F8F8"), // Light gray background for non-editable
                IsReadOnly = true, // Make non-editable
                IsEnabled = false, // Disable interaction
                HeightRequest = 80,
                VerticalOptions = LayoutOptions.Center
            };

            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = Color.FromArgb("#666666"),
                BackgroundColor = Colors.White,
                Padding = new Thickness(4, 0),
                Margin = new Thickness(16, -6, 0, 0),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            grid.Children.Add(editor);
            if (!string.IsNullOrEmpty(placeholder))
            {
                grid.Children.Add(label);
            }

            return grid;
        }

        private Grid CreateDropdownEntry(string placeholder, string selectedValue = "", bool isDateField = false, bool isFirstField = false, bool isDisabled = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0)
            };

            var picker = new Picker
            {
                Title = placeholder,
                FontSize = 16,
                TextColor = isDisabled ? Color.FromArgb("#999999") : Colors.Black,
                BackgroundColor = isDisabled ? Color.FromArgb("#F0F0F0") : Colors.White,
                IsEnabled = !isDisabled,
                HeightRequest = 56,
                VerticalOptions = LayoutOptions.Center
            };

            // Add dropdown options for Verification Status
            picker.Items.Add("Completed");
            picker.Items.Add("Pending");
            picker.Items.Add("In Progress");

            if (!string.IsNullOrEmpty(selectedValue))
            {
                picker.SelectedItem = selectedValue;
            }

            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = Color.FromArgb("#666666"),
                BackgroundColor = Colors.White,
                Padding = new Thickness(4, 0),
                Margin = new Thickness(16, -6, 0, 0),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            grid.Children.Add(picker);
            grid.Children.Add(label);

            return grid;
        }

        private StackLayout CreateSwitchSection(string text, bool isOn)
        {
            var section = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15,
                Margin = new Thickness(0, 10),
                VerticalOptions = LayoutOptions.Center
            };

            var label = new Label
            {
                Text = text,
                FontSize = 16,
                TextColor = Color.FromArgb("#FF6B35"),
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var switchControl = new Switch
            {
                IsToggled = isOn,
                OnColor = Color.FromArgb("#4CAF50"),
                ThumbColor = Colors.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                IsEnabled = false // Make it non-interactive for readonly form
            };

            section.Children.Add(label);
            section.Children.Add(switchControl);

            return section;
        }

        private StackLayout CreateRadioButton(string text, bool isSelected)
        {
            var container = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 8,
                VerticalOptions = LayoutOptions.Center
            };

            var radioCircle = new Frame
            {
                BackgroundColor = isSelected ? Color.FromArgb("#4CAF50") : Colors.Transparent,
                BorderColor = Color.FromArgb("#4CAF50"),
                CornerRadius = 12,
                WidthRequest = 24,
                HeightRequest = 24,
                Padding = 0,
                HasShadow = false,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false // Make non-interactive
            };

            if (isSelected)
            {
                var innerDot = new BoxView
                {
                    BackgroundColor = Colors.White,
                    WidthRequest = 10,
                    HeightRequest = 10,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                radioCircle.Content = innerDot;
            }

            var label = new Label
            {
                Text = text,
                FontSize = 14,
                TextColor = Color.FromArgb("#666666"), // Dimmed for disabled state
                VerticalOptions = LayoutOptions.Center
            };

            container.Children.Add(radioCircle);
            container.Children.Add(label);

            return container;
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

        private Button CreateActionButton(string text, Color backgroundColor, Action action)
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
                IsEnabled = false, // Disable the GET LOCATION button
                Opacity = 0.6 // Make it appear disabled
            };
            // Don't attach click handler since it's disabled
            return button;
        }

        private Grid CreateDualNavigationButtons(Func<Task> previousAction, Func<Task> nextAction)
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

            var previousButton = CreateNavigationButton("PREVIOUS", Color.FromArgb("#6C757D"), previousAction);
            var nextButton = CreateNavigationButton("NEXT", Color.FromArgb("#4CAF50"), nextAction);

            Grid.SetColumn(previousButton, 0);
            Grid.SetColumn(nextButton, 1);

            buttonGrid.Children.Add(previousButton);
            buttonGrid.Children.Add(nextButton);

            return buttonGrid;
        }

        private Frame CreateMapPlaceholder()
        {
            var mapFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#E3F2FD"),
                BorderColor = Color.FromArgb("#2196F3"),
                CornerRadius = 12,
                HeightRequest = 220,
                Padding = new Thickness(20),
                Margin = new Thickness(0, 15)
            };

            var mapContent = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 10
            };

            var mapIcon = new Label
            {
                Text = "🗺️",
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Center
            };

            var mapLabel = new Label
            {
                Text = $"Map Location\nLatitude: {_apiData?.phyVerificationModel?.Latitude ?? "N/A"}\nLongitude: {_apiData?.phyVerificationModel?.Longitude ?? "N/A"}",
                FontSize = 14,
                TextColor = Color.FromArgb("#1976D2"),
                HorizontalTextAlignment = TextAlignment.Center,
                LineHeight = 1.3
            };

            mapContent.Children.Add(mapIcon);
            mapContent.Children.Add(mapLabel);
            mapFrame.Content = mapContent;

            return mapFrame;
        }

        private Frame _currentlyOpenSection = null;

        // New helper method for collapsible sections
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

            // Header (always visible)
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

            // Content (initially hidden)
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

            // Add tap gesture to header
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (sender, e) =>
            {
                // Close currently open section if different
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

                // Toggle current section
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

        private void GetCurrentLocation()
        {
            // Disabled - no implementation needed for non-editable form
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate back
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

        // Helper class for step information
        private class StepInfo
        {
            public string Title { get; set; } = string.Empty;
            public string Icon { get; set; } = string.Empty;
        }
    }
}