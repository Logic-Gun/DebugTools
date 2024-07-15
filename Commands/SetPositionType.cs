using CommandSystem;
using Exiled.API.Features;
using System;

namespace DebugTools.Commands
{

    [CommandHandler(typeof(ClientCommandHandler))]
    internal class SetPositionType : ICommand
    {
        public bool SanitizeResponse => false;
        public string Command => "setpositiontype";
        public string[] Aliases => ["setpostype", "spt", "positiontype"];
        public string Description => Plugin.Instance.Translation.SetPositionTypeDescription;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);

            if (Plugin.Instance.Config.UseOnlyAdmins && !pl.RemoteAdminAccess) goto Error;
            if (!pl.SessionVariables.ContainsKey("debugtools_localPosition_type")) pl.SessionVariables.Add("debugtools_localPosition_type", LocalPositionType.Point);

            if (arguments.Count == 0)
            {
                response = Plugin.Instance.Translation.SetPositionTypeUsage.Replace("%s%", $"{this.Command} [None, Point, Body]");
                return false;
            }

            if (Enum.TryParse(arguments.At(0), out LocalPositionType localPositionType))
            {
                pl.SessionVariables["debugtools_localPosition_type"] = localPositionType;

                response = Plugin.Instance.Translation.Successfully.Replace("%s%", localPositionType.ToString());
                return true;
            }


            Error:

            response = Plugin.Instance.Translation.Error;
            return false;
        }
    }
}
