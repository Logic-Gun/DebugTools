using CommandSystem;
using Exiled.API.Features;
using System;

namespace DebugTools.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class Debug : ICommand
    {
        public bool SanitizeResponse => false;

        public string Command => "debugtool";
        public string[] Aliases => ["dt", "debug", "tools"];
        public string Description => Plugin.Instance.Translation.DebugDescription;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);

            if (pl == null) goto Error;

            if (Plugin.Instance.Config.UseOnlyAdmins && !pl.RemoteAdminAccess) goto Error;
            if (!pl.SessionVariables.ContainsKey("debugtools_enabled")) pl.SessionVariables.Add("debugtools_enabled", false);
            if (!pl.SessionVariables.ContainsKey("debugtools_localPosition_type")) pl.SessionVariables.Add("debugtools_localPosition_type", LocalPositionType.Point);

            pl.SessionVariables["debugtools_enabled"] = !(bool)pl.SessionVariables["debugtools_enabled"];

            response = Plugin.Instance.Translation.Successfully.Replace("%s%", ((bool)pl.SessionVariables["debugtools_enabled"]).ToString());
            return true;




            Error:

            response = Plugin.Instance.Translation.Error;
            return false;
        }
    }
}
