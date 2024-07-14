using DebugTools.Events;
using Exiled.API.Features;
using System;

namespace DebugTools
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "Debug Tools";
        public override string Author => "Logic_Gun";
        //public override Version RequiredExiledVersion => new(9, 0, 0);
        public override Version Version => new(1, 0, 1);

        public static Plugin Instance;

        private ServerHandler _serverHandler;

        public override void OnEnabled()
        {
            Instance = this;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;

            base.OnDisabled();
        }

        protected override void SubscribeEvents()
        {
            _serverHandler = new();

            Exiled.Events.Handlers.Server.WaitingForPlayers += _serverHandler.OnWaitingForPlayers;

            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += _serverHandler.OnWaitingForPlayers;

            _serverHandler = null;

            base.UnsubscribeEvents();
        }
    }
}
