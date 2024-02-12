using BepInEx;
using BepInEx.Logging;
using DootDoot.Patches;
using HarmonyLib;
using UnityEngine;

namespace DootDoot
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class DootDootModBase : BaseUnityPlugin
    {
        private const string modGUID = "8bitRedux.DootDoot";
        private const string modName = "DootDoot";
        private const string modVersion = "0.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static DootDootModBase Instance;

        internal static AssetBundle Bundle;
        internal static AudioClip[] DootDootSFX;
        internal static ManualLogSource MLS;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            MLS = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            MLS.LogInfo("Doot Doot initializing...");

            harmony.PatchAll(typeof(DootDootModBase));
            harmony.PatchAll(typeof(ShotgunItemPatch));

            string folderLocation = Instance.Info.Location.TrimEnd("DootDoot.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(folderLocation + "doot-doot");
            if(Bundle != null)
            {
                DootDootSFX = Bundle.LoadAllAssets<AudioClip>();
                MLS.LogInfo("Successfully loaded doot-doot bundle");
            }
            else
            {
                MLS.LogError("Failed to load doot-doot bundle");
            }
        }
    }
}
