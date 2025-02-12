using System.Reflection;
using UnityEngine;

namespace HoshinoLabs.ClientSimPatcher {
    static class ClientSimPatcher {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void OnSubsystemRegistration() {
            var playerObjectList = typeof(VRC.SDK3.ClientSim.ClientSimNetworkingUtilities)
                .GetField("_playerObjectList", BindingFlags.Static | BindingFlags.NonPublic);
            if (playerObjectList != null) {
                playerObjectList.SetValue(null, null);
            }
        }
    }
}
