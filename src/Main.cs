using AmongUs.GameOptions;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using InnerNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[assembly: AssemblyFileVersion(MH.Main.PluginVersion)]
[assembly: AssemblyVersion(MH.Main.PluginVersion)]
namespace MH;

[BepInProcess("Among Us.exe")]

public class Main : BasePlugin
{

    public static readonly string ModName = "MH"; // 模组名字
    public const string PluginVersion = "0.0.0"; //版本号
    
    public static BepInEx.Logging.ManualLogSource Logger;
    public static int updateTime;
    public static Main Instance; //设置Main实例
    
    public static Version version = Version.Parse(PluginVersion);
    public static Dictionary<byte, List<string>> SetRolesList = new();
    public override void Load()
    {
        Instance = this; 
        Logger = BepInEx.Logging.Logger.CreateLogSource("MH"); //输出前缀

       
    }
    
    public static readonly string ForkId = "MH";
    public static Dictionary<byte, PlayerVersion> playerVersion = new();
}

public class PlayerVersion
{
    public readonly Version version;

    public readonly string tag;
    
    public readonly string forkId;
    public PlayerVersion(string ver, string tag_str, string forkId) : this(Version.Parse(ver), tag_str, forkId) { }
    public PlayerVersion(Version ver, string tag_str, string forkId)
    {
        version = ver;
        tag = tag_str;
        this.forkId = forkId;
    }
    
    
}

public enum CustomRoles
{
    //Default
    Crewmate,
    Impostor,
    Shapeshifter,
    Phantom,
    Engineer,
    Scientist,
    GuardianAngel,
    Noisemaker,
    Tracker,
}