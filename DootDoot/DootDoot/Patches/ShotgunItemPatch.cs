using HarmonyLib;
using UnityEngine;

namespace DootDoot.Patches
{
    [HarmonyPatch(typeof(ShotgunItem))]
    internal class ShotgunItemPatch
    {
        [HarmonyPatch("ShootGun")]
        [HarmonyPrefix]
        static void shootGunPatch(ShotgunItem __instance)
        {
            if (__instance.isHeldByEnemy)
            {
                __instance.gunShootSFX = DootDootModBase.DootDootSFX;
            }
        }
    }
}
