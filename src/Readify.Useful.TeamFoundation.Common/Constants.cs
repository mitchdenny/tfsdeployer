using System.Diagnostics;

namespace Readify.Useful.TeamFoundation.Common
{
    internal static class Constants
    {
        public static TraceSwitch CommonSwitch = new TraceSwitch("Readify.Useful.TeamFoundation.Common", "Trace switch for the common components of Team Foundation", TraceLevel.Warning.ToString());
        public const string NotificationServiceHost = "NotificationServiceHost";
        public const string ServiceHelper = "ServiceHelper";
    }
}
