using HarmonyLib;
using UnityEngine;
using TMPro;

namespace MH;

[HarmonyPriority(Priority.Low)]
[HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
public static class PingTracker_Update
{
    private static float deltaTime;
    
    [HarmonyPostfix]
    public static void Postfix(PingTracker __instance)
    {
        /*var offset_x = 0f; //从右边缘偏移
        var offset_y = 0f; //从右边缘偏移
        if (HudManager.InstanceExists && HudManager._instance.Chat.chatButton.gameObject.active) offset_x -= 0.8f; //如果有聊天按钮，则有额外的偏移量
        __instance.GetComponent<AspectPosition>().DistanceFromEdge = new Vector3(offset_x, offset_y, 0f);
        */
        __instance.text.text = __instance.ToString();
        __instance.text.text =
            $"";

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = Mathf.Ceil(1.0f / deltaTime);
        __instance.text.text += "<align=center>";
        __instance.text.text += $"<color=#E1E102>Ping: {AmongUsClient.Instance.Ping} FPS: {fps}</color>";
        __instance.text.text += "\n\n\n</align>";
        
    }
    /*public static class VersionShower_Start
    {
        public static void Postfix(VersionShower __instance)
        {
            __instance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            __instance.text.text = $"test";

        }
    }*/
}
