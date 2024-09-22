using System.Collections.Generic;
using HarmonyLib;
using InnerNet;

namespace MH;

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
public static class PlayerJoined
{
    public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ClientData client)
    {
        S.Tip($"<color=#EE9D26>{client.PlayerName} </color><color=#1F36A2>加入房间</color>\n<color=#C06BE8></color>");
        S.Com($"<align=center><size=80%><color=#EE9D26>{client.PlayerName} </color>\n<size=75%><color=#FF1919>好友代码\n</color><color=#C06BE8></size><size=60%>{client.FriendCode}\n<size=75%><color=#FF1919>PUID\n</color></size><size=60%>{client.ProductUserId}</size></color></size></align>");
        if(GameData.Instance.PlayerCount == 14)
        {
            S.Tip($"15人了,快催房主开始一起 Van♂耍 吧)");
        }
    }
}






//大厅音乐
[HarmonyPatch(typeof(LobbyBehaviour))]
public class LobbyBehaviourPatch
{
    [HarmonyPatch(nameof(LobbyBehaviour.Update)), HarmonyPostfix]
    public static void Update_Postfix(LobbyBehaviour __instance)
    {
        System.Func<ISoundPlayer, bool> lobbybgm = x => x.Name.Equals("MapTheme");
        ISoundPlayer MapThemeSound = SoundManager.Instance.soundPlayers.Find(lobbybgm);
        if (C.Music)
        {
            if (MapThemeSound == null) return;
            SoundManager.Instance.StopNamedSound("MapTheme");
        }
        else
        {
            if (MapThemeSound != null) return;
            SoundManager.Instance.CrossFadeSound("MapTheme", __instance.MapTheme, 0.5f);
        }
    }
}