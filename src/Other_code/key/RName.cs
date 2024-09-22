using AmongUs.Data;
using HarmonyLib;
using Hazel;
using InnerNet;
using UnityEngine;

namespace MH
{
    [HarmonyPatch(typeof(ControllerManager), nameof(ControllerManager.Update))]
    class Rname
    {

        public static void Postfix()
        {
            if(!GameStates.IsHost)return;
            if(KB.GetKeysDown(new[] { KeyCode.F6 }))
            {
                if(C.OldName==null)
                {
                    Rester();
                }
                else
                {
                    if(C.Rname==true)
                    {
                        C.Rname=false;
                        S.Tip("已取消改名");
                    }
                    else
                    {
                        C.Rname=true;
                        S.Tip("输入要改的名字");
                    }
                }
            }
            if(!GameStates.IsLobby)
            {
                C.OldName = null;
            }
        }
        public static void Rester()
        {
            
            C.OldName = C.Name;
            S.RN(C.OldName);
            S.Tip("初始化完成\n请再试一遍");
        }
    }
}
