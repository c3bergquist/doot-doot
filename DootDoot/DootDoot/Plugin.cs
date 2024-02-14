using BepInEx;
using BepInEx.Logging;
using DootDoot.Patches;
using HarmonyLib;
using LCSoundTool;
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

        internal static AudioClip DootDootSFX;
        internal static AudioClip SkeletonEndRotationSFX;
        internal static AudioClip SkeletonSearchSFX;
        internal static AudioClip SkeletonStep1SFX;
        internal static AudioClip SkeletonStep2SFX;
        internal static AudioClip SkeletonStep3SFX;

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
            harmony.PatchAll(typeof(NutcrackerEnemyAIPatch));

            string folderLocation = Instance.Info.Location.TrimEnd("DootDoot.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(folderLocation + "doot-doot");
            if (Bundle != null)
            {
                MLS.LogInfo("Successfully loaded doot-doot bundle");
                LoadBundleAssets();
            }
            else
            {
                MLS.LogError("Failed to load doot-doot bundle");
            }
        }

        void Start()
        {
            if (Bundle.LoadAsset<AudioClip>("skeleton-step-1") != null)
            {
                SkeletonStep1SFX = Bundle.LoadAsset<AudioClip>("skeleton-step-1");
                SoundTool.ReplaceAudioClip("BootStomp1", SkeletonStep1SFX);
                MLS.LogInfo("Successfully loaded skeleton step audio asset");
            }
            else
            {
                MLS.LogError("Failed to load skeleton step audio asset");
            }

            if (Bundle.LoadAsset<AudioClip>("skeleton-step-2") != null)
            {
                SkeletonStep2SFX = Bundle.LoadAsset<AudioClip>("skeleton-step-2");
                SoundTool.ReplaceAudioClip("BootStomp2", SkeletonStep2SFX);
                MLS.LogInfo("Successfully loaded skeleton step audio asset");
            }
            else
            {
                MLS.LogError("Failed to load skeleton step audio asset");
            }

            if (Bundle.LoadAsset<AudioClip>("skeleton-step-3") != null)
            {
                SkeletonStep3SFX = Bundle.LoadAsset<AudioClip>("skeleton-step-3");
                SoundTool.ReplaceAudioClip("BootStomp3", SkeletonStep3SFX);
                MLS.LogInfo("Successfully loaded skeleton step audio asset");
            }
            else
            {
                MLS.LogError("Failed to load skeleton step audio asset");
            }
        }

        static void LoadBundleAssets()
        {
            if (Bundle.LoadAsset<AudioClip>("doot-doot") != null)
            {
                DootDootSFX = Bundle.LoadAsset<AudioClip>("doot-doot");
                MLS.LogInfo("Successfully loaded doot-doot audio asset");
            }
            else
            {
                MLS.LogError("Failed to load doot-doot audio asset");
            }

            if (Bundle.LoadAsset<AudioClip>("skeleton-end-rotation") != null)
            {
                SkeletonEndRotationSFX = Bundle.LoadAsset<AudioClip>("skeleton-end-rotation");
                MLS.LogInfo("Successfully loaded skeleton end rotation audio asset");
            }
            else
            {
                MLS.LogError("Failed to load skeleton end rotation audio asset");
            }

            if (Bundle.LoadAsset<AudioClip>("skeleton-search") != null)
            {
                SkeletonSearchSFX = Bundle.LoadAsset<AudioClip>("skeleton-search");
                MLS.LogInfo("Successfully loaded skeleton search audio asset");
            }
            else
            {
                MLS.LogError("Failed to load skeleton search audio asset");
            }
        }
    }
}
