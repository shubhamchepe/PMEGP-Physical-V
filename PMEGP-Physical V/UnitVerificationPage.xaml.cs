using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using PMEGP_Physical_V.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;
using IOPath = System.IO.Path;


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

        [JsonPropertyName("FullTime_Emp")]
        public string FullTime_Emp { get; set; }

        [JsonPropertyName("PartTime_Emp")]
        public string PartTime_Emp { get; set; }

        [JsonPropertyName("Seasonal_Emp")]
        public string Seasonal_Emp { get; set; }

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
        private readonly string _badgeStatus;
        private bool _isEditable = false;
        private readonly bool _isUnitVerDone;
        private readonly string _detailsPageStatus;
        private Dictionary<int, Dictionary<string, object>> _stepData = new Dictionary<int, Dictionary<string, object>>();
        private string _previousVerificationStatus = "WR"; // Track previous status
        private Dictionary<string, object> _formState = new Dictionary<string, object>();

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
        public UnitVerificationPage(int applId, string detailsPageStatus, string badgeStatus = "Completed", bool isUnitVerDone = false)
        {
            InitializeComponent();
            _applId = applId;
            _badgeStatus = badgeStatus?.Trim() ?? "Completed";
            _isUnitVerDone = isUnitVerDone;
            _detailsPageStatus = detailsPageStatus;

            _isEditable = !string.Equals(_badgeStatus, "Completed", StringComparison.OrdinalIgnoreCase);

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
                //System.Diagnostics.Debug.WriteLine($"\n🔄 Navigating from Step {_currentStep} to Step {stepNumber}");

                // CRITICAL: Save current step state BEFORE changing _currentStep
                SaveCurrentStepState();

                _currentStep = stepNumber;
                UpdateStepVisualStates();

                // Load the new step content
                LoadStepContent(_currentStep);

                // CRITICAL: Wait for UI to fully render before restoring
                await Task.Delay(200); // Increased delay to ensure UI is ready

                // Restore saved state for the new step
                RestoreStepState();

                await ScrollToStep(stepNumber);

                //System.Diagnostics.Debug.WriteLine($"✅ Navigation complete to Step {stepNumber}\n");
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

        /// <summary>
        /// Save all input values from current step before navigating away
        /// </summary>
        private void SaveCurrentStepState()
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine($"🔵 Saving state for step {_currentStep}...");
                int savedCount = 0;

                foreach (var child in ContentContainer.Children)
                {
                    if (child is StackLayout stack)
                    {
                        savedCount += SaveStackLayoutState(stack);
                    }
                }

                //System.Diagnostics.Debug.WriteLine($"✅ State saved for step {_currentStep}: {savedCount} items, Total in state: {_formState.Count}");

                // Debug: Print all saved keys
                foreach (var key in _formState.Keys)
                {
                    System.Diagnostics.Debug.WriteLine($"   📝 {key} = {_formState[key]}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error saving state: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        /// <summary>
        /// Recursively save state from StackLayout hierarchy
        /// </summary>
        private int SaveStackLayoutState(StackLayout stack)
        {
            int count = 0;

            foreach (var item in stack.Children)
            {
                try
                {
                    if (item is Grid editorGrid)
                    {
                        // Check for Border containing Editor directly
                        var editorBorder = editorGrid.Children.OfType<Border>().FirstOrDefault();
                        if (editorBorder?.Content is VerticalStackLayout editorVertStack)
                        {
                            var editorLabel = editorVertStack.Children.OfType<Label>().FirstOrDefault();
                            var editor = editorVertStack.Children.OfType<Editor>().FirstOrDefault();

                            if (editorLabel != null && editor != null)
                            {
                                string key = NormalizeKey(editorLabel.Text);
                                string value = editor.Text ?? "";
                                _formState[key] = value;
                                count++;
                                System.Diagnostics.Debug.WriteLine($"   ✔️ Saved Multiline Editor: {key} = {value.Substring(0, Math.Min(50, value.Length))}...");
                                continue; // Skip further processing for this item
                            }
                        }
                    }
                    // Handle Grid containing Entry/Editor/Picker
                    if (item is Grid grid)
                    {
                        // Check for Border wrapper (Material Design 3 style)
                        var border = grid.Children.OfType<Border>().FirstOrDefault();
                        if (border?.Content is Grid contentGrid)
                        {
                            var result = ExtractAndSaveFromGrid(contentGrid);
                            if (result.saved)
                            {
                                count++;
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Saved from Grid: {result.key} = {result.value}");
                            }
                        }
                        // Check for direct Entry/Editor/Picker in Grid (old style)
                        else
                        {
                            var result = ExtractAndSaveFromGrid(grid);
                            if (result.saved)
                            {
                                count++;
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Saved from Direct Grid: {result.key} = {result.value}");
                            }
                        }
                    }

                    if (item is Picker standalonePicker && standalonePicker.SelectedItem != null)
                    {
                        // Get picker title or use a default key
                        string key = !string.IsNullOrEmpty(standalonePicker.Title)
                            ? NormalizeKey(standalonePicker.Title)
                            : "ProductDetailsMainProduct";

                        string value = standalonePicker.SelectedItem.ToString();
                        _formState[key] = value;
                        count++;
                        System.Diagnostics.Debug.WriteLine($"   ✔️ Saved Standalone Picker: {key} = {value}");
                    }

                    // Handle Switch sections
                    if (item is StackLayout possibleSwitchWrapper)
                    {
                        var switchBorder = possibleSwitchWrapper.Children.OfType<Border>().FirstOrDefault();
                        if (switchBorder?.Content is Grid switchGrid)
                        {
                            var label = switchGrid.Children.OfType<Label>().FirstOrDefault();
                            var switchControl = switchGrid.Children.OfType<Switch>().FirstOrDefault();

                            if (label != null && switchControl != null)
                            {
                                string key = NormalizeKey(label.Text);
                                _formState[key] = switchControl.IsToggled;
                                count++;
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Saved Switch: {key} = {switchControl.IsToggled}");
                            }
                        }
                    }

                    // Handle Radio button groups (Verification Status)
                    if (item is StackLayout radioGroup && radioGroup.Orientation == StackOrientation.Horizontal)
                    {
                        foreach (var radioContainer in radioGroup.Children.OfType<StackLayout>())
                        {
                            var radioFrame = radioContainer.Children.FirstOrDefault() as Frame;
                            if (radioFrame != null && radioFrame.BackgroundColor == Color.FromArgb("#4CAF50"))
                            {
                                _formState["VerificationStatus_Selected"] = radioFrame.ClassId;
                                count++;
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Saved Radio: VerificationStatus_Selected = {radioFrame.ClassId}");
                                break;
                            }
                        }
                    }

                    // Recursively process nested StackLayouts
                    if (item is StackLayout nestedStack && item != stack)
                    {
                        count += SaveStackLayoutState(nestedStack);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"   ⚠️ Error processing item: {ex.Message}");
                }
            }

            return count;
        }

        /// <summary>
        /// Extract and save input values from a Grid
        /// </summary>
        private (bool saved, string key, object value) ExtractAndSaveFromGrid(Grid grid)
        {
            try
            {
                // Look for VerticalStackLayout (Material Design 3 style)
                var verticalStack = grid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                if (verticalStack != null)
                {
                    var label = verticalStack.Children.OfType<Label>().FirstOrDefault();
                    var entry = verticalStack.Children.OfType<Entry>().FirstOrDefault();
                    var editor = verticalStack.Children.OfType<Editor>().FirstOrDefault();
                    var picker = verticalStack.Children.OfType<Picker>().FirstOrDefault();

                    if (label != null)
                    {
                        string key = NormalizeKey(label.Text);

                        if (entry != null)
                        {
                            string value = entry.Text ?? "";
                            _formState[key] = value;
                            return (true, key, value);
                        }
                        else if (editor != null)
                        {
                            string value = editor.Text ?? "";
                            _formState[key] = value;
                            return (true, key, value);
                        }
                        else if (picker != null && picker.SelectedItem != null)
                        {
                            string value = picker.SelectedItem.ToString();
                            _formState[key] = value;

                            // Special handling for Verification Status dropdown
                            if (key.Contains("VerificationStatus"))
                            {
                                _formState["VerificationStatus_Dropdown"] = value;
                                System.Diagnostics.Debug.WriteLine($"   🔵 Saved Verification Dropdown: {value}");
                            }

                            return (true, key, value);
                        }
                    }
                }

                // Fallback: Look for direct Entry/Editor/Picker (old style)
                var directLabel = grid.Children.OfType<Label>().FirstOrDefault();
                var directEntry = grid.Children.OfType<Entry>().FirstOrDefault();
                var directEditor = grid.Children.OfType<Editor>().FirstOrDefault();
                var directPicker = grid.Children.OfType<Picker>().FirstOrDefault();

                if (directLabel != null)
                {
                    string key = NormalizeKey(directLabel.Text);

                    if (directEntry != null)
                    {
                        string value = directEntry.Text ?? "";
                        _formState[key] = value;
                        return (true, key, value);
                    }
                    else if (directEditor != null)
                    {
                        string value = directEditor.Text ?? "";
                        _formState[key] = value;
                        return (true, key, value);
                    }
                    else if (directPicker != null && directPicker.SelectedItem != null)
                    {
                        string value = directPicker.SelectedItem.ToString();
                        _formState[key] = value;
                        return (true, key, value);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"   ⚠️ ExtractAndSaveFromGrid error: {ex.Message}");
            }

            return (false, "", null);
        }

        /// <summary>
        /// Restore saved values when loading a step
        /// </summary>
        private void RestoreStepState()
        {
            try
            {
                if (_formState.Count == 0)
                {
                    //System.Diagnostics.Debug.WriteLine($"⚠️ No state to restore for step {_currentStep}");
                    return;
                }

                //System.Diagnostics.Debug.WriteLine($"🔵 Restoring state for step {_currentStep}...");
                int restoredCount = 0;

                // Use BeginInvokeOnMainThread to ensure UI is ready
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var child in ContentContainer.Children)
                    {
                        if (child is StackLayout stack)
                        {
                            restoredCount += RestoreStackLayoutState(stack);
                        }
                    }

                    //System.Diagnostics.Debug.WriteLine($"✅ State restored for step {_currentStep}: {restoredCount} items");
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error restoring state: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        /// <summary>
        /// Recursively restore state to StackLayout hierarchy
        /// </summary>
        private int RestoreStackLayoutState(StackLayout stack)
        {
            int count = 0;

            foreach (var item in stack.Children)
            {
                try
                {
                    if (item is Grid editorGrid)
                    {
                        var editorBorder = editorGrid.Children.OfType<Border>().FirstOrDefault();
                        if (editorBorder?.Content is VerticalStackLayout editorVertStack)
                        {
                            var editorLabel = editorVertStack.Children.OfType<Label>().FirstOrDefault();
                            var editor = editorVertStack.Children.OfType<Editor>().FirstOrDefault();

                            if (editorLabel != null && editor != null && editor.IsEnabled)
                            {
                                string key = NormalizeKey(editorLabel.Text);
                                if (_formState.ContainsKey(key))
                                {
                                    editor.Text = _formState[key]?.ToString() ?? "";
                                    count++;
                                    System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Multiline Editor: {key} = {editor.Text.Substring(0, Math.Min(50, editor.Text.Length))}...");
                                    continue; // Skip further processing
                                }
                            }
                        }
                    }
                    // Handle Grid containing Entry/Editor/Picker
                    if (item is Grid grid)
                    {
                        // Check for Border wrapper (Material Design 3 style)
                        var border = grid.Children.OfType<Border>().FirstOrDefault();
                        if (border?.Content is Grid contentGrid)
                        {
                            if (RestoreToGrid(contentGrid))
                            {
                                count++;
                            }
                        }
                        // Check for direct Entry/Editor/Picker in Grid (old style)
                        else
                        {
                            if (RestoreToGrid(grid))
                            {
                                count++;
                            }
                        }
                    }

                    if (item is Picker standalonePicker && standalonePicker.IsEnabled)
                    {
                        string key = !string.IsNullOrEmpty(standalonePicker.Title)
                            ? NormalizeKey(standalonePicker.Title)
                            : "ProductDetailsMainProduct";

                        if (_formState.ContainsKey(key))
                        {
                            string savedValue = _formState[key]?.ToString();
                            if (!string.IsNullOrEmpty(savedValue) && standalonePicker.Items.Contains(savedValue))
                            {
                                standalonePicker.SelectedItem = savedValue;
                                count++;
                                System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Standalone Picker: {key} = {savedValue}");
                            }
                        }
                    }

                    // Handle Switch sections
                    if (item is StackLayout possibleSwitchWrapper)
                    {
                        var switchBorder = possibleSwitchWrapper.Children.OfType<Border>().FirstOrDefault();
                        if (switchBorder?.Content is Grid switchGrid)
                        {
                            var label = switchGrid.Children.OfType<Label>().FirstOrDefault();
                            var switchControl = switchGrid.Children.OfType<Switch>().FirstOrDefault();

                            if (label != null && switchControl != null && switchControl.IsEnabled)
                            {
                                string key = NormalizeKey(label.Text);
                                if (_formState.ContainsKey(key) && _formState[key] is bool boolValue)
                                {
                                    switchControl.IsToggled = boolValue;
                                    count++;
                                    //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Switch: {key} = {boolValue}");
                                }
                            }
                        }
                    }

                    // Handle Radio button groups (Verification Status)
                    if (item is StackLayout radioGroup && radioGroup.Orientation == StackOrientation.Horizontal)
                    {
                        if (_formState.ContainsKey("VerificationStatus_Selected"))
                        {
                            string savedSelection = _formState["VerificationStatus_Selected"]?.ToString();
                            //System.Diagnostics.Debug.WriteLine($"   🔵 Restoring radio selection: {savedSelection}");

                            foreach (var radioContainer in radioGroup.Children.OfType<StackLayout>())
                            {
                                var radioFrame = radioContainer.Children.FirstOrDefault() as Frame;
                                if (radioFrame != null)
                                {
                                    bool shouldSelect = radioFrame.ClassId == savedSelection;
                                    radioFrame.BackgroundColor = shouldSelect ? Color.FromArgb("#4CAF50") : Colors.Transparent;

                                    if (shouldSelect)
                                    {
                                        var innerDot = new BoxView
                                        {
                                            BackgroundColor = Colors.White,
                                            WidthRequest = 8,
                                            HeightRequest = 8,
                                            CornerRadius = 4,
                                            HorizontalOptions = LayoutOptions.Center,
                                            VerticalOptions = LayoutOptions.Center
                                        };
                                        radioFrame.Content = innerDot;
                                        count++;
                                        //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Radio: {savedSelection}");
                                    }
                                    else
                                    {
                                        radioFrame.Content = null;
                                    }
                                }
                            }
                        }
                    }

                    // Recursively process nested StackLayouts
                    if (item is StackLayout nestedStack && item != stack)
                    {
                        count += RestoreStackLayoutState(nestedStack);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"   ⚠️ Error processing item during restore: {ex.Message}");
                }
            }

            return count;
        }

        /// <summary>
        /// Restore values to a Grid containing input controls
        /// </summary>
        private bool RestoreToGrid(Grid grid)
        {
            try
            {
                // Look for VerticalStackLayout (Material Design 3 style)
                var verticalStack = grid.Children.OfType<VerticalStackLayout>().FirstOrDefault();
                if (verticalStack != null)
                {
                    var label = verticalStack.Children.OfType<Label>().FirstOrDefault();
                    var entry = verticalStack.Children.OfType<Entry>().FirstOrDefault();
                    var editor = verticalStack.Children.OfType<Editor>().FirstOrDefault();
                    var picker = verticalStack.Children.OfType<Picker>().FirstOrDefault();

                    if (label != null)
                    {
                        string key = NormalizeKey(label.Text);

                        if (_formState.ContainsKey(key))
                        {
                            var savedValue = _formState[key];

                            if (entry != null && entry.IsEnabled)
                            {
                                entry.Text = savedValue?.ToString() ?? "";
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Entry: {key} = {entry.Text}");
                                return true;
                            }
                            else if (editor != null && editor.IsEnabled)
                            {
                                editor.Text = savedValue?.ToString() ?? "";
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Editor: {key} = {editor.Text}");
                                return true;
                            }
                            else if (picker != null && picker.IsEnabled)
                            {
                                string savedPickerValue = savedValue?.ToString();

                                // Special handling for Verification Status dropdown
                                if (key.Contains("VerificationStatus") && _formState.ContainsKey("VerificationStatus_Dropdown"))
                                {
                                    savedPickerValue = _formState["VerificationStatus_Dropdown"]?.ToString();
                                }

                                if (!string.IsNullOrEmpty(savedPickerValue) && picker.Items.Contains(savedPickerValue))
                                {
                                    picker.SelectedItem = savedPickerValue;
                                    System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Picker: {key} = {savedPickerValue}");
                                    return true;
                                }
                            }
                        }
                    }
                }

                // Fallback: Look for direct Entry/Editor/Picker (old style)
                var directLabel = grid.Children.OfType<Label>().FirstOrDefault();
                var directEntry = grid.Children.OfType<Entry>().FirstOrDefault();
                var directEditor = grid.Children.OfType<Editor>().FirstOrDefault();
                var directPicker = grid.Children.OfType<Picker>().FirstOrDefault();

                if (directLabel != null)
                {
                    string key = NormalizeKey(directLabel.Text);

                    if (_formState.ContainsKey(key))
                    {
                        var savedValue = _formState[key];

                        if (directEntry != null && directEntry.IsEnabled)
                        {
                            directEntry.Text = savedValue?.ToString() ?? "";
                            //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Direct Entry: {key} = {directEntry.Text}");
                            return true;
                        }
                        else if (directEditor != null && directEditor.IsEnabled)
                        {
                            directEditor.Text = savedValue?.ToString() ?? "";
                            //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Direct Editor: {key} = {directEditor.Text}");
                            return true;
                        }
                        else if (directPicker != null && directPicker.IsEnabled)
                        {
                            string savedPickerValue = savedValue?.ToString();
                            if (!string.IsNullOrEmpty(savedPickerValue) && directPicker.Items.Contains(savedPickerValue))
                            {
                                directPicker.SelectedItem = savedPickerValue;
                                //System.Diagnostics.Debug.WriteLine($"   ✔️ Restored Direct Picker: {key} = {savedPickerValue}");
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"   ⚠️ RestoreToGrid error: {ex.Message}");
            }

            return false;
        }

        private string NormalizeKey(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace("*", "").Replace(" ", "").Replace(":", "").Replace("-", "").Trim();
        }

        private void LoadStepContent(int step)
        {
            //System.Diagnostics.Debug.WriteLine($"📄 Loading content for step {step}");

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

            //System.Diagnostics.Debug.WriteLine($"✅ Content loaded for step {step}");
        }

        private void LoadBeneficiaryContent()
        {
            var titleFrame = CreateSectionTitle("Beneficiary", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                // Temporarily override _isEditable to force read-only state for Beneficiary section
                bool originalIsEditable = _isEditable;
                _isEditable = false; // Force non-editable

                form.Children.Add(CreateFormEntry("Beneficiary ID*", _apiData.applicantData?.ApplCode ?? "", false, true, false));
                form.Children.Add(CreateFormEntry("Beneficiary Name*", _apiData.applicantData?.ApplName ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Gender*", GetGenderDisplay(_apiData.applicantData?.Gender), false, false, false));
                form.Children.Add(CreateFormEntry("Social Category*", _apiData.applicantData?.SocialCatID ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Special Category*", _apiData.applicantData?.SpecialCatID ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Email ID*", _apiData.applicantData?.eMail ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Mobile Number*", _apiData.applicantData?.MobileNo1 ?? "", false, false, false));

                _isEditable = originalIsEditable; // Restore original state
            }
            else
            {
                // Show loading or default values
                form.Children.Add(CreateFormEntry("Loading...", "", false, true));
            }

            // Change button text based on editable status
            string buttonText = _isEditable ? "SAVE" : "NEXT";
            var nextButton = CreateNavigationButton(buttonText, Color.FromArgb("#4CAF50"), async () =>
            {
                if (_isEditable)
                {
                    await SaveBeneficiaryData();
                }
                await NavigateToStep(2);
            });
            form.Children.Add(nextButton);

            ContentContainer.Children.Add(form);
        }

        private async Task GetCurrentLocationAsync()
        {
            try
            {
                // Request location permissions
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permission Denied", "Location permission is required to get current location", "OK");
                    return;
                }

                // Show loading indicator
                await DisplayAlert("Loading", "Fetching location...", "OK");

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(10)
                });

                if (location != null)
                {
                    // Update Latitude field
                    var latEntry = FindEntryByPlaceholder("Latitude");
                    if (latEntry != null)
                        latEntry.Text = location.Latitude.ToString("F6");

                    // Update Longitude field
                    var longEntry = FindEntryByPlaceholder("Longitude");
                    if (longEntry != null)
                        longEntry.Text = location.Longitude.ToString("F6");

                    // Generate and update GeoTag ID
                    var geoTagEntry = FindEntryByPlaceholder("GeoTaggingID");
                    if (geoTagEntry != null)
                    {
                        string geoTagId = GenerateGeoTagId(location.Latitude, location.Longitude);
                        geoTagEntry.Text = geoTagId;
                    }

                    // Update the API data object
                    if (_apiData?.phyVerificationModel != null)
                    {
                        _apiData.phyVerificationModel.Latitude = location.Latitude.ToString("F6");
                        _apiData.phyVerificationModel.Longitude = location.Longitude.ToString("F6");
                        _apiData.phyVerificationModel.GeoTagID = GenerateGeoTagId(location.Latitude, location.Longitude);
                    }

                    // Reload the section to update map
                    LoadStepContent(2);

                    await DisplayAlert("Success", "Location captured and map updated successfully", "OK");
                }
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Error", "Location services not supported on this device", "OK");
            }
            catch (PermissionException)
            {
                await DisplayAlert("Error", "Location permission denied", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
            }
        }

        private Entry FindEntryByClassId(string classId)
        {
            // Helper to find Entry controls by ClassId
            // TODO: Implement recursive search through ContentContainer
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    foreach (var item in stack.Children)
                    {
                        if (item is Grid grid && grid.ClassId == classId)
                        {
                            return grid.Children.OfType<Entry>().FirstOrDefault();
                        }
                    }
                }
            }
            return null;
        }

        private void LoadUnitDetailContent()
        {
            var titleFrame = CreateSectionTitle("Unit Detail", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Unit Name*", _apiData.phyVerificationModel?.UnitName ?? "", false, true, _isEditable));
                form.Children.Add(CreateMultilineEntry("Updated Unit Address*", _apiData.phyVerificationModel?.UnitAddr ?? "", false, _isEditable));

                var statusSection = CreateVerificationStatusSection(_apiData.phyVerificationModel?.VeriStatus, _isEditable);
                form.Children.Add(statusSection);

                if (!string.IsNullOrEmpty(_apiData.phyVerificationModel?.VeriStatus))
                {
                    _previousVerificationStatus = _apiData.phyVerificationModel.VeriStatus == "WR" ? "Working" :
                                                   _apiData.phyVerificationModel.VeriStatus == "DF" ? "Defunct" :
                                                   _apiData.phyVerificationModel.VeriStatus == "NT" ? "Non-Traceable" : "Working";
                }

                form.Children.Add(CreateFormEntry("Unit Establishment Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.UnitEstDate), true, false, _isEditable));
                form.Children.Add(CreateFormEntry("GST Registration Number*", _apiData.phyVerificationModel?.UnitGSTNo ?? "", false, false, _isEditable));
                form.Children.Add(CreateFormEntry("Udyam Registration Number", _apiData.phyVerificationModel?.UnitUdyamRegNo ?? "", false, false, false));
                form.Children.Add(CreateFormEntry("Unit Location*", _apiData.phyVerificationModel?.UnitLocation ?? "", false, false, _isEditable));
                form.Children.Add(CreateFormEntry("Unit Sponsored By*", _apiData.applicantData?.AgencyCode ?? "", false, false, _isEditable));
                form.Children.Add(CreateFormEntry("Agency Office Name*", _apiData.AgencyOffDetailModel?.AgencyOffName ?? "", false, false, _isEditable));
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

                var getLocationButton = CreateActionButton("GET LOCATION", Color.FromArgb("#2196F3"), async () => await GetCurrentLocationAsync(), _isEditable);
                form.Children.Add(getLocationButton);

                var longitudeEntry = CreateFormEntry("Longitude*", _apiData.phyVerificationModel?.Longitude ?? "", false, false, false);
                longitudeEntry.ClassId = "LongitudeEntry"; // For programmatic access
                form.Children.Add(longitudeEntry);

                var latitudeEntry = CreateFormEntry("Latitude*", _apiData.phyVerificationModel?.Latitude ?? "", false, false, false);
                latitudeEntry.ClassId = "LatitudeEntry"; // For programmatic access
                form.Children.Add(latitudeEntry);

                var geoTagEntry = CreateFormEntry("Geo Tagging ID*", _apiData.phyVerificationModel?.GeoTagID ?? "", false, false, false);
                geoTagEntry.ClassId = "GeoTagEntry"; // For programmatic access
                form.Children.Add(geoTagEntry);
            }

            // Replace CreateMapPlaceholder() with CreateGoogleMap()
            var mapFrame = CreateGoogleMap();
            form.Children.Add(mapFrame);

            string nextButtonText = _isEditable ? "SAVE" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(1),
                async () =>
                {
                    if (_isEditable) await SaveUnitDetailData();
                    await NavigateToStep(3);
                },
                "PREVIOUS",
                nextButtonText
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
            var titleFrame = CreateSectionTitle("EDP Training Detail", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("EDP Completed*", ConvertUnixToDate(_apiData.edpTrainingModel?.TrDateTo), false, false, false));
                form.Children.Add(CreateFormEntry("EDP Training Period*", _apiData.phyVerificationModel?.EDPPeriod ?? "", false, false, _isEditable));
                form.Children.Add(CreateFormEntry("Name of Institute*", _apiData.edpTrainingModel?.EDPTCName ?? "", false, false, false));

                var addressFrame = CreateMultilineEntry("Address of Institute*", _apiData.edpTrainingModel?.EDPAddress ?? "", false, false);
                form.Children.Add(addressFrame);
            }

            string nextButtonText = _isEditable ? "SAVE" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(2),
                async () =>
                {
                    if (_isEditable) await SaveEDPTrainingData();
                    await NavigateToStep(4);
                },
                "PREVIOUS",
                nextButtonText
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadProjectDetailContent()
        {
            var titleFrame = CreateSectionTitle("Project Detail", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Project Sanctioned Date*", ConvertUnixToDate(_apiData.bankProcess?.SancDate), true, true));
                string schemeValue = _isEditable && string.IsNullOrEmpty(_apiData.phyVerificationModel?.SanctionedScheme)
    ? "PMEGP"
    : (_apiData.phyVerificationModel?.SanctionedScheme ?? "PMEGP");
                form.Children.Add(CreateFormEntry("Scheme under which project got sanctioned*", schemeValue, false, false, _isEditable));
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
            var titleFrame = CreateSectionTitle("Finance Bank Detail", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                form.Children.Add(CreateFormEntry("Financing Bank*", _apiData.applicantData?.FinBank1 ?? "", false, true));
                form.Children.Add(CreateFormEntry("Bank Branch*", _apiData.applicantData?.BankBranch1 ?? ""));

                var bankAddressFrame = CreateMultilineEntry("Bank Address*", _apiData.applicantData?.BankAddress1 ?? "", false, false, true);
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

        private string ConvertNumberToRupeesWords(long amount)
        {
            if (amount == 0) return "Rupees Zero Only";
            if (amount < 0) return "Minus " + ConvertNumberToRupeesWords(-amount);

            string words = "";

            // Crore (10,000,000)
            if (amount >= 10000000)
            {
                long crore = amount / 10000000;
                words += ConvertHundreds((int)crore) + "Crore ";
                amount %= 10000000;
            }

            // Lakh (100,000)
            if (amount >= 100000)
            {
                long lakh = amount / 100000;
                words += ConvertHundreds((int)lakh) + "Lakh ";
                amount %= 100000;
            }

            // Thousand (1,000)
            if (amount >= 1000)
            {
                long thousand = amount / 1000;
                words += ConvertHundreds((int)thousand) + "Thousand ";
                amount %= 1000;
            }

            // Hundreds
            if (amount > 0)
            {
                words += ConvertHundreds((int)amount);
            }

            return "Rupees " + words.Trim() + " Only";
        }

        private string ConvertHundreds(int number)
        {
            string[] units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string word = "";

            if (number >= 100)
            {
                word += units[number / 100] + " Hundred ";
                number %= 100;
            }

            if (number >= 20)
            {
                word += tens[number / 10] + " ";
                number %= 10;
            }
            else if (number >= 10)
            {
                word += teens[number - 10] + " ";
                return word;
            }

            if (number > 0)
            {
                word += units[number] + " ";
            }

            return word;
        }

        private string GenerateGeoTagId(double latitude, double longitude)
        {
            // Create deterministic ID from coordinates
            string combined = $"{latitude:F6}_{longitude:F6}";

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(combined));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").Substring(0, 12);
                return $"GEOTAG_{hash}";
            }
        }

        private string ConvertSchemeIdToString(object schemeId)
        {
            if (schemeId == null) return string.Empty;

            // Handle if it's already a string
            if (schemeId is string str)
                return str;

            // Handle if it's a number (int, long, decimal, etc.)
            if (schemeId is int || schemeId is long || schemeId is decimal || schemeId is double)
                return schemeId.ToString();

            // Fallback
            return schemeId.ToString();
        }

        private void LoadProductAndSalesContent()
        {
            var titleFrame = CreateSectionTitle("Product And Sales", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                var annualProductionFrame = CreateFormEntry("Annual Production-Value", _apiData.phyVerificationModel?.AnlProdVal?.ToString("F2") ?? "", false, true);
                form.Children.Add(annualProductionFrame);

                // Add words for Annual Production
                // Add words for Annual Production
                if (_apiData.phyVerificationModel?.AnlProdVal.HasValue == true)
                {
                    var productionWords = new Label
                    {
                        Text = ConvertNumberToRupeesWords((long)_apiData.phyVerificationModel.AnlProdVal.Value),
                        FontSize = 11,
                        TextColor = Color.FromArgb("#666666"),
                        Margin = new Thickness(0, -10, 0, 5),
                        FontAttributes = FontAttributes.Italic
                    };
                    form.Children.Add(productionWords);
                }

                var annualSalesFrame = CreateFormEntry("Annual Sales-Value", _apiData.phyVerificationModel?.AnlSaleVal?.ToString("F2") ?? "");
                form.Children.Add(annualSalesFrame);

                // Add words for Annual Sales
                if (_apiData.phyVerificationModel?.AnlSaleVal.HasValue == true)
                {
                    var salesWords = new Label
                    {
                        Text = ConvertNumberToRupeesWords((long)_apiData.phyVerificationModel.AnlSaleVal.Value),
                        FontSize = 11,
                        TextColor = Color.FromArgb("#666666"),
                        Margin = new Thickness(0, -10, 0, 5),
                        FontAttributes = FontAttributes.Italic
                    };
                    form.Children.Add(salesWords);
                }

                // Add Product Details dropdown
                var productPicker = new Picker
                {
                    Title = "Product Details - Main Product",
                    FontSize = 16,
                    TextColor = Colors.Black,
                    BackgroundColor = _isEditable ? Colors.White : Color.FromArgb("#F8F8F8"),
                    IsEnabled = _isEditable,
                    HeightRequest = 56,
                    Margin = new Thickness(0, 10, 0, 0)
                };

                productPicker.Items.Add("--select");
                productPicker.Items.Add("Opencast mining of hard coal");
                productPicker.Items.Add("Cleaning, sizing, grading, pulverizing, compressing etc. of coal");
                productPicker.Items.Add("Belowground mining of hard coal");

                // Try to select existing value or default
                string existingProduct = _apiData.applicantData?.ProdDescr2 ?? "";
                if (productPicker.Items.Contains(existingProduct))
                    productPicker.SelectedItem = existingProduct;
                else
                    productPicker.SelectedIndex = 0;

                form.Children.Add(productPicker);

                productPicker.SelectedIndexChanged += (s, e) =>
                {
                    if (productPicker.SelectedItem != null)
                    {
                        string key = NormalizeKey(productPicker.Title);
                        _formState[key] = productPicker.SelectedItem.ToString();
                        System.Diagnostics.Debug.WriteLine($"   💾 Product dropdown changed: {productPicker.SelectedItem}");
                    }
                };

                var exportValueFrame = CreateFormEntry("Export Detail - value*", _apiData.phyVerificationModel?.ExportDetails?.ToString("F2") ?? "");
                form.Children.Add(exportValueFrame);

                form.Children.Add(CreateFormEntry("Export Detail - Country of Export*", _apiData.phyVerificationModel?.ExportDetCount ?? "", false, false, _isEditable));
            }

            string nextButtonText = _isEditable ? "SAVE & NEXT" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(5),
                async () =>
                {
                    if (_isEditable) await SaveProductSalesData();
                    await NavigateToStep(7);
                },
                "PREVIOUS",
                nextButtonText
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadEmploymentContent()
        {
            var titleFrame = CreateSectionTitle("Employment Detail", "");
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

                // ✅ FIXED: Now using string properties, no .ToString() needed
                form.Children.Add(CreateFormEntry("Full-Time Employees",
                    _apiData.phyVerificationModel?.FullTime_Emp ?? "0",
                    false, false, _isEditable));
                form.Children.Add(CreateFormEntry("Part-Time Employees",
                    _apiData.phyVerificationModel?.PartTime_Emp ?? "0",
                    false, false, _isEditable));
                form.Children.Add(CreateFormEntry("Seasonal Employees",
                    _apiData.phyVerificationModel?.Seasonal_Emp ?? "0",
                    false, false, _isEditable));

                form.Children.Add(CreateFormEntry("Total Number Of Employees*", _apiData.phyVerificationModel?.TotalEMP?.ToString() ?? ""));

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

            string nextButtonText = _isEditable ? "SAVE & NEXT" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(6),
                async () =>
                {
                    if (_isEditable) await SaveEmploymentData();
                    await NavigateToStep(8);
                },
                "PREVIOUS",
                nextButtonText
            );
            form.Children.Add(navigationButtons);

            ContentContainer.Children.Add(form);
        }

        private void LoadDocUploadContent()
        {
            var titleFrame = CreateSectionTitleWithButton("Document Uploading", "📍", _isEditable);
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            var tableFrame = CreateDocumentTable();
            form.Children.Add(tableFrame);

            string nextButtonText = _isEditable ? "SAVE & NEXT" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(7),
                async () =>
                {
                    if (_isEditable) await SaveDocumentData();
                    await NavigateToStep(9);
                },
                "PREVIOUS",
                nextButtonText
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

        private List<DocumentUploadItem> _uploadedDocuments = new List<DocumentUploadItem>();

        private class DocumentUploadItem
        {
            public string DocType { get; set; }
            public string DocName { get; set; }
            public string FilePath { get; set; }
            public byte[] FileData { get; set; }
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

            // Document Type Picker
            var docTypePicker = new Picker
            {
                Title = "Document Type*",
                FontSize = 16,
                BackgroundColor = Colors.White,
                HeightRequest = 50
            };
            docTypePicker.Items.Add("Unit Photo");
            docTypePicker.Items.Add("Product Photo");
            docTypePicker.Items.Add("Bank Document");
            docTypePicker.Items.Add("PMEGP SignBoard Photo");
            docTypePicker.Items.Add("Declaration Photo");
            docTypePicker.Items.Add("Manufacturing");
            docTypePicker.Items.Add("Others");

            // Document Name Entry
            var docNameEntry = new Entry
            {
                Placeholder = "Document Name*",
                FontSize = 16,
                BackgroundColor = Colors.White,
                HeightRequest = 50
            };

            // File Picker Section
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
                    fileNameLabel.ClassId = result.FullPath; // Store path
                }
            };

            Grid.SetColumn(chooseFileButton, 0);
            Grid.SetColumn(fileNameLabel, 1);
            filePickerGrid.Children.Add(chooseFileButton);
            filePickerGrid.Children.Add(fileNameLabel);
            filePickerFrame.Content = filePickerGrid;

            // Upload Button
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
                // Validate
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
                    // Read file and convert to base64
                    var filePath = fileNameLabel.ClassId;
                    byte[] fileBytes;

                    using (var stream = File.OpenRead(filePath))
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }

                    var base64File = Convert.ToBase64String(fileBytes);
                    var fileExtension = IOPath.GetExtension(filePath);

                    // Get state info from API data
                    var stateName = _apiData?.applicantData?.StateName ?? "Maharashtra";
                    var stateCode = stateName == "Maharashtra" ? "27" : "00"; // Default logic
                    var applCode = _apiData?.applicantData?.ApplCode ?? "";

                    // Create document upload item
                    var uploadItem = new DocumentUploadItem
                    {
                        DocType = docTypePicker.SelectedItem.ToString(),
                        DocName = docNameEntry.Text,
                        FilePath = filePath,
                        FileData = fileBytes
                    };

                    // Prepare API payload
                    var documentPayload = new[]
                    {
            new
            {
                Base64File = base64File,
                FileExtension = fileExtension,
                DocDescription = docNameEntry.Text,
                ApplID = _applId,
                StateName = stateName,
                StateCode = stateCode,
                ApplCode = applCode,
                DocType = docTypePicker.SelectedItem.ToString()
            }
        };

                    var jsonPayload = JsonSerializer.Serialize(documentPayload);
                    var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                    //System.Diagnostics.Debug.WriteLine($"Uploading document: {docNameEntry.Text}");

                    // Call upload API
                    var response = await _httpClient.PostAsync(
                        "https://115.124.125.153/MobileApp/UploadAllDocumentsUV",
                        content
                    );

                    var responseContent = await response.Content.ReadAsStringAsync();
                    //System.Diagnostics.Debug.WriteLine($"Upload Response: {responseContent}");

                    if (response.IsSuccessStatusCode)
                    {
                        _uploadedDocuments.Add(uploadItem);
                        await DisplayAlert("Success", "Document uploaded successfully", "OK");
                        CloseCurrentModal();
                        LoadStepContent(8); // Reload step 8
                    }
                    else
                    {
                        throw new Exception($"Upload failed: {responseContent}");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Upload Error: {ex.Message}");
                    await DisplayAlert("Error", $"Failed to upload document: {ex.Message}", "OK");
                }
            };

            // Close Button
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

            // Combine API documents with uploaded documents
            var allDocuments = new List<object>();

            if (_imageData?.phyVerificationDocs != null)
            {
                allDocuments.AddRange(_imageData.phyVerificationDocs);
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
                    var apiDoc = doc as PhyVerificationDoc;
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

                // Action buttons
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

                bool isCompletedStatus = string.Equals(_badgeStatus, "Completed", StringComparison.OrdinalIgnoreCase);
                bool showDeleteButton = !_isUnitVerDone && isUploadedDoc;

                //System.Diagnostics.Debug.WriteLine($"Delete button visibility - Badge Status: {_badgeStatus}, IsCompleted: {isCompletedStatus}, IsUploadedDoc: {isUploadedDoc}, ShowDelete: {showDeleteButton}");

                if (showDeleteButton)
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
                            LoadStepContent(8); // Reload
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
            var titleFrame = CreateSectionTitle("Verification Details", "");
            ContentContainer.Children.Add(titleFrame);

            var form = new StackLayout { Spacing = 16 };

            if (_apiData != null)
            {
                var verificationStatusFrame = CreateDropdownEntry("Verification Status*",
    _apiData.phyVerificationModel?.VeriStatus == "WR" ? "Completed" : "Pending",
    false, true, !_isEditable); // Enable dropdown when editable
                form.Children.Add(verificationStatusFrame);

                form.Children.Add(CreateFormEntry("Verification Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.VerDate), true));
                form.Children.Add(CreateFormEntry("Verification Agency Name*", _apiData.phyVerificationModel?.VerAgencyName ?? ""));

                var enumeratorRemarkFrame = CreateMultilineEntry("Enumerator Remark*", _apiData.phyVerificationModel?.EnumRem ?? "", false, _isEditable);
                form.Children.Add(enumeratorRemarkFrame);

                var signBoardSection = CreateSwitchSection("Prominent Sign Board installed", _apiData.phyVerificationModel?.IsSignBoardIns ?? false, _isEditable);
                form.Children.Add(signBoardSection);
            }

            string nextButtonText = _isEditable ? "SAVE & NEXT" : "NEXT";
            var navigationButtons = CreateDualNavigationButtons(
                async () => await NavigateToStep(8),
                async () =>
                {
                    if (_isEditable) await SaveVerificationData();
                    await NavigateToStep(10);
                },
                "PREVIOUS",
                nextButtonText
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
            form.Children.Add(CreateCollapsibleSection("Beneficiary", "", CreateBeneficiarySummary()));
            form.Children.Add(CreateCollapsibleSection("Unit Detail", "", CreateUnitDetailSummary()));
            form.Children.Add(CreateCollapsibleSection("EDP Training Detail", "", CreateEDPTrainingSummary()));
            form.Children.Add(CreateCollapsibleSection("Project Detail", "", CreateProjectDetailSummary()));
            form.Children.Add(CreateCollapsibleSection("Finance Bank Detail", "", CreateFinanceSummary()));
            form.Children.Add(CreateCollapsibleSection("Product And Sales", "", CreateProductSalesSummary()));
            form.Children.Add(CreateCollapsibleSection("Employment Detail", "", CreateEmploymentSummary()));
            form.Children.Add(CreateCollapsibleSection("Document Uploading", "", CreateDocumentSummary()));
            form.Children.Add(CreateCollapsibleSection("Verification Details", "", CreateVerificationSummary()));

            var finalSubmitButton = CreateNavigationButton("FINAL SUBMIT", Color.FromArgb("#FF6B35"), async () => await FinalSubmit());
            form.Children.Add(finalSubmitButton);

            var previousButton = CreateNavigationButton("PREVIOUS", Color.FromArgb("#6C757D"), async () => await NavigateToStep(9));
            form.Children.Add(previousButton);

            ContentContainer.Children.Add(form);
        }

        private StackLayout CreateVerificationStatusSection(string veriStatus = null, bool enableSelection = false)
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
                Spacing = 15,
                Margin = new Thickness(5, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            // ✅ Check formState first, then fallback to API data
            string currentStatus = null;
            if (_formState.ContainsKey("VerificationStatus_Selected"))
            {
                currentStatus = _formState["VerificationStatus_Selected"]?.ToString();
                System.Diagnostics.Debug.WriteLine($"📍 Restoring status from formState: {currentStatus}");
            }
            else if (!string.IsNullOrEmpty(veriStatus))
            {
                currentStatus = veriStatus == "WR" ? "Working" :
                               veriStatus == "DF" ? "Defunct" :
                               veriStatus == "NT" ? "Non-Traceable" : null;
                System.Diagnostics.Debug.WriteLine($"📍 Using status from API: {currentStatus}");
            }

            var isWorking = currentStatus == "Working";
            var isDefunct = currentStatus == "Defunct";
            var isNonTraceable = currentStatus == "Non-Traceable";

            radioGroup.Children.Add(CreateRadioButton("Working", isWorking, enableSelection));
            radioGroup.Children.Add(CreateRadioButton("Defunct", isDefunct, enableSelection));
            radioGroup.Children.Add(CreateRadioButton("Non-Traceable", isNonTraceable, enableSelection));

            section.Children.Add(radioGroup);
            return section;
        }

        // Update all summary methods to use API data
        private StackLayout CreateBeneficiarySummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Beneficiary ID*", _apiData.applicantData?.ApplCode ?? "", false, true, false, true));
                summary.Children.Add(CreateFormEntry("Beneficiary Name*", _apiData.applicantData?.ApplName ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Gender*", GetGenderDisplay(_apiData.applicantData?.Gender), false, false, false, true));
                summary.Children.Add(CreateFormEntry("Social Category*", _apiData.applicantData?.SocialCatID ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Special Category*", _apiData.applicantData?.SpecialCatID ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Email ID*", _apiData.applicantData?.eMail ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Mobile Number*", _apiData.applicantData?.MobileNo1 ?? "", false, false, false, true));
            }
            return summary;
        }

        private StackLayout CreateUnitDetailSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Unit Name*", _apiData.phyVerificationModel?.UnitName ?? "", false, true, false, true));
                summary.Children.Add(CreateFormEntry("Updated Unit Address*", _apiData.phyVerificationModel?.UnitAddr ?? "", false, false, false, true));
                summary.Children.Add(CreateVerificationStatusSection(_apiData.phyVerificationModel?.VeriStatus));
                summary.Children.Add(CreateFormEntry("Unit Establishment Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.UnitEstDate), true, false, false, true));
                summary.Children.Add(CreateFormEntry("GST Registration Number*", _apiData.phyVerificationModel?.UnitGSTNo ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Udyam Registration Number", _apiData.phyVerificationModel?.UnitUdyamRegNo ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Unit Location*", _apiData.phyVerificationModel?.UnitLocation ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Unit Sponsored By*", _apiData.applicantData?.AgencyCode ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Longitude*", _apiData.phyVerificationModel?.Longitude ?? "", false, false, false, true));

                string industryType = _apiData.applicantData?.SchemeID == "1" ? "Manufacturing" : "Service";
                summary.Children.Add(CreateFormEntry("Industry Type*", industryType, false, false, false, true));

                summary.Children.Add(CreateFormEntry("Latitude*", _apiData.phyVerificationModel?.Latitude ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Geo Tagging ID*", _apiData.phyVerificationModel?.GeoTagID ?? "", false, false, false, true));

            }
            return summary;
        }

        private StackLayout CreateEDPTrainingSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("EDP Completed*", ConvertUnixToDate(_apiData.edpTrainingModel?.TrDateTo), true, true, false, true));
                summary.Children.Add(CreateFormEntry("EDP Training Period*", _apiData.phyVerificationModel?.EDPPeriod ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Name of Institute*", _apiData.edpTrainingModel?.EDPTCName ?? "", false, false, false, true));

                var addressFrame = CreateMultilineEntry(
    "Address of Institute*",
    _apiData.edpTrainingModel?.EDPAddress ?? "",
    false,
    false,
    true   // this makes it non-editable
);
                summary.Children.Add(addressFrame);

            }
            return summary;
        }

        private StackLayout CreateProjectDetailSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Project Sanctioned Date*", ConvertUnixToDate(_apiData.bankProcess?.SancDate), true, true, false, true));
                summary.Children.Add(CreateFormEntry("Scheme under which project got sanctioned*", _apiData.phyVerificationModel?.SanctionedScheme ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Capital Expenditure*", _apiData.bankProcess?.CapitalExpd?.ToString("F2") ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Working Capital*", _apiData.bankProcess?.WorkingCapital?.ToString("F2") ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Own Contribution*", _apiData.bankProcess?.DepAmount?.ToString("F2") ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Total*", _apiData.bankProcess?.TotalProjectCost?.ToString("F2") ?? "", false, false, false, true));

            }
            return summary;
        }

        private StackLayout CreateFinanceSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Financing Bank*", _apiData.applicantData?.FinBank1 ?? "", false, true, false, true));
                summary.Children.Add(CreateFormEntry("Bank Branch*", _apiData.applicantData?.BankBranch1 ?? "", false, false, false, true));

                var bankAddressFrame = CreateMultilineEntry("Bank Address*", _apiData.applicantData?.BankAddress1 ?? "", false, false, true);
                summary.Children.Add(bankAddressFrame);

                summary.Children.Add(CreateFormEntry("IFSC code*", _apiData.applicantData?.BankIFSC1 ?? "", false, false, false, true));

            }
            return summary;
        }

        private StackLayout CreateProductSalesSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                var annualProductionFrame = CreateFormEntry("Annual Production-Value", _apiData.phyVerificationModel?.AnlProdVal?.ToString("F2") ?? "", false, true, false, true);
                summary.Children.Add(annualProductionFrame);

                var annualSalesFrame = CreateFormEntry("Annual Sales-Value", _apiData.phyVerificationModel?.AnlSaleVal?.ToString("F2") ?? "", false, false, false, true);
                summary.Children.Add(annualSalesFrame);

                var productDescFrame = CreateMultilineEntry("Product Details-Main Product", _apiData.applicantData?.ProdDescr2 ?? "", false, false, true);
                summary.Children.Add(productDescFrame);

                var exportValueFrame = CreateFormEntry("Export Detail - value*", _apiData.phyVerificationModel?.ExportDetails?.ToString("F2") ?? "", false, false, false, true);
                summary.Children.Add(exportValueFrame);

                summary.Children.Add(CreateFormEntry("Export Detail - Country of Export*", _apiData.phyVerificationModel?.ExportDetCount ?? "", false, false, false, true));

            }
            return summary;
        }

        private StackLayout CreateEmploymentSummary()
        {
            var summary = new StackLayout { Spacing = 16 };
            if (_apiData != null)
            {
                summary.Children.Add(CreateFormEntry("Male*", _apiData.phyVerificationModel?.EmpMale?.ToString() ?? "", false, true, false, true));
                summary.Children.Add(CreateFormEntry("Female*", _apiData.phyVerificationModel?.EmpFemale?.ToString() ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Transgender*", _apiData.phyVerificationModel?.EmpTransgender?.ToString() ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("General*", _apiData.phyVerificationModel?.EmpGEN?.ToString() ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("SC*", _apiData.phyVerificationModel?.EmpSC?.ToString() ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("ST*", _apiData.phyVerificationModel?.EmpST?.ToString() ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("OBC*", _apiData.phyVerificationModel?.EmpOBC?.ToString() ?? "", false, false, false, true));
                summary.Children.Add(CreateFormEntry("Minority*", _apiData.phyVerificationModel?.EmpMinority?.ToString() ?? "", false, false, false, true));

                // ✅ FIXED: Show actual values from API
                summary.Children.Add(CreateFormEntry("Full-Time Employees",
                    _apiData.phyVerificationModel?.FullTime_Emp?.ToString() ?? "0",
                    false, false, false, true));
                summary.Children.Add(CreateFormEntry("Part-Time Employees",
                    _apiData.phyVerificationModel?.PartTime_Emp?.ToString() ?? "0",
                    false, false, false, true));
                summary.Children.Add(CreateFormEntry("Seasonal Employees",
                    _apiData.phyVerificationModel?.Seasonal_Emp?.ToString() ?? "0",
                    false, false, false, true));

                summary.Children.Add(CreateFormEntry("Total Number Of Employees*", _apiData.phyVerificationModel?.TotalEMP?.ToString() ?? "", false, false, false, true));

                var wagesFrame = CreateFormEntry("Average Wages paid per employee per month", _apiData.phyVerificationModel?.AvgWgPaidPerMonth?.ToString("F2") ?? "", false, false, false, true);
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
                summary.Children.Add(CreateFormEntry("Verification Date*", ConvertUnixToDate(_apiData.phyVerificationModel?.VerDate), true, false, false, true));
                summary.Children.Add(CreateFormEntry("Verification Agency Name*", _apiData.phyVerificationModel?.VerAgencyName ?? "", false, false, false, true));

                var enumeratorRemarkFrame = CreateMultilineEntry("Enumerator Remark*", _apiData.phyVerificationModel?.EnumRem ?? "", false, false, true);
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
        private Grid CreateFormEntry(string placeholder, string text = "", bool isDateField = false, bool isFirstField = false, bool forceEditable = false, bool forceReadOnly = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0, 12, 0, 0)
            };

            bool isReadOnly = forceReadOnly || !(_isEditable || forceEditable);

            // Always non-editable fields
            string[] readOnlyFields = new[]
            {
        "Udyam Registration Number", "Address*", "Taluka/Block*", "District*", "State*",
        "Pincode*", "Industry Type*", "Industry Activity*", "Product Description*",
        "Longitude*", "Latitude*", "Geo Tagging ID*", "EDP Completed*",
        "Name of Institute*", "Address of Institute*", "Project Sanctioned Date*",
        "Capital Expenditure*", "Working Capital*", "Own Contribution*", "Total*",
        "Financing Bank*", "Bank Branch*", "Bank Address*", "IFSC code*",
        "Verification Date*", "Verification Agency Name*"
    };

            if (readOnlyFields.Any(f => placeholder.Equals(f, StringComparison.OrdinalIgnoreCase)))
            {
                isReadOnly = true;
            }

            // Material Design 3 colors
            var primaryColor = Color.FromArgb("#1976D2");
            var surfaceColor = !isReadOnly ? Colors.White : Color.FromArgb("#F5F5F5");
            var onSurfaceColor = !isReadOnly ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E");
            var outlineColor = !isReadOnly ? Color.FromArgb("#1976D2") : Color.FromArgb("#BDBDBD");

            // Main container with proper border
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

            // Text container
            var textStack = new VerticalStackLayout
            {
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center
            };

            // Label (always visible, smaller)
            var label = new Label
            {
                Text = placeholder,
                FontSize = 12,
                TextColor = !isReadOnly ? primaryColor : Color.FromArgb("#9E9E9E"),
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 0, 0)
            };

            // Entry field with proper alignment
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

            // Focus effects
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

            // Trailing icon
            if (isDateField)
            {
                var iconButton = new Border
                {
                    BackgroundColor = !isReadOnly ? Color.FromArgb("#E3F2FD") : Color.FromArgb("#F5F5F5"),
                    StrokeThickness = 0,
                    StrokeShape = new RoundRectangle { CornerRadius = 20 },
                    Padding = new Thickness(8),
                    WidthRequest = 40,
                    HeightRequest = 40,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(8, 0, 0, 0)
                };

                var icon = new Label
                {
                    Text = "📅",
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                iconButton.Content = icon;

                if (!isReadOnly)
                {
                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += async (s, e) =>
                    {
                        await iconButton.ScaleTo(0.85, 100);
                        await iconButton.ScaleTo(1, 100);
                        await OpenDatePicker(entry);
                    };
                    iconButton.GestureRecognizers.Add(tapGesture);
                }

                Grid.SetColumn(iconButton, 1);
                mainGrid.Children.Add(iconButton);
            }
            else if (!isReadOnly)
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

        private async Task OpenDatePicker(Entry targetEntry)
        {
            try
            {
                // Parse existing date or use today
                DateTime selectedDate = DateTime.Today;
                if (!string.IsNullOrEmpty(targetEntry.Text))
                {
                    if (DateTime.TryParseExact(targetEntry.Text, "dd-MM-yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                    {
                        selectedDate = parsedDate;
                    }
                }

                // Show native date picker
                var pickedDate = await DisplayPromptDateAsync(selectedDate);

                if (pickedDate.HasValue)
                {
                    targetEntry.Text = pickedDate.Value.ToString("dd-MM-yyyy");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Date picker error: {ex.Message}");
            }
        }

        private async Task<DateTime?> DisplayPromptDateAsync(DateTime initialDate)
        {
            // Create a modal with date picker
            var modal = new AbsoluteLayout
            {
                BackgroundColor = Color.FromArgb("#AA000000"),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            var contentFrame = new Frame
            {
                BackgroundColor = Colors.White,
                CornerRadius = 15,
                Padding = new Thickness(20),
                WidthRequest = 320,
                HasShadow = true
            };

            var datePicker = new DatePicker
            {
                Date = initialDate,
                MinimumDate = new DateTime(1900, 1, 1),
                MaximumDate = DateTime.Today.AddYears(10),
                Format = "dd-MM-yyyy",
                FontSize = 18
            };

            var buttonGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
        },
                ColumnSpacing = 10,
                Margin = new Thickness(0, 20, 0, 0)
            };

            DateTime? result = null;
            var tcs = new TaskCompletionSource<DateTime?>();

            var cancelButton = new Button
            {
                Text = "CANCEL",
                BackgroundColor = Color.FromArgb("#6C757D"),
                TextColor = Colors.White,
                CornerRadius = 10
            };
            cancelButton.Clicked += (s, e) =>
            {
                CloseCurrentModal();
                tcs.TrySetResult(null);
            };

            var okButton = new Button
            {
                Text = "OK",
                BackgroundColor = Color.FromArgb("#4CAF50"),
                TextColor = Colors.White,
                CornerRadius = 10
            };
            okButton.Clicked += (s, e) =>
            {
                result = datePicker.Date;
                CloseCurrentModal();
                tcs.TrySetResult(result);
            };

            Grid.SetColumn(cancelButton, 0);
            Grid.SetColumn(okButton, 1);
            buttonGrid.Children.Add(cancelButton);
            buttonGrid.Children.Add(okButton);

            var contentStack = new StackLayout
            {
                Spacing = 20,
                Children = { datePicker, buttonGrid }
            };

            contentFrame.Content = contentStack;

            AbsoluteLayout.SetLayoutBounds(contentFrame, new Rect(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(contentFrame, AbsoluteLayoutFlags.PositionProportional);

            modal.Children.Add(contentFrame);
            _currentModal = modal;

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(modal, 3);
                Grid.SetRow(modal, 0);
                rootGrid.Children.Add(modal);
            }

            return await tcs.Task;
        }

        // Updated CreateMultilineEntry to be non-editable
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

        private Grid CreateDropdownEntry(string placeholder, string selectedValue = "", bool isDateField = false, bool isFirstField = false, bool isDisabled = false)
        {
            var grid = new Grid
            {
                Margin = isFirstField ? new Thickness(0, 15, 0, 0) : new Thickness(0, 12, 0, 0)
            };

            var primaryColor = Color.FromArgb("#1976D2");
            var surfaceColor = !isDisabled ? Colors.White : Color.FromArgb("#F5F5F5");
            var onSurfaceColor = !isDisabled ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#79747E");
            var outlineColor = !isDisabled ? Color.FromArgb("#1976D2") : Color.FromArgb("#BDBDBD");

            var container = new Border
            {
                BackgroundColor = surfaceColor,
                Stroke = outlineColor,
                StrokeThickness = 1.5,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(16, 4, 16, 4),
                MinimumHeightRequest = 64,
                Shadow = !isDisabled ? new Shadow
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
                TextColor = !isDisabled ? primaryColor : Color.FromArgb("#9E9E9E"),
                FontAttributes = FontAttributes.Bold
            };

            var picker = new Picker
            {
                FontSize = 16,
                TextColor = onSurfaceColor,
                BackgroundColor = Colors.Transparent,
                IsEnabled = !isDisabled,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -4, 0, 0)
            };

            picker.Items.Add("Completed");
            picker.Items.Add("Pending");

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

        private StackLayout CreateSwitchSection(string text, bool isOn, bool enableSwitch = false)
        {
            var container = new Border
            {
                BackgroundColor = Colors.White,
                Stroke = Color.FromArgb("#BDBDBD"),
                StrokeThickness = 1.5,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(16, 12),
                Margin = new Thickness(0, 12, 0, 0),
                Shadow = new Shadow
                {
                    Brush = new SolidColorBrush(Color.FromArgb("#40000000")),
                    Opacity = 0.15f,
                    Radius = 4,
                    Offset = new Point(0, 2)
                }
            };

            var section = new Grid
            {
                ColumnDefinitions =
        {
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Auto }
        },
                ColumnSpacing = 15
            };

            var label = new Label
            {
                Text = text,
                FontSize = 15,
                TextColor = Color.FromArgb("#1C1B1F"),
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center
            };

            var switchControl = new Switch
            {
                IsToggled = isOn,
                OnColor = Color.FromArgb("#4CAF50"),
                ThumbColor = Colors.White,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = enableSwitch
            };

            Grid.SetColumn(label, 0);
            Grid.SetColumn(switchControl, 1);

            section.Children.Add(label);
            section.Children.Add(switchControl);

            container.Content = section;

            var wrapper = new StackLayout();
            wrapper.Children.Add(container);

            return wrapper;
        }

        private StackLayout CreateRadioButton(string text, bool isSelected, bool enableInteraction = false)
        {
            var container = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 5,
                VerticalOptions = LayoutOptions.Center
            };

            var radioCircle = new Frame
            {
                BackgroundColor = isSelected ? Color.FromArgb("#4CAF50") : Colors.Transparent,
                BorderColor = Color.FromArgb("#4CAF50"),
                CornerRadius = 9,
                WidthRequest = 18,
                HeightRequest = 18,
                Padding = 0,
                HasShadow = false,
                VerticalOptions = LayoutOptions.Center,
                ClassId = text
            };

            if (isSelected)
            {
                var innerDot = new BoxView
                {
                    BackgroundColor = Colors.White,
                    WidthRequest = 8,
                    HeightRequest = 8,
                    CornerRadius = 4,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                radioCircle.Content = innerDot;
            }

            var label = new Label
            {
                Text = text,
                FontSize = 12,
                TextColor = enableInteraction ? Colors.Black : Color.FromArgb("#666666"),
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.NoWrap
            };

            container.Children.Add(radioCircle);
            container.Children.Add(label);

            if (enableInteraction)
            {
                // NEW: Add tap gesture to the container
                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += async (s, e) => await OnRadioButtonTappedAsync(radioCircle);
                container.GestureRecognizers.Add(tapGesture);

                // NEW: Also add tap gesture to the radio circle itself
                var radioTapGesture = new TapGestureRecognizer();
                radioTapGesture.Tapped += async (s, e) => await OnRadioButtonTappedAsync(radioCircle);
                radioCircle.GestureRecognizers.Add(radioTapGesture);
            }

            return container;
        }

        private async Task OnRadioButtonTappedAsync(Frame selectedRadio)
        {
            var newStatus = selectedRadio.ClassId; // "Working", "Defunct", or "Non-Traceable"

            System.Diagnostics.Debug.WriteLine($"📍 Radio button tapped: {newStatus}");

            // Check if changing from Working to Defunct or Non-Traceable
            if (_previousVerificationStatus == "Working" && (newStatus == "Defunct" || newStatus == "Non-Traceable"))
            {
                var remarks = await ShowVerificationRemarksModal($"Changing to {newStatus}", "⚠️");
                if (remarks == null)
                {
                    System.Diagnostics.Debug.WriteLine($"📍 User cancelled status change");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"📍 Status change remarks: {remarks}");
                _formState["VerificationStatus_ChangeRemarks"] = remarks;
            }
            // Check if changing back to Working from Defunct/Non-Traceable
            else if ((_previousVerificationStatus == "Defunct" || _previousVerificationStatus == "Non-Traceable") && newStatus == "Working")
            {
                var location = await ShowLocationMapModal();
                if (location == null)
                {
                    System.Diagnostics.Debug.WriteLine($"📍 User cancelled location update");
                    return;
                }

                UpdateLocationFields(location.Value.latitude, location.Value.longitude);

                _formState["VerificationStatus_LocationUpdated"] = true;
                _formState["VerificationStatus_NewLatitude"] = location.Value.latitude;
                _formState["VerificationStatus_NewLongitude"] = location.Value.longitude;
            }

            // ✅ CRITICAL: Save the selected status to formState
            _formState["VerificationStatus_Selected"] = newStatus;
            _previousVerificationStatus = newStatus;

            System.Diagnostics.Debug.WriteLine($"📍 Saved status to formState: {newStatus}");

            // Find parent StackLayout containing all radio buttons
            var parentStack = selectedRadio.Parent?.Parent as StackLayout;
            if (parentStack == null) return;

            // Clear all radio buttons in the group
            foreach (var child in parentStack.Children)
            {
                if (child is StackLayout radioContainer)
                {
                    var radioFrame = radioContainer.Children.FirstOrDefault() as Frame;
                    if (radioFrame != null)
                    {
                        radioFrame.BackgroundColor = Colors.Transparent;
                        radioFrame.Content = null;
                    }
                }
            }

            // Select the tapped radio button
            selectedRadio.BackgroundColor = Color.FromArgb("#4CAF50");
            var innerDot = new BoxView
            {
                BackgroundColor = Colors.White,
                WidthRequest = 8,
                HeightRequest = 8,
                CornerRadius = 4,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            selectedRadio.Content = innerDot;

            System.Diagnostics.Debug.WriteLine($"📍 Radio button UI updated");
        }

        // ADD these helper methods at the end of UnitVerificationPage class
        private Task<string> ShowVerificationRemarksModal(string title, string icon)
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

            var iconLabel = new Label
            {
                Text = icon,
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center
            };

            var headingLabel = new Label
            {
                Text = title,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#333333"),
                HorizontalTextAlignment = TextAlignment.Center
            };

            var remarksEditor = new Editor
            {
                Placeholder = "Enter your remarks here...",
                FontSize = 16,
                HeightRequest = 120,
                BackgroundColor = Color.FromArgb("#F5F5F5")
            };

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
                CloseCurrentModal();
                if (_currentModal != null && this.Content is Grid rootGrid)
                {
                    rootGrid.Children.Remove(_currentModal);
                }
                _currentModal = null;
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
                CloseCurrentModal();
                if (_currentModal != null && this.Content is Grid rootGrid)
                {
                    rootGrid.Children.Remove(_currentModal);
                }
                _currentModal = null;
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
            _currentModal = modal;

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(modal, 3);
                Grid.SetRow(modal, 0);
                rootGrid.Children.Add(modal);
            }

            return tcs.Task;
        }

        private async Task<(double latitude, double longitude)?> ShowLocationMapModal()
        {
            // Request location permissions first
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Permission Denied", "Location permission is required", "OK");
                return null;
            }

            var tcs = new TaskCompletionSource<(double latitude, double longitude)?>();

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
                Padding = new Thickness(20),
                WidthRequest = 360,
                HeightRequest = 500,
                HasShadow = true
            };

            var contentStack = new StackLayout { Spacing = 15 };

            var headingLabel = new Label
            {
                Text = "Confirm Location",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#333333"),
                HorizontalTextAlignment = TextAlignment.Center
            };

            var mapFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#E3F2FD"),
                BorderColor = Color.FromArgb("#2196F3"),
                CornerRadius = 10,
                HeightRequest = 300,
                Padding = 0
            };

            // Get current location
            double currentLat = 0;
            double currentLng = 0;

            Task.Run(async () =>
            {
                try
                {
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Best,
                        Timeout = TimeSpan.FromSeconds(10)
                    });

                    if (location != null)
                    {
                        currentLat = location.Latitude;
                        currentLng = location.Longitude;

                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            var mapWebView = new WebView
                            {
                                HorizontalOptions = LayoutOptions.Fill,
                                VerticalOptions = LayoutOptions.Fill
                            };

                            var htmlSource = new HtmlWebViewSource
                            {
                                Html = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <style>
                            * {{ margin: 0; padding: 0; }}
                            body, html {{ height: 100%; width: 100%; overflow: hidden; }}
                            #map {{ height: 100%; width: 100%; }}
                        </style>
                    </head>
                    <body>
                        <iframe 
                            id='map'
                            frameborder='0' 
                            style='border:0'
                            src='https://www.google.com/maps?q={currentLat},{currentLng}&z=15&output=embed'
                            allowfullscreen>
                        </iframe>
                    </body>
                    </html>"
                            };

                            mapWebView.Source = htmlSource;
                            mapFrame.Content = mapWebView;
                        });
                    }
                }
                catch
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        mapFrame.Content = new Label
                        {
                            Text = "Unable to get current location",
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            TextColor = Color.FromArgb("#666666")
                        };
                    });
                }
            });

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
                CloseCurrentModal();
                if (_currentModal != null && this.Content is Grid rootGrid)
                {
                    rootGrid.Children.Remove(_currentModal);
                }
                _currentModal = null;
                tcs.TrySetResult(null);
            };

            var saveButton = new Button
            {
                Text = "SAVE",
                BackgroundColor = Color.FromArgb("#4CAF50"),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 10,
                HeightRequest = 45
            };
            saveButton.Clicked += async (s, e) =>
            {
                if (currentLat == 0 && currentLng == 0)
                {
                    // Try to get location again
                    try
                    {
                        var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Best,
                            Timeout = TimeSpan.FromSeconds(10)
                        });

                        if (location != null)
                        {
                            currentLat = location.Latitude;
                            currentLng = location.Longitude;
                        }
                    }
                    catch { }
                }

                CloseCurrentModal();
                if (_currentModal != null && this.Content is Grid rootGrid)
                {
                    rootGrid.Children.Remove(_currentModal);
                }
                _currentModal = null;

                if (currentLat != 0 && currentLng != 0)
                {
                    tcs.TrySetResult((currentLat, currentLng));
                }
                else
                {
                    tcs.TrySetResult(null);
                }
            };

            Grid.SetColumn(cancelButton, 0);
            Grid.SetColumn(saveButton, 1);
            buttonGrid.Children.Add(cancelButton);
            buttonGrid.Children.Add(saveButton);

            contentStack.Children.Add(headingLabel);
            contentStack.Children.Add(mapFrame);
            contentStack.Children.Add(buttonGrid);

            contentFrame.Content = contentStack;
            AbsoluteLayout.SetLayoutBounds(contentFrame, new Rect(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(contentFrame, AbsoluteLayoutFlags.PositionProportional);

            modal.Children.Add(contentFrame);
            _currentModal = modal;

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(modal, 3);
                Grid.SetRow(modal, 0);
                rootGrid.Children.Add(modal);
            }

            return await tcs.Task;
        }

        private void UpdateLocationFields(double latitude, double longitude)
        {
            System.Diagnostics.Debug.WriteLine($"🗺️ Updating location fields: Lat={latitude}, Lng={longitude}");

            // Update _apiData object
            if (_apiData?.phyVerificationModel != null)
            {
                _apiData.phyVerificationModel.Latitude = latitude.ToString("F6");
                _apiData.phyVerificationModel.Longitude = longitude.ToString("F6");
                _apiData.phyVerificationModel.GeoTagID = GenerateGeoTagId(latitude, longitude);
            }

            // Update state
            _formState["Longitude"] = longitude.ToString("F6");
            _formState["Latitude"] = latitude.ToString("F6");
            _formState["GeoTaggingID"] = GenerateGeoTagId(latitude, longitude);

            // Find and update UI fields
            UpdateLocationFieldInUI("Longitude", longitude.ToString("F6"));
            UpdateLocationFieldInUI("Latitude", latitude.ToString("F6"));
            UpdateLocationFieldInUI("GeoTaggingID", GenerateGeoTagId(latitude, longitude));

            // Reload map with new coordinates
            RefreshMapWithNewLocation(latitude, longitude);

            System.Diagnostics.Debug.WriteLine($"✅ Location fields and map updated successfully");
        }

        /// <summary>
        /// Helper method to update a specific location field in the UI
        /// </summary>
        private void UpdateLocationFieldInUI(string fieldName, string value)
        {
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    UpdateFieldInStack(stack, fieldName, value);
                }
            }
        }

        /// <summary>
        /// Recursively search and update field in StackLayout
        /// </summary>
        private void UpdateFieldInStack(StackLayout stack, string fieldName, string value)
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
                                string key = NormalizeKey(label.Text);
                                if (key == NormalizeKey(fieldName))
                                {
                                    entry.Text = value;
                                    System.Diagnostics.Debug.WriteLine($"   ✔️ Updated UI field: {fieldName} = {value}");
                                    return;
                                }
                            }
                        }
                    }
                }

                if (item is StackLayout nestedStack)
                {
                    UpdateFieldInStack(nestedStack, fieldName, value);
                }
            }
        }

        /// <summary>
        /// Refresh map with new coordinates
        /// </summary>
        private void RefreshMapWithNewLocation(double latitude, double longitude)
        {
            try
            {
                // Find the map frame in ContentContainer
                Frame mapFrame = null;

                foreach (var child in ContentContainer.Children)
                {
                    if (child is StackLayout stack)
                    {
                        mapFrame = FindMapFrame(stack);
                        if (mapFrame != null) break;
                    }
                }

                if (mapFrame != null)
                {
                    // Create new map WebView with updated coordinates
                    var mapWebView = new WebView
                    {
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill
                    };

                    var htmlSource = new HtmlWebViewSource
                    {
                        Html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no'>
                    <style>
                        * {{ margin: 0; padding: 0; }}
                        body, html {{ height: 100%; width: 100%; overflow: hidden; }}
                        #map {{ height: 100%; width: 100%; }}
                    </style>
                </head>
                <body>
                    <iframe 
                        id='map'
                        frameborder='0' 
                        style='border:0'
                        src='https://www.google.com/maps?q={latitude},{longitude}&z=15&output=embed'
                        allowfullscreen>
                    </iframe>
                </body>
                </html>"
                    };

                    mapWebView.Source = htmlSource;
                    mapFrame.Content = mapWebView;

                    System.Diagnostics.Debug.WriteLine($"   🗺️ Map refreshed with new location");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"   ⚠️ Map frame not found in UI");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"   ❌ Error refreshing map: {ex.Message}");
            }
        }

        /// <summary>
        /// Recursively find map frame in StackLayout hierarchy
        /// </summary>
        private Frame FindMapFrame(StackLayout stack)
        {
            foreach (var child in stack.Children)
            {
                if (child is Frame frame)
                {
                    // Check if this is a map frame (has WebView content)
                    if (frame.Content is WebView)
                    {
                        return frame;
                    }
                }

                if (child is StackLayout nestedStack)
                {
                    var found = FindMapFrame(nestedStack);
                    if (found != null) return found;
                }
            }

            return null;
        }

        private Entry FindEntryByPlaceholder(string placeholder)
        {
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    foreach (var item in stack.Children)
                    {
                        if (item is Grid grid)
                        {
                            var label = grid.Children.OfType<Label>()
                                .FirstOrDefault(l => l.Text?.Replace("*", "").Replace(" ", "").Replace(":", "")
                                    == placeholder.Replace("*", "").Replace(" ", "").Replace(":", ""));

                            if (label != null)
                            {
                                var entry = grid.Children.OfType<Entry>().FirstOrDefault();
                                if (entry != null)
                                {
                                    return entry;
                                }
                            }
                        }
                    }
                }
            }
            return null;
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

        private Grid CreateDualNavigationButtons(
    Func<Task> previousAction,
    Func<Task> nextAction,
    string previousText = "PREVIOUS",
    string nextText = "NEXT")
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

        private async Task SaveBeneficiaryData()
        {
            // Skip API call for Beneficiary section
            //System.Diagnostics.Debug.WriteLine("Beneficiary data saved locally (no API call)");
            await Task.CompletedTask;
        }

        private async Task SaveUnitDetailData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("\n========== SAVE UNIT DETAIL DEBUG ==========");

                var veriStatus = GetVerificationStatusCode();
                System.Diagnostics.Debug.WriteLine($"VeriStatus Code: {veriStatus}");

                // Get editable field values from UI
                var unitName = FindEntryValue("UnitName");
                var unitAddr = FindEditorValue("UpdatedUnitAddress");
                var unitEstDate = ConvertToApiDateFormat(FindEntryValue("UnitEstablishmentDate"));
                var unitGSTNo = FindEntryValue("GSTRegistrationNumber");
                var geoTagID = FindEntryValue("GeoTaggingID");
                var longitude = FindEntryValue("Longitude");
                var latitude = FindEntryValue("Latitude");

                // Try to get UnitLocation from UI first (if editable), then fallback to API data
                var unitLocation = FindEntryValue("UnitLocation");
                if (string.IsNullOrEmpty(unitLocation))
                {
                    unitLocation = _apiData?.phyVerificationModel?.UnitLocation ?? "";
                    System.Diagnostics.Debug.WriteLine($"⚠️ UnitLocation from UI is empty, using API data: {unitLocation}");
                }

                // Get read-only field values directly from API data
                var unitUdyamRegNo = _apiData?.phyVerificationModel?.UnitUdyamRegNo ?? "";
                var agencyCode = _apiData?.applicantData?.AgencyCode ?? "";
                var agencyOfficeName = _apiData?.AgencyOffDetailModel?.AgencyOffName ?? "";

                // Build product description from API data
                var prodDescriptions = new List<string>();
                if (!string.IsNullOrEmpty(_apiData?.applicantData?.ProdDescr))
                    prodDescriptions.Add(_apiData.applicantData.ProdDescr);
                if (!string.IsNullOrEmpty(_apiData?.applicantData?.ProdDescr2))
                    prodDescriptions.Add(_apiData.applicantData.ProdDescr2);
                var productDescription = string.Join(", ", prodDescriptions);

                // Debug print all values
                System.Diagnostics.Debug.WriteLine($"UnitName: '{unitName}'");
                System.Diagnostics.Debug.WriteLine($"UnitAddr: '{unitAddr}'");
                System.Diagnostics.Debug.WriteLine($"UnitEstDate: '{unitEstDate}'");
                System.Diagnostics.Debug.WriteLine($"UnitGSTNo: '{unitGSTNo}'");
                System.Diagnostics.Debug.WriteLine($"UnitUdyamRegNo: '{unitUdyamRegNo}'");
                System.Diagnostics.Debug.WriteLine($"UnitLocation: '{unitLocation}'");
                System.Diagnostics.Debug.WriteLine($"AgencyCode: '{agencyCode}'");
                System.Diagnostics.Debug.WriteLine($"AgencyOfficeName: '{agencyOfficeName}'");
                System.Diagnostics.Debug.WriteLine($"ProductDescription: '{productDescription}'");
                System.Diagnostics.Debug.WriteLine($"GeoTagID: '{geoTagID}'");
                System.Diagnostics.Debug.WriteLine($"Longitude: '{longitude}'");
                System.Diagnostics.Debug.WriteLine($"Latitude: '{latitude}'");
                System.Diagnostics.Debug.WriteLine($"VeriStatus: '{veriStatus}'");

                // Additional debug - check _apiData structure
                System.Diagnostics.Debug.WriteLine($"\n📊 API Data Check:");
                System.Diagnostics.Debug.WriteLine($"phyVerificationModel != null: {_apiData?.phyVerificationModel != null}");
                System.Diagnostics.Debug.WriteLine($"phyVerificationModel.UnitLocation: '{_apiData?.phyVerificationModel?.UnitLocation}'");
                System.Diagnostics.Debug.WriteLine($"applicantData.UnitAddress: '{_apiData?.applicantData?.UnitAddress}'");
                System.Diagnostics.Debug.WriteLine($"applicantData.UnitDistrict: '{_apiData?.applicantData?.UnitDistrict}'");

                var payload = new
                {
                    ApplID = _applId,
                    UnitName = unitName,
                    UnitAddr = unitAddr,
                    VeriStatus = veriStatus,
                    UnitArea = "",
                    UnitEstDate = unitEstDate,
                    UnitGSTNo = unitGSTNo,
                    UnitUdyamRegNo = unitUdyamRegNo,
                    UnitLocation = unitLocation,
                    AgencyCode = agencyCode,
                    AgencyOfficeName = agencyOfficeName,
                    ProductDescription = productDescription,
                    GeoTagID = geoTagID,
                    Longitude = longitude,
                    Latitude = latitude
                };

                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                System.Diagnostics.Debug.WriteLine($"\n📤 Sending payload:\n{jsonPayload}");

                await CallSaveApi("https://115.124.125.153/MobileApp/Insert_UVData_PV", payload);

                // ✅ SAVE current state BEFORE any navigation
                SaveCurrentStepState();

                // Update previous status
                _previousVerificationStatus = GetVerificationStatusText();

                System.Diagnostics.Debug.WriteLine("========== END DEBUG ==========\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                await DisplayAlert("Error", $"Failed to save Unit Detail: {ex.Message}", "OK");
            }
        }


        private void DebugPrintStackFields(StackLayout stack, ref int fieldCount, int depth)
        {
            string indent = new string(' ', depth * 2);

            foreach (var item in stack.Children)
            {
                if (item is Grid grid)
                {
                    // Check for Border wrapper (Material Design style)
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
                                fieldCount++;
                                string fieldType = entry != null ? "Entry" :
                                                 editor != null ? "Editor" :
                                                 picker != null ? "Picker" : "Unknown";
                                string value = entry?.Text ?? editor?.Text ?? picker?.SelectedItem?.ToString() ?? "empty";

                                System.Diagnostics.Debug.WriteLine($"{indent}[{fieldCount}] Label: '{label.Text}' | Type: {fieldType} | Value: '{value}' | Normalized: '{NormalizeKey(label.Text)}'");
                            }
                        }
                    }

                    // Also check for Editor in Border with VerticalStackLayout
                    if (border?.Content is VerticalStackLayout editorVertStack)
                    {
                        var label = editorVertStack.Children.OfType<Label>().FirstOrDefault();
                        var editor = editorVertStack.Children.OfType<Editor>().FirstOrDefault();

                        if (label != null && editor != null)
                        {
                            fieldCount++;
                            System.Diagnostics.Debug.WriteLine($"{indent}[{fieldCount}] Label: '{label.Text}' | Type: Editor (Multiline) | Value: '{editor.Text}' | Normalized: '{NormalizeKey(label.Text)}'");
                        }
                    }
                }

                // Check for Switch
                if (item is StackLayout possibleSwitchWrapper)
                {
                    var switchBorder = possibleSwitchWrapper.Children.OfType<Border>().FirstOrDefault();
                    if (switchBorder?.Content is Grid switchGrid)
                    {
                        var label = switchGrid.Children.OfType<Label>().FirstOrDefault();
                        var switchControl = switchGrid.Children.OfType<Switch>().FirstOrDefault();

                        if (label != null && switchControl != null)
                        {
                            fieldCount++;
                            System.Diagnostics.Debug.WriteLine($"{indent}[{fieldCount}] Label: '{label.Text}' | Type: Switch | Value: {switchControl.IsToggled} | Normalized: '{NormalizeKey(label.Text)}'");
                        }
                    }
                }

                // Recursively check nested StackLayouts
                if (item is StackLayout nestedStack && item != stack)
                {
                    DebugPrintStackFields(nestedStack, ref fieldCount, depth + 1);
                }
            }
        }

        private async Task SaveEDPTrainingData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("\n========== SAVE EDP TRAINING DEBUG ==========");

                // Get editable field value from UI
                var edpPeriod = FindEntryValue("EDPTrainingPeriod");

                // Get read-only fields from API data
                var edpCompleted = _apiData?.edpTrainingModel?.TrDateTo ?? "";
                var instituteName = _apiData?.edpTrainingModel?.EDPTCName ?? "";
                var instituteAddress = _apiData?.edpTrainingModel?.EDPAddress ?? "";

                System.Diagnostics.Debug.WriteLine($"EDPPeriod: '{edpPeriod}'");
                System.Diagnostics.Debug.WriteLine($"EDPCompleted: '{edpCompleted}'");
                System.Diagnostics.Debug.WriteLine($"InstituteName: '{instituteName}'");
                System.Diagnostics.Debug.WriteLine($"InstituteAddress: '{instituteAddress}'");

                var payload = new
                {
                    ApplID = _applId,
                    EDPPeriod = edpPeriod,
                    TrDateTo = edpCompleted,
                    EDPTCName = instituteName,
                    EDPAddress = instituteAddress
                };

                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                System.Diagnostics.Debug.WriteLine($"\n📤 Sending payload:\n{jsonPayload}");

                await CallSaveApi("https://115.124.125.153/MobileApp/Insert_UVData_PV", payload);
                SaveCurrentStepState();

                System.Diagnostics.Debug.WriteLine("========== END DEBUG ==========\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR: {ex.Message}");
                await DisplayAlert("Error", $"Failed to save EDP Training: {ex.Message}", "OK");
            }
        }

        private async Task SaveProjectDetailData()
        {
            // Project detail is read-only, no save needed
            await Task.CompletedTask;
        }

        private async Task FinalSubmit()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("\n========== FINAL SUBMIT DEBUG ==========");
                System.Diagnostics.Debug.WriteLine($"📍 Current DetailsPage Status: {_detailsPageStatus}");

                bool confirm = await DisplayAlert(
                    "Confirm Submission",
                    "Are you sure you want to submit the verification? This action cannot be undone.",
                    "Yes, Submit",
                    "Cancel"
                );

                if (!confirm)
                {
                    System.Diagnostics.Debug.WriteLine("User cancelled final submission");
                    return;
                }

                ShowSaveLoadingOverlay();

                // Step 1: Update isUnitVerDone = true
                var unitVerPayload = new
                {
                    ApplID = _applId,
                    isUnitVerDone = true
                };

                var unitVerJson = JsonSerializer.Serialize(unitVerPayload);
                var unitVerContent = new StringContent(unitVerJson, System.Text.Encoding.UTF8, "application/json");

                System.Diagnostics.Debug.WriteLine($"📤 Updating Unit Verification Status:\n{unitVerJson}");

                var unitVerResponse = await _httpClient.PostAsync(
                    "https://115.124.125.153/MobileApp/Insert_UVData_PV",
                    unitVerContent
                );

                var unitVerResponseContent = await unitVerResponse.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"📥 Unit Ver Response: {unitVerResponseContent}");

                if (!unitVerResponse.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to update unit verification status: {unitVerResponseContent}");
                }

                // Step 2: Get verification details
                string verificationStatus = GetVerificationStatusText();
                string enumRemarks = FindEditorValue("EnumeratorRemark");
                if (string.IsNullOrEmpty(enumRemarks))
                {
                    enumRemarks = "Unit verification completed successfully";
                }

                System.Diagnostics.Debug.WriteLine($"Verification Status: '{verificationStatus}'");
                System.Diagnostics.Debug.WriteLine($"Enumerator Remarks: '{enumRemarks}'");

                // Step 3: Final submission
                var finalSubPayload = new
                {
                    ApplID = _applId,
                    status = verificationStatus,
                    enumRem = enumRemarks
                };

                var finalSubJson = JsonSerializer.Serialize(finalSubPayload, new JsonSerializerOptions { WriteIndented = true });
                var finalSubContent = new StringContent(finalSubJson, System.Text.Encoding.UTF8, "application/json");

                System.Diagnostics.Debug.WriteLine($"📤 Calling Final Submission:\n{finalSubJson}");

                var finalSubResponse = await _httpClient.PostAsync(
                    "https://115.124.125.153/MobileApp/PhyVerFinalSub_TP",
                    finalSubContent
                );

                var finalSubResponseContent = await finalSubResponse.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"📥 Final Submission Response: {finalSubResponseContent}");

                HideSaveLoadingOverlay();

                if (finalSubResponse.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("✅ Final submission successful!");

                    await DisplayAlert("Success", "Unit verification completed and submitted successfully!", "OK");

                    // ✅ Navigate back with the stored status
                    System.Diagnostics.Debug.WriteLine($"📍 Navigating back with status: {_detailsPageStatus}");
                    await NavigateBackToDetailsPageWithRefresh();
                }
                else
                {
                    throw new Exception($"Final submission failed: {finalSubResponseContent}");
                }

                System.Diagnostics.Debug.WriteLine("========== END DEBUG ==========\n");
            }
            catch (Exception ex)
            {
                HideSaveLoadingOverlay();
                System.Diagnostics.Debug.WriteLine($"❌ Final Submit Error: {ex.Message}");
                await DisplayAlert("Error", $"Final submission failed: {ex.Message}", "OK");
            }
        }

        // ✅ Navigate back method
        private async Task NavigateBackToDetailsPageWithRefresh()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"🔄 Navigating back to DetailsPage");
                System.Diagnostics.Debug.WriteLine($"   Status to be used for refresh: {_detailsPageStatus}");

                // Find DetailsPage in navigation stack
                var detailsPage = Navigation.NavigationStack.OfType<DetailsPage>().FirstOrDefault();

                if (detailsPage != null)
                {
                    System.Diagnostics.Debug.WriteLine("✅ Found DetailsPage in navigation stack");

                    // ✅ Call public refresh method directly (no reflection needed)
                    await detailsPage.RefreshDataExternallyAsync();
                    System.Diagnostics.Debug.WriteLine("✅ Refresh method called successfully");

                    // Pop back to DetailsPage
                    await Navigation.PopAsync();
                    System.Diagnostics.Debug.WriteLine("✅ Navigated back to DetailsPage");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ DetailsPage not found in navigation stack");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Navigation error: {ex.Message}");
                await Navigation.PopAsync();
            }
        }

        private async Task SaveProductSalesData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("\n========== SAVE PRODUCT & SALES DEBUG ==========");

                // Get editable field values from UI
                var anlProdVal = FindEntryValue("AnnualProduction-Value");
                var anlSaleVal = FindEntryValue("AnnualSales-Value");
                var exportDetails = FindEntryValue("ExportDetail-value");
                var exportDetCount = FindEntryValue("ExportDetail-CountryofExport");

                // Get product details from Picker
                var productDetails = FindPickerValue("ProductDetailsMainProduct");

                // If picker value is empty or "--select", use API data
                if (string.IsNullOrEmpty(productDetails) || productDetails == "--select")
                {
                    productDetails = _apiData?.applicantData?.ProdDescr2 ?? "";
                }

                System.Diagnostics.Debug.WriteLine($"AnlProdVal: '{anlProdVal}'");
                System.Diagnostics.Debug.WriteLine($"AnlSaleVal: '{anlSaleVal}'");
                System.Diagnostics.Debug.WriteLine($"ProductDetails: '{productDetails}'");
                System.Diagnostics.Debug.WriteLine($"ExportDetails: '{exportDetails}'");
                System.Diagnostics.Debug.WriteLine($"ExportDetCount: '{exportDetCount}'");

                var payload = new
                {
                    ApplID = _applId,
                    AnlProdVal = string.IsNullOrEmpty(anlProdVal) ? 0 : decimal.Parse(anlProdVal),
                    AnlSaleVal = string.IsNullOrEmpty(anlSaleVal) ? 0 : decimal.Parse(anlSaleVal),
                    ProdDetails = productDetails,
                    ExportDetails = string.IsNullOrEmpty(exportDetails) ? 0 : decimal.Parse(exportDetails),
                    ExportDetCount = exportDetCount
                };

                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                System.Diagnostics.Debug.WriteLine($"\n📤 Sending payload:\n{jsonPayload}");

                await CallSaveApi("https://115.124.125.153/MobileApp/Insert_UVData_PV", payload);
                SaveCurrentStepState();

                System.Diagnostics.Debug.WriteLine("========== END DEBUG ==========\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR: {ex.Message}");
                await DisplayAlert("Error", $"Failed to save Product & Sales: {ex.Message}", "OK");
            }
        }

        private async Task SaveEmploymentData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("\n========== SAVE EMPLOYMENT DATA ==========");

                // Collect values from form
                var empMale = FindEntryValue("Male");
                var empFemale = FindEntryValue("Female");
                var empTransgender = FindEntryValue("Transgender");
                var empGEN = FindEntryValue("General");
                var empSC = FindEntryValue("SC");
                var empST = FindEntryValue("ST");
                var empOBC = FindEntryValue("OBC");
                var empMinority = FindEntryValue("Minority");
                var fullTimeEmp = FindEntryValue("Full-TimeEmployees");
                var partTimeEmp = FindEntryValue("Part-TimeEmployees");
                var seasonalEmp = FindEntryValue("SeasonalEmployees");
                var totalEMP = FindEntryValue("TotalNumberOfEmployees");
                var avgWgPaidPerMonth = FindEntryValue("AverageWagespaidperemployeepermonth");

                // Construct payload exactly as backend expects
                var payload = new
                {
                    ApplID = _applId,                                // numeric
                    EmpMale = empMale ?? "0",
                    EmpFemale = empFemale ?? "0",
                    EmpTransgender = empTransgender ?? "0",
                    EmpGEN = empGEN ?? "0",
                    EmpSC = empSC ?? "0",
                    EmpST = empST ?? "0",
                    EmpOBC = empOBC ?? "0",
                    EmpMinority = empMinority ?? "0",
                    FullTime_Emp = fullTimeEmp ?? "0",
                    PartTime_Emp = partTimeEmp ?? "0",
                    Seasonal_Emp = seasonalEmp ?? "0",
                    TotalEMP = string.IsNullOrWhiteSpace(totalEMP) ? 0 : int.Parse(totalEMP),
                    AvgWgPaidPerMonth = avgWgPaidPerMonth ?? "0"
                };

                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                System.Diagnostics.Debug.WriteLine($"\n📤 Sending Employment Payload:\n{jsonPayload}");

                await CallSaveApi("https://115.124.125.153/MobileApp/Insert_UVData_PV", payload);
                SaveCurrentStepState();

                // ✅ Update local model too
                if (_apiData?.phyVerificationModel != null)
                {
                    _apiData.phyVerificationModel.EmpMale = SafeParseInt(empMale);
                    _apiData.phyVerificationModel.EmpFemale = SafeParseInt(empFemale);
                    _apiData.phyVerificationModel.EmpTransgender = SafeParseInt(empTransgender);
                    _apiData.phyVerificationModel.FullTime_Emp = fullTimeEmp;
                    _apiData.phyVerificationModel.PartTime_Emp = partTimeEmp;
                    _apiData.phyVerificationModel.Seasonal_Emp = seasonalEmp;
                    _apiData.phyVerificationModel.TotalEMP = SafeParseInt(totalEMP);
                    _apiData.phyVerificationModel.AvgWgPaidPerMonth = SafeParseDecimal(avgWgPaidPerMonth);
                }

                await DisplayAlert("Success", "Employment details saved successfully.", "OK");
                System.Diagnostics.Debug.WriteLine("✅ Employment details saved successfully.\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR: {ex.Message}");
                await DisplayAlert("Error", $"Failed to save Employment: {ex.Message}", "OK");
            }
        }

        private int SafeParseInt(string s) => int.TryParse(s, out var v) ? v : 0;
        private decimal SafeParseDecimal(string s) => decimal.TryParse(s, out var v) ? v : 0;


        private int ParseInt(string s) => int.TryParse(s, out var v) ? v : 0;
        private decimal ParseDecimal(string s) => decimal.TryParse(s, out var v) ? v : 0;


        private async Task SaveDocumentData()
        {
            try
            {
                // TODO: Implement document upload API
                // Upload documents from _uploadedDocuments list
                //System.Diagnostics.Debug.WriteLine("Document upload to be implemented");
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save documents: {ex.Message}", "OK");
            }
        }

        private async Task SaveVerificationData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("\n========== SAVE VERIFICATION DEBUG ==========");

                // Get verification status from dropdown
                var verStatusDropdown = FindPickerValue("VerificationStatus");
                System.Diagnostics.Debug.WriteLine($"Verification Status Dropdown: '{verStatusDropdown}'");

                // Convert dropdown value to status code
                string veriStatusCode = "";
                if (verStatusDropdown == "Completed")
                {
                    veriStatusCode = "WR"; // Working
                }
                else if (verStatusDropdown == "Pending")
                {
                    veriStatusCode = "PD"; // Pending
                }
                else
                {
                    // Fallback to radio button selection
                    veriStatusCode = GetVerificationStatusCode();
                }

                var verDate = ConvertToApiDateFormat(FindEntryValue("VerificationDate"));
                var verAgencyName = FindEntryValue("VerificationAgencyName");
                var enumRem = FindEditorValue("EnumeratorRemark");
                var isSignBoardIns = FindSwitchValue("ProminentSignBoardinstalled");

                System.Diagnostics.Debug.WriteLine($"VeriStatusCode: '{veriStatusCode}'");
                System.Diagnostics.Debug.WriteLine($"VerDate: '{verDate}'");
                System.Diagnostics.Debug.WriteLine($"VerAgencyName: '{verAgencyName}'");
                System.Diagnostics.Debug.WriteLine($"EnumRem: '{enumRem}'");
                System.Diagnostics.Debug.WriteLine($"IsSignBoardIns: '{isSignBoardIns}'");

                var payload = new
                {
                    ApplID = _applId,
                    VeriStatus = veriStatusCode,
                    VerDate = verDate,
                    VerAgencyName = verAgencyName,
                    EnumRem = enumRem,
                    IsSignBoardIns = isSignBoardIns ? 1 : 0
                };

                var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
                System.Diagnostics.Debug.WriteLine($"\n📤 Sending payload:\n{jsonPayload}");

                await CallSaveApi("https://115.124.125.153/MobileApp/Insert_UVData_PV", payload);
                SaveCurrentStepState();

                System.Diagnostics.Debug.WriteLine("========== END DEBUG ==========\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR: {ex.Message}");
                await DisplayAlert("Error", $"Failed to save Verification: {ex.Message}", "OK");
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

                if (response.IsSuccessStatusCode)
                {
                    //System.Diagnostics.Debug.WriteLine($"API Success: {responseContent}");
                    await DisplayAlert("Success", "Data saved successfully", "OK");
                }
                else
                {
                    throw new Exception($"API Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Network error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Save failed: {ex.Message}");
            }
        }

        private async Task CallSaveApiWithReload(string url, object payload, int stepToReload)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine($"💾 Saving data for step {stepToReload}...");

                // Save current state before API call
                SaveCurrentStepState();

                // Show loading overlay
                ShowSaveLoadingOverlay();

                await CallSaveApi(url, payload);

                // Reload the section with fresh data from API
                LoadApiDataAsync();
                LoadStepContent(stepToReload);

                // Wait for UI to render
                await Task.Delay(200);

                // Restore user-modified values (this overwrites API data with user changes)
                RestoreStepState();

                HideSaveLoadingOverlay();

                //System.Diagnostics.Debug.WriteLine($"✅ Save and reload complete for step {stepToReload}");
            }
            catch (Exception ex)
            {
                HideSaveLoadingOverlay();
                System.Diagnostics.Debug.WriteLine($"❌ Save failed: {ex.Message}");
                throw;
            }
        }

        private void ShowSaveLoadingOverlay()
        {
            var overlay = new AbsoluteLayout
            {
                BackgroundColor = Color.FromArgb("#AA000000"),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };

            var spinner = new ActivityIndicator
            {
                IsRunning = true,
                Color = Colors.White,
                WidthRequest = 50,
                HeightRequest = 50
            };

            AbsoluteLayout.SetLayoutBounds(spinner, new Rect(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(spinner, AbsoluteLayoutFlags.PositionProportional);

            overlay.Children.Add(spinner);

            if (this.Content is Grid rootGrid)
            {
                Grid.SetRowSpan(overlay, 3);
                Grid.SetRow(overlay, 0);
                rootGrid.Children.Add(overlay);
                overlay.ClassId = "SaveLoadingOverlay";
            }
        }

        private void HideSaveLoadingOverlay()
        {
            if (this.Content is Grid rootGrid)
            {
                var overlay = rootGrid.Children.FirstOrDefault(c => c is AbsoluteLayout al && al.ClassId == "SaveLoadingOverlay");
                if (overlay != null)
                {
                    rootGrid.Children.Remove(overlay);
                }
            }
        }

        private string FindEntryValue(string placeholder)
        {
            var normalizedPlaceholder = NormalizeKey(placeholder);
            System.Diagnostics.Debug.WriteLine($"  🔍 FindEntryValue searching for: '{placeholder}' → Normalized: '{normalizedPlaceholder}'");

            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var result = FindEntryInStack(stack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                    {
                        System.Diagnostics.Debug.WriteLine($"  ✅ Found value: '{result}'");
                        return result;
                    }
                }
            }

            // Check formState
            if (_formState.ContainsKey(normalizedPlaceholder))
            {
                var stateValue = _formState[normalizedPlaceholder]?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"  ✅ Found in state: '{stateValue}'");
                return stateValue;
            }

            System.Diagnostics.Debug.WriteLine($"  ❌ NOT FOUND");
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
            System.Diagnostics.Debug.WriteLine($"  🔍 FindEditorValue searching for: '{placeholder}' → Normalized: '{normalizedPlaceholder}'");

            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var result = FindEditorInStack(stack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                    {
                        System.Diagnostics.Debug.WriteLine($"  ✅ Found value: '{result}'");
                        return result;
                    }
                }
            }

            if (_formState.ContainsKey(normalizedPlaceholder))
            {
                var stateValue = _formState[normalizedPlaceholder]?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"  ✅ Found in state: '{stateValue}'");
                return stateValue;
            }

            System.Diagnostics.Debug.WriteLine($"  ❌ NOT FOUND");
            return "";
        }

        private string FindEditorInStack(StackLayout stack, string normalizedPlaceholder)
        {
            foreach (var item in stack.Children)
            {
                if (item is Grid grid)
                {
                    var border = grid.Children.OfType<Border>().FirstOrDefault();

                    // Check for VerticalStackLayout with Editor
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

                    // Also check Grid with VerticalStackLayout
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

        private string GetVerificationStatusText()
        {
            string statusCode = GetVerificationStatusCode();
            return statusCode switch
            {
                "WR" => "Working",
                "DF" => "Defunct",
                "NT" => "Non-Traceable",
                _ => "Working"
            };
        }

        private string FindPickerValue(string placeholder)
        {
            var normalizedPlaceholder = NormalizeKey(placeholder);
            System.Diagnostics.Debug.WriteLine($"  🔍 FindPickerValue searching for: '{placeholder}' → Normalized: '{normalizedPlaceholder}'");

            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var result = FindPickerInStack(stack, normalizedPlaceholder);
                    if (!string.IsNullOrEmpty(result))
                    {
                        System.Diagnostics.Debug.WriteLine($"  ✅ Found picker value: '{result}'");
                        return result;
                    }
                }
            }

            // Check formState
            if (_formState.ContainsKey(normalizedPlaceholder))
            {
                var stateValue = _formState[normalizedPlaceholder]?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"  ✅ Found in state: '{stateValue}'");
                return stateValue;
            }

            // Check with dropdown suffix
            var dropdownKey = normalizedPlaceholder + "_Dropdown";
            if (_formState.ContainsKey(dropdownKey))
            {
                var stateValue = _formState[dropdownKey]?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"  ✅ Found in state with dropdown suffix: '{stateValue}'");
                return stateValue;
            }

            System.Diagnostics.Debug.WriteLine($"  ❌ NOT FOUND");
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

                // Check for standalone Picker
                if (item is Picker standalonePicker && standalonePicker.SelectedItem != null)
                {
                    string key = !string.IsNullOrEmpty(standalonePicker.Title)
                        ? NormalizeKey(standalonePicker.Title)
                        : normalizedPlaceholder;

                    if (key == normalizedPlaceholder)
                    {
                        return standalonePicker.SelectedItem.ToString();
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

        private bool FindSwitchValue(string text)
        {
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    foreach (var item in stack.Children)
                    {
                        if (item is StackLayout switchStack)
                        {
                            var label = switchStack.Children.OfType<Label>().FirstOrDefault(l => l.Text?.Replace(" ", "") == text.Replace(" ", ""));
                            if (label != null)
                            {
                                var switchControl = switchStack.Children.OfType<Switch>().FirstOrDefault();
                                return switchControl?.IsToggled ?? false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private string GetVerificationStatusCode()
        {
            // First, try to get from form state (saved selection)
            if (_formState.ContainsKey("VerificationStatus_Selected"))
            {
                string savedStatus = _formState["VerificationStatus_Selected"]?.ToString();
                System.Diagnostics.Debug.WriteLine($"📍 Found saved status in state: {savedStatus}");

                return savedStatus switch
                {
                    "Working" => "WR",
                    "Defunct" => "DF",
                    "Non-Traceable" => "NT",
                    _ => "WR"
                };
            }

            // Fallback: search in UI
            System.Diagnostics.Debug.WriteLine($"📍 Searching for radio buttons in UI...");
            foreach (var child in ContentContainer.Children)
            {
                if (child is StackLayout stack)
                {
                    var code = SearchRadioButtonsInStack(stack);
                    if (!string.IsNullOrEmpty(code))
                    {
                        System.Diagnostics.Debug.WriteLine($"📍 Found status in UI: {code}");
                        return code;
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine($"📍 No status found, defaulting to WR");
            return "WR"; // Default to Working
        }

        private string SearchRadioButtonsInStack(StackLayout stack)
        {
            foreach (var item in stack.Children)
            {
                if (item is StackLayout radioGroup && radioGroup.Orientation == StackOrientation.Horizontal)
                {
                    foreach (var radioContainer in radioGroup.Children.OfType<StackLayout>())
                    {
                        var radioFrame = radioContainer.Children.FirstOrDefault() as Frame;
                        if (radioFrame != null && radioFrame.BackgroundColor == Color.FromArgb("#4CAF50"))
                        {
                            return radioFrame.ClassId switch
                            {
                                "Working" => "WR",
                                "Defunct" => "DF",
                                "Non-Traceable" => "NT",
                                _ => "WR"
                            };
                        }
                    }
                }

                if (item is StackLayout nestedStack)
                {
                    var code = SearchRadioButtonsInStack(nestedStack);
                    if (!string.IsNullOrEmpty(code))
                        return code;
                }
            }

            return "";
        }

        private string ConvertToApiDateFormat(string dateText)
        {
            if (string.IsNullOrEmpty(dateText)) return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            try
            {
                if (DateTime.TryParseExact(dateText, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date.ToString("yyyy-MM-dd HH:mm:ss.fff");
                }
            }
            catch { }

            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
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