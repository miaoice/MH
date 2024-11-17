using HarmonyLib;

namespace MH;

[HarmonyPatch]
public class EngGamePatch
{
    [HarmonyPatch(typeof(EndGameNavigation), nameof(EndGameNavigation.ShowDefaultNavigation)), HarmonyPostfix]
    public static void ShowDefaultNavigation_Postfix(EndGameNavigation __instance)
    {
        new LateTask(__instance.NextGame, 2f, "Auto End Game");
        __instance.CoJoinGame();
    }
}