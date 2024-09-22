
using System.Text.RegularExpressions;
using Beebyte.Obfuscator;
using HarmonyLib;
using UnityEngine;
namespace MH;

[HarmonyPatch(typeof(ChatController), nameof(ChatController.SendFreeChat))]
public static class ChatController_SendFreeChat
{
    public static string Command = "";
    public static bool Prefix(ChatController __instance)
    {
        string text = __instance.freeChatField.Text;
        if(text == "/music")
            if(C.Music)
            {
                C.Music = false;
                S.Com("已开启音乐");
            }
            else
            {
                C.Music = true;
                S.Com("已关闭音乐");
            }


        //改名
        if(C.Rname == true)
        {
            S.RN(text); 
            C.Rname = false;
            S.Com("<color=#951716>已改名</color>");
        }
        //发消息
        else
        S.Chat(text); // 发送原始消息

        return false; // 阻止原方法执行
    }
}