using HarmonyLib;
using InnerNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MH
{
	[HarmonyPatch(typeof(BanMenu), "SetVisible")]
	internal class BanMenuSetVisiblePatch
	{
		public static bool Prefix(BanMenu __instance, bool show)
		{
			if (!AmongUsClient.Instance.AmHost)
			{
				return true;
			}
			show &= (PlayerControl.LocalPlayer && PlayerControl.LocalPlayer.Data != null);
			__instance.BanButton.gameObject.SetActive(AmongUsClient.Instance.CanBan());
			__instance.KickButton.gameObject.SetActive(AmongUsClient.Instance.CanKick());
			__instance.MenuButton.gameObject.SetActive(show);
			return false;
		}
	}
    [HarmonyPatch(typeof(BanMenu), "Select")]
	internal class BanMenuSelectPatch
	{
		public static void Postfix(BanMenu __instance, int clientId)
		{
			ClientData recentClient = AmongUsClient.Instance.GetRecentClient(clientId);
			if (recentClient == null)
			{
				return;
			}
		}
	}
}