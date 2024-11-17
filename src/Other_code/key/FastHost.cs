using AmongUs.Data;
using HarmonyLib;
using Hazel;
using InnerNet;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UIElements;

namespace MH
{
    
    [HarmonyPatch(typeof(ControllerManager), nameof(ControllerManager.Update))]
    class Host
    {
        public static void Postfix()
        {
            if(!AmongUsClient.Instance.AmHost) return;
            // 护盾
            if(KB.GetKeysDown(new[] { KeyCode.LeftControl, KeyCode.H}))
            {
                foreach(PlayerControl player in PlayerControl.AllPlayerControls)
                {
                    var playername = player;
                    PlayerControl.LocalPlayer.RpcProtectPlayer(playername,0);
                }  
            }
            /*if(KB.GetKeysDown(new[] { KeyCode.H}))
            {   
                if(C.NoEnd)
                {
                    C.NoEnd =!C.NoEnd;
                S.Tip("允许结束");
                }
                else
                {
                    C.NoEnd = true;
                    S.Tip("禁止结束");
                }
            }*/
            // 房间基础设置
            if (KB.GetKeysDown(new KeyCode[] { KeyCode.LeftControl, KeyCode.N}) && GameStates.IsLobby)
            {
                S.Sys($"房主:{C.PlayerName}\n地图:{C.Map}\n会议数量/冷却:{C.MeetingsNum}/{C.MeetingsCooldown}\n讨论/投票时间:{C.DiscussionTime}/{C.VotingTime}\n击杀冷却:{C.Killdown}","[房间设置]");
            }
            //懒人模式
            if (KB.GetKeysDown(new[] { KeyCode.LeftShift, KeyCode.F8 }))
            {
                if(C.Lazy)
                {
                    C.Lazy = false;
                    S.Tip("勤快房主");
                }
                else
                {
                    S.Tip("懒人房主");
                    C.Lazy = true;
                }
            }
            //关闭会议
            if (KB.GetKeysDown(new[] { KeyCode.LeftShift, KeyCode.M, KeyCode.Return}))
            {
                if(GameStates.IsMeeting) MeetingHud.Instance.RpcClose();
            }
            //结束
            if(KB.GetKeysDown(new[] { KeyCode.LeftShift, KeyCode.L, KeyCode.Return}))
            {
                GameManager.Instance.RpcEndGame(GameOverReason.HumansDisconnect,false);
            }
            // 重置开始时间
            if (Input.GetKeyDown(KeyCode.C) && GameStartManager.InstanceExists && GameStartManager.Instance.startState == GameStartManager.StartingStates.Countdown)
            {
                GameStartManager.Instance.ResetStartState();
            }
            
            // 开始游戏
            if (Input.GetKeyDown(KeyCode.LeftShift) && GameStartManager.InstanceExists && GameStartManager.Instance.startState == GameStartManager.StartingStates.Countdown)
            {
                GameStartManager.Instance.countDownTimer = 0f;
            }
        }
    }
}