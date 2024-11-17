using HarmonyLib;
using UnityEngine;

namespace MalumMenu;


[HarmonyPatch(typeof(TextBoxTMP), nameof(TextBoxTMP.IsCharAllowed))]
public static class TextBoxTMP_IsCharAllowed
{
    // Postfix patch of TextBoxTMP.IsCharAllowed to allow all characters
    public static bool Prefix(TextBoxTMP __instance, char i, ref bool __result)
    {
        __result = !(i == '\b' || i == '>' || i == '<' || i == ']' || i == '[' || i == '\r'); // Some characters cause issues and must therefore be removed
        return false;
    }
}