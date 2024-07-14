using Exiled.API.Interfaces;

namespace DebugTools
{
    public class Translation : ITranslation
    {
        public string DebugDescription { get; set; } = "This enabled the debug tools on your player.";
        public string SetPositionTypeDescription { get; set; } = "This command allows you to change the display type of the local position.";
        public string SetPositionTypeUsage { get; set; } = "Usage: %s%";
        public string Error { get; set; } = "An error has occurred, please try again.";
        public string ErrorEmpty { get; set; } = "Empty value";
        public string Successfully { get; set; } = "You have successfully changed the state to: %s%.";
        public string PointInCursor { get; set; } = "<color=yellow>The local position of the point in the cursor: %s%</color>";
    }
}
