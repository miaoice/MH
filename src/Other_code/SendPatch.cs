
using Discord;
using Epic.OnlineServices;
using HarmonyLib;
using Hazel;
using Il2CppSystem.Collections.Immutable;
using UnityEngine;
using UnityEngine.UIElements;

namespace MH;

public class S
{
    //退出房间的左下角提示
    public static void Tip(string text)
    {
        if (DestroyableSingleton<HudManager>._instance) 
        HudManager.Instance.Notifier.AddDisconnectMessage(text);
    }

    //禁止发送网站的那个提示
    public static void Com(string text)
    {
        if (DestroyableSingleton<HudManager>._instance) 
        HudManager.Instance.Chat.AddChatWarning(text);
    }
    //消息(全员可见且受树懒限制)
    public static void Chat(string text)
    {
        if (DestroyableSingleton<HudManager>._instance) 
        PlayerControl.LocalPlayer.RpcSendChat(text);
    }
    //sys
    public static void Sys(string text,string title)
    {
        var name = PlayerControl.LocalPlayer.Data.PlayerName;
        if(GameStates.IsHost)
        {
            if(title==null || title=="")
            S.RN("<color=#4EBE7E>[Mod]</color>");
            else
            S.RN("<color=#4EBE7E>" + title + "</color>");
            if (DestroyableSingleton<HudManager>._instance) 
                PlayerControl.LocalPlayer.RpcSendChat(text);
            S.RN(name);
        }
        else
        {
            if(title==null || title=="")
            PlayerControl.LocalPlayer.RpcSendChat("[Mod]\n" + text);
            else
            PlayerControl.LocalPlayer.RpcSendChat(title + "\n" + text);
        }
    }
    //改名
    public static void RN(string text)
    {
        if(AmongUsClient.Instance.AmHost)
        {
            PlayerControl.LocalPlayer.RpcSetName(text);
        }
        else
            Com("无法改名");
    }
}
