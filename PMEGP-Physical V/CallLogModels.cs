namespace PMEGP_Physical_V
{
    public class CallLogPermission : Permissions.BasePlatformPermission
    {
#if ANDROID
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
            new List<(string androidPermission, bool isRuntime)>
            {
                (Android.Manifest.Permission.ReadCallLog, true)
            }.ToArray();
#endif
    }

    public class CallLogEntry
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string CallType { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }

        public string FormattedDate => DateTime.ToString("dd-MM-yyyy");
        public string FormattedTime => DateTime.ToString("hh:mm tt");
        public string FormattedDuration
        {
            get
            {
                if (Duration == 0) return "0s";
                var minutes = Duration / 60;
                var seconds = Duration % 60;
                return minutes > 0 ? $"{minutes}m {seconds}s" : $"{seconds}s";
            }
        }
        public string CallTypeIcon => CallType switch
        {
            "Incoming" => "📞",
            "Outgoing" => "📱",
            "Missed" => "❌",
            "Rejected" => "🚫",
            _ => "📞"
        };
    }
}