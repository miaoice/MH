using System;
using System.Security.Cryptography;
using AmongUs.Data;
using HarmonyLib;
using UnityEngine;

namespace MH;

[HarmonyPatch(typeof(StatsManager), nameof(StatsManager.BanMinutesLeft), MethodType.Getter)]
public static class StatsManager_BanMinutesLeft_Getter
{    public static void Postfix(StatsManager __instance, ref int __result)
    {
            __instance.BanPoints = 0f;
            __result = 0; 
    }
}
[HarmonyPatch(typeof(SystemInfo), nameof(SystemInfo.deviceUniqueIdentifier), MethodType.Getter)]
public static class SystemInfo_deviceUniqueIdentifier_Getter
{
    // Postfix patch of SystemInfo.deviceUniqueIdentifier Getter method 
    // Made to hide the user's real unique deviceId by generating a random fake one
    public static void Postfix(ref string __result)
    {
        var bytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(bytes);
        }
        __result = BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}


[HarmonyPatch(typeof(FullAccount), nameof(FullAccount.CanSetCustomName))]
public static class FullAccount_CanSetCustomName
{
    // Prefix patch of FullAccount.CanSetCustomName to allow the usage of custom names
    public static void Prefix(ref bool canSetName)
    {
            canSetName = true;
    }
}


[HarmonyPatch(typeof(HatManager), nameof(HatManager.Initialize))]
public static class HatManager_Initialize
{
    public static void Postfix(HatManager __instance){

        CosmeticsUnlocker.unlockCosmetics(__instance);
        
    }
}

[HarmonyPatch(typeof(AccountManager), nameof(AccountManager.CanPlayOnline))]
public static class AccountManager_CanPlayOnline
{
    // Prefix patch of AccountManager.CanPlayOnline to allow online games
    public static void Postfix(ref bool __result)
    {
            __result = true;
    }
}

[HarmonyPatch(typeof(InnerNet.InnerNetClient), nameof(InnerNet.InnerNetClient.JoinGame))]
public static class InnerNet_InnerNetClient_JoinGame
{
    // Prefix patch of InnerNet.InnerNetClient.JoinGame to allow online games
    public static void Prefix()
    {
            DataManager.Player.Account.LoginStatus = EOSManager.AccountLoginStatus.LoggedIn;
    }
}
public static class CosmeticsUnlocker
{    public static void unlockCosmetics(HatManager hatManager){
            foreach(var bundle in hatManager.allBundles){ //Bundles
            bundle.Free = true;
            }

            foreach(var featuredBundle in hatManager.allFeaturedBundles){ //Featured Bundles
                featuredBundle.Free = true;
            }

            foreach(var featuredCube in hatManager.allFeaturedCubes){ //Featured Cosmicubes
                featuredCube.Free = true;
            }

            foreach(var featuredItem in hatManager.allFeaturedItems){ //Featured Items
                featuredItem.Free = true;
            }

            foreach(var hat in hatManager.allHats){ //Hats
                hat.Free = true;
            }

            foreach(var nameplate in hatManager.allNamePlates){ //NamePlates
                nameplate.Free = true;
            }

            foreach(var pet in hatManager.allPets){ //Pets
                pet.Free = true;
            }

            foreach(var skin in hatManager.allSkins){ //Skins
                skin.Free = true;
            }

            foreach(var starBundle in hatManager.allStarBundles){ //Star Bundles
                starBundle.price = 0; // StarBundles don't have a Free property, so price is changed instead
            }

            foreach(var visor in hatManager.allVisors){ //Visors
                visor.Free = true;
            }
        }
    }
