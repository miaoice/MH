using AmongUs.GameOptions;
using HarmonyLib;
using Hazel;
using Il2CppSystem.Linq;
using System.Threading.Tasks;
using InnerNet;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Rewired.Utils.Classes.Data;

namespace MH
{
    
    [HarmonyPatch(typeof(ControllerManager), nameof(ControllerManager.Update))]
    class Normal
    {
        
        public static void Postfix()
        {
            //愚人节
            if(KB.GetKeysDown(new[] { KeyCode.LeftControl, KeyCode.Y}))
            {
                if(C.AF==0)       {  C.AF=1;   S.Tip("马模式");        }
                else if(C.AF==1)  {  C.AF=2;   S.Tip("长颈鹿模式");    }
                else if(C.AF==2)  {  C.AF=0;   S.Tip("愚人节已关闭");  }
            }
            // 强制显示聊天框
            if (KB.GetKeysDown(new[] { KeyCode.Return, KeyCode.C, KeyCode.LeftShift}))
            {
                HudManager.Instance.Chat.SetVisible(true);
            }
            //-------------------------

            //作弊模式
            if (KB.GetKeysDown(new[] { KeyCode.F1 }))
            {
                if (!C.CDS)
                {
                    C.CDS = true;
                    S.Tip("作弊已开启");
                    /*align=left/center/right*/
                }else{
                    C.CDS = !C.CDS;
                    S.Tip("作弊已关闭");
                    C.MT = !C.MT;
                    C.MNB = false;
                }
            }
            //地图
            if (KB.GetKeysDown(new[] { KeyCode.F4 }) && C.CDS)
            {
                if(C.MT)
                {
                    C.MT = !C.MT;
                    S.Tip("已关闭");
                } 
                else
                {
                    C.MT = true;
                    S.Tip("已开启地图");
                }
            }
            if(C.CDS)
            {
                //右键传送
                if (Input.GetMouseButtonDown(1)) 
                {
                    PlayerControl.LocalPlayer.NetTransform.RpcSnapTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
            //内鬼CD => 0s
            if (Input.GetKeyDown(KeyCode.F2) && C.CDS)
            {
                PlayerControl.LocalPlayer.Data.Object.SetKillTimer(0f);
                S.Tip("已将内鬼CD重置为0");
            }
            //做完任务
            if (Input.GetKeyDown(KeyCode.F3) && C.CDS)
            {
                foreach (var task in PlayerControl.LocalPlayer.myTasks)
                PlayerControl.LocalPlayer.RpcCompleteTask(task.Id);
                S.Tip("已完成所有任务");
            }
            if(KB.GetKeysDown(new[] { KeyCode.LeftControl, KeyCode.M }))
            {
                
            }
        }

        private static void WaitFunctions(int v)
        {
            throw new NotImplementedException();
        }
    }
}
