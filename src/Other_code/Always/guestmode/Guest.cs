using AmongUs.Data;
using HarmonyLib;

namespace MalumMenu;

[HarmonyPatch(typeof(EOSManager), nameof(EOSManager.StartInitialLoginFlow))]
public static class EOSManager_StartInitialLoginFlow
{
    // Prefix patch of EOSManager.StartInitialLoginFlow to automatically play with a guest account
    // when loading the game with guestMode enabled
    public static bool Prefix(EOSManager __instance)
    {
        // Always delete old guest accounts to avoid merge account popup
        __instance.DeleteDeviceID(new System.Action(__instance.EndMergeGuestAccountFlow));
        __instance.StartTempAccountFlow();
        __instance.CloseStartupWaitScreen();

        return false;
    }
}
[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.Update))]
public static class AmongUsClient_Update
{
    public static void Postfix()
    {
        if (EOSManager.Instance.loginFlowFinished){
            // Temporarily save the spoofed level using DataManager
            DataManager.Player.stats.level = 99;
            DataManager.Player.Save();

            DataManager.Player.Account.LoginStatus = EOSManager.AccountLoginStatus.LoggedIn;

            if (string.IsNullOrWhiteSpace(EOSManager.Instance.FriendCode))
            {
                string friendCode = "AMNS";
                EditAccountUsername editUsername = EOSManager.Instance.editAccountUsername;
                editUsername.UsernameText.SetText(friendCode);
                editUsername.SaveUsername();
                EOSManager.Instance.FriendCode = friendCode;
            }

        }
    }
}
