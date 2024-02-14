using HarmonyLib;
using LCSoundTool;
using UnityEngine;

namespace DootDoot.Patches
{
    [HarmonyPatch(typeof(ShotgunItem))]
    internal class ShotgunItemPatch
    {
        [HarmonyPatch("ShootGun")]
        [HarmonyPrefix]
        static void ShootGunPatch(ShotgunItem __instance)
        {
            if (__instance.isHeldByEnemy)
            {
                SoundTool.ReplaceAudioClip("ShotgunBlast", DootDootModBase.DootDootSFX);
                SoundTool.ReplaceAudioClip("ShotgunBlast2", DootDootModBase.DootDootSFX);
            }
            else
            {
                SoundTool.RestoreAudioClip("ShotgunBlast");
                SoundTool.RestoreAudioClip("ShotgunBlast2");
            }
        }
    }
}
