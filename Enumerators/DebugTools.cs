using Exiled.API.Features;
using MEC;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DebugTools.Enumerators
{
    public static class DebugTools
    {
        public static IEnumerator<float> Start()
        {
            while (!Round.IsEnded)
            {
                Vector3? localPosition;
                StringBuilder sb;

                foreach (var player in Player.List.Where(r => r.IsAlive))
                {
                    if (!player.SessionVariables.ContainsKey("debugtools_enabled")) continue;
                    if (!player.SessionVariables.ContainsKey("debugtools_localPosition_type")) continue;

                    localPosition = null;

                    if (player.CurrentRoom != null)
                    {
                        switch ((LocalPositionType)player.SessionVariables["debugtools_localPosition_type"])
                        {
                            case LocalPositionType.Point:
                            {
                                if (Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out RaycastHit hitinfo))
                                {
                                    localPosition = player.CurrentRoom.Transform.InverseTransformPoint(hitinfo.point);
                                }

                                break;
                            }

                            case LocalPositionType.Body:
                            {
                                localPosition = player.CurrentRoom.Transform.InverseTransformPoint(player.Position);

                                break;
                            }

                            case LocalPositionType.None:
                            default:
                            {
                                continue;
                            }
                        }
                    }

                    sb = new();

                    sb.Append(Plugin.Instance.Translation.PointInCursor);
                    sb.Replace("%s%", player.CurrentRoom.Type.ToString() ?? Plugin.Instance.Translation.ErrorEmpty);
                    sb.Replace("%s%", localPosition.ToString() ?? Plugin.Instance.Translation.ErrorEmpty);

                    player.Broadcast(1, sb.ToString(), shouldClearPrevious: true);
                }

                yield return Timing.WaitForSeconds(0.25f);
            }

            yield break;
        }
    }
}
