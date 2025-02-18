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

            var lastImageRequest = typeof(VRC.SDK3.Image.VRCImageDownloader.ImageDownloader)
                .GetField("_lastImageRequest", BindingFlags.Static | BindingFlags.NonPublic);
            if (lastImageRequest != null) {
                lastImageRequest.SetValue(null, -5f);
            }

            var lastStringRequest = typeof(VRC.SDK3.StringLoading.VRCStringDownload)
                .GetField("_lastStringRequest", BindingFlags.Static | BindingFlags.NonPublic);
            if (lastStringRequest != null) {
                lastStringRequest.SetValue(null, -5f);
            }
        }
    }
}
