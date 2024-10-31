using MelonLoader;
using System.Diagnostics;

[assembly: MelonInfo(typeof(FlatPlayerCheck.Core), "FlatPlayerCheck", "1.0.1", "SonofForehead", null)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace FlatPlayerCheck
{
    public class Core : MelonMod
    {
        public override void OnEarlyInitializeMelon()
        {
            IsVRRunning();
        }
        public static void IsVRRunning()
        {
            Process[] steamVRs = Process.GetProcessesByName("vrserver");
            if (steamVRs.Length > 0)
            {
                MelonLogger.Warning("SteamVR is running, opening in VR...");
                MelonLoader.MelonAssembly.FindMelonInstance<FlatPlayer.FlatBooter>().Unregister("Unregistering FlatPlayer", true);
            }

            if (steamVRs.Length == 0)
            {
                MelonLogger.Warning("steamVR isn't running, opening in FlatPlayer...");
            }
        }
    }
}