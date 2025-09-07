using MelonLoader;
using System.Diagnostics;

[assembly: MelonInfo(typeof(FlatPlayerCheck.Core), "FlatPlayerCheckOculus", "1.0.1", "NitricAcidDev", null)]
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
            Process[] DashVR = Process.GetProcessesByName("OculusDash");
            if (DashVR.Length > 0)
            {
                MelonLogger.Warning("OculusDash is running, opening in VR...");
                MelonLoader.MelonAssembly.FindMelonInstance<FlatPlayer.FlatBooter>().Unregister("Unregistering FlatPlayer", true);
            }

            if (DashVR.Length == 0)
            {
                MelonLogger.Warning("OculusDash isn't running, opening in FlatPlayer...");
            }
        }
    }
}