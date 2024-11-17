
using System.Text.RegularExpressions;
using Beebyte.Obfuscator;
using HarmonyLib;
using UnityEngine;
namespace MH;

[HarmonyPatch(typeof(ChatController), nameof(ChatController.SendFreeChat))]
public static class ChatController_SendFreeChat
{
    private static string Text;
    public static bool Prefix(ChatController __instance)
    {
        Text = __instance.freeChatField.Text;
        if(Text == "/music")
        {
            Music();
            return false;
        }


        //改名
        if(C.Rname == true)
        {
            Rname();
        }
        //发消息
        else
        S.Chat(Text); // 发送原始消息

        return false; // 阻止原方法执行
    }
    private static void Music()
    {
        if(C.Music)
        {
            C.Music = !C.Music;   S.Com("已开启音乐");
        }else{
            C.Music = true;   S.Com("已关闭音乐.");
        }
    }
    private static void Rname()
    {
            S.RN(Text); 
            C.Rname = false;
            S.Com("<color=#951716>已改名</color>");
    }
    
}