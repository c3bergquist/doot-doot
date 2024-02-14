using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DootDoot.Patches
{
    [HarmonyPatch(typeof(NutcrackerEnemyAI))]
    internal class NutcrackerEnemyAIPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void NutcrackerFootstepPatch(NutcrackerEnemyAI __instance)
        {
            __instance.torsoTurnAudio.clip = DootDootModBase.SkeletonSearchSFX;
            Array.Resize(ref __instance.torsoFinishTurningClips, 1);
            __instance.torsoFinishTurningClips[0] = DootDootModBase.SkeletonEndRotationSFX;
        }
    }
}
