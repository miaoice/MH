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

namespace MH
{
    
    [HarmonyPatch(typeof(ControllerManager), nameof(ControllerManager.Update))]
    class ABCDEFG
    {
        
        public static void Postfix()
        {
        }
    }
}
