using MEC;

namespace DebugTools.Events
{
    internal class ServerHandler
    {
        public void OnWaitingForPlayers()
        {
            Timing.RunCoroutine(Enumerators.DebugTools.Start());
        }
    }
}
