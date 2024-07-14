using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DebugTools
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;

        [Description("Command can use only admins?")]
        public bool UseOnlyAdmins { get; set; } = false;
    }
}
