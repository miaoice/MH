using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine.SceneManagement; 
using System;
using System.Collections.Generic;
using BepInEx.Configuration;
using HarmonyLib;


namespace MH;

[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
public partial class MH : BasePlugin
{

    public const string PluginGuid = "G.MH";
    public Harmony Harmony { get; } = new Harmony(PluginGuid);
    public static ConfigEntry<string> menuKeybind;
    public static bool NoGameEnd;
    

    public override void Load()
    {
        Harmony.PatchAll();
        SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>) ((scene, _) =>
        {
            if (scene.name == "MainMenu")
            {
                ModManager.Instance.ShowModStamp(); 
            }
        }));
    }
}