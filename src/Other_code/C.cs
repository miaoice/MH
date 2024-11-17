using Hazel;
using InnerNet;
using AmongUs.Data;
using System;
using AmongUs.GameOptions;

namespace MH;
public static class C
{
    //是否开启作弊
    public static bool CDS = false;
    //无冷却+无限时间
    public static bool MNB = false;
    //房主改颜色
    public static int Color = 0;
    //小地图
    public static bool MT = false;
    //自动开始
    public static bool Lazy = false; 
    //更改名字
    public static bool Rname = false;
    //原名
    public static string OldName = null;
    //倒计时开始时间
    public static float timer = 600f;
    //愚人节
    public static int AF = 0;
    //关闭音乐
    public static bool Music = false;
    //不结束
    public static bool NoEnd = false;
    //文字变量----------------------------
    
    //内鬼

    public static string ImpostorsNum=> "";//好像我不会)
    public static string ImpostorLightMod=> GameOptionsManager.Instance.currentNormalGameOptions.ImpostorLightMod.ToString();
    public static string Killdown=> GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown.ToString();    
    public static string KillDistance = "";
    //船员
    public static string CrewLightMod=> GameOptionsManager.Instance.currentNormalGameOptions.CrewLightMod.ToString();    
    public static string NumCommonTasks=> GameOptionsManager.Instance.currentNormalGameOptions.NumCommonTasks.ToString();
    public static string NumLongTasks=> GameOptionsManager.Instance.currentNormalGameOptions.NumLongTasks.ToString();
    public static string NumShortTasks=> GameOptionsManager.Instance.currentNormalGameOptions.NumShortTasks.ToString();

    //会议
    public static string MeetingsNum=> GameOptionsManager.Instance.currentNormalGameOptions.NumEmergencyMeetings.ToString();
    public static string MeetingsCooldown=> GameOptionsManager.Instance.currentNormalGameOptions.EmergencyCooldown.ToString();
    public static string DiscussionTime=> GameOptionsManager.Instance.currentNormalGameOptions.DiscussionTime.ToString();
    public static string VotingTime=> GameOptionsManager.Instance.currentNormalGameOptions.VotingTime.ToString();
    public static string PlayerSpeedMod=> GameOptionsManager.Instance.currentNormalGameOptions.PlayerSpeedMod.ToString();
    public static string AnonymousVotes="";
    
    //其它
    public static string RoomCode => InnerNet.GameCode.IntToGameName(AmongUsClient.Instance.GameId);
    public static string PlayerName=> DataManager.Player.Customization.Name;
    public static string AmongUsVersion=> UnityEngine.Application.version;
    public static string Map=> Constants.MapNames[GameOptionsManager.Instance.currentNormalGameOptions.MapId];
    public static string Date=> DateTime.Now.ToShortDateString();
    public static string Time=> DateTime.Now.ToShortTimeString();
    public static string PlayerLevel => PlayerControl.LocalPlayer.Data.PlayerLevel.ToString();
    
    //----------------------------



    //需要转换的变量
    public static string Name => PlayerControl.LocalPlayer.Data.PlayerName;
    public static string KD=> GameOptionsManager.Instance.currentNormalGameOptions.KillDistance.ToString();
    public static bool AV=> GameOptionsManager.Instance.currentNormalGameOptions.AnonymousVotes;
    
}
