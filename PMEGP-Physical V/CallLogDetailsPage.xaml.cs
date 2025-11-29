namespace PMEGP_Physical_V
{
    public partial class CallLogDetailsPage : ContentPage
    {
        private readonly PreVerApplicant _applicant;
        private readonly List<CallLogEntry> _callLogs;
        private double screenWidth;
        private double screenHeight;
        private double scaleFactor;
        private bool isSmallScreen;
        private bool isTablet;

        public CallLogDetailsPage(PreVerApplicant applicant, List<CallLogEntry> callLogs)
        {
            InitializeComponent();
            _applicant = applicant;
            _callLogs = callLogs;

            InitializeResponsiveDesign();
            LoadApplicantInfo();
            DisplayCallLogs();
        }

        private void InitializeResponsiveDesign()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            screenWidth = displayInfo.Width / displayInfo.Density;
            screenHeight = displayInfo.Height / displayInfo.Density;
            scaleFactor = Math.Max(0.7, Math.Min(1.3, screenWidth / 400.0));
            isSmallScreen = screenWidth < 500;
            isTablet = screenWidth >= 600;
        }

        private void LoadApplicantInfo()
        {
            ApplicantNameLabel.Text = $"Name: {_applicant.Name}";
            PhoneNumberLabel.Text = $"Phone: {_applicant.PhoneNumber}";
            TotalCallsLabel.Text = $"Total Calls: {_callLogs.Count}";
        }

        private void DisplayCallLogs()
        {
            CallLogsContainer.Children.Clear();
            CallLogsContainer.RowDefinitions.Clear();
            CallLogsContainer.RowSpacing = GetResponsiveSpacing(isSmallScreen ? 8 : 10);

            for (int i = 0; i < _callLogs.Count; i++)
            {
                CallLogsContainer.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var callLogCard = CreateCallLogCard(_callLogs[i]);
                Grid.SetRow(callLogCard, i);
                CallLogsContainer.Children.Add(callLogCard);
            }
        }

        private Frame CreateCallLogCard(CallLogEntry callLog)
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

            var mainGrid = new Grid();
            var borderWidth = GetResponsiveSpacing(isSmallScreen ? 6 : 8);
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(borderWidth) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var leftBorderColor = callLog.CallType switch
            {
                "Incoming" => "#4CAF50",
                "Outgoing" => "#2196F3",
                "Missed" => "#F44336",
                "Rejected" => "#FF9800",
                _ => "#9E9E9E"
            };

            var leftBorder = new BoxView
            {
                BackgroundColor = Color.FromArgb(leftBorderColor),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill
            };
            Grid.SetColumn(leftBorder, 0);

            var contentGrid = new Grid
            {
                Padding = GetResponsivePadding(isSmallScreen ? 12 : 15, isSmallScreen ? 10 : 15),
                RowSpacing = GetResponsiveSpacing(isSmallScreen ? 4 : 6)
            };

            for (int i = 0; i < 4; i++)
            {
                contentGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            var typeRow = CreateDetailRow("Call Type:", $"{callLog.CallTypeIcon} {callLog.CallType}");
            var dateRow = CreateDetailRow("Date:", callLog.FormattedDate);
            var timeRow = CreateDetailRow("Time:", callLog.FormattedTime);
            var durationRow = CreateDetailRow("Duration:", callLog.FormattedDuration);

            Grid.SetRow(typeRow, 0);
            Grid.SetRow(dateRow, 1);
            Grid.SetRow(timeRow, 2);
            Grid.SetRow(durationRow, 3);

            contentGrid.Children.Add(typeRow);
            contentGrid.Children.Add(dateRow);
            contentGrid.Children.Add(timeRow);
            contentGrid.Children.Add(durationRow);

            Grid.SetColumn(contentGrid, 1);

            mainGrid.Children.Add(leftBorder);
            mainGrid.Children.Add(contentGrid);

            cardFrame.Content = mainGrid;

            return cardFrame;
        }

        private Grid CreateDetailRow(string label, string value)
        {
            var grid = new Grid();
            var labelWidth = isSmallScreen ? 90 : (isTablet ? 120 : 100);
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(labelWidth * scaleFactor) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var baseFontSize = isSmallScreen ? 12 : (isTablet ? 15 : 13);

            var labelControl = new Label
            {
                Text = label,
                FontSize = GetResponsiveFontSize(baseFontSize),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#666666"),
                VerticalOptions = LayoutOptions.Start
            };

            var valueControl = new Label
            {
                Text = value,
                FontSize = GetResponsiveFontSize(baseFontSize),
                FontAttributes = FontAttributes.None,
                TextColor = Colors.Black,
                VerticalOptions = LayoutOptions.Start
            };

            Grid.SetColumn(labelControl, 0);
            Grid.SetColumn(valueControl, 1);

            grid.Children.Add(labelControl);
            grid.Children.Add(valueControl);

            return grid;
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