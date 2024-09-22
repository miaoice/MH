
using System.Runtime.CompilerServices;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace MH
{
	[HarmonyPatch(typeof(FreeChatInputField), "UpdateCharCount")]
	internal class UpdateCharCountPatch
	{
		public static void Postfix(FreeChatInputField __instance)
		{
			int length = __instance.textArea.text.Length;
			TMP_Text charCountText = __instance.charCountText;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(length);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(__instance.textArea.characterLimit);
			charCountText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			if (length < (AmongUsClient.Instance.AmHost ? 800 : 800))
			{
				__instance.charCountText.color = Color.black;
				return;
			}
			//如果字数超过限制，则字数显示为红色
			if (length < (AmongUsClient.Instance.AmHost ? 900 : 900))
			{
				__instance.charCountText.color = Color.yellow;
				return;
			}
			__instance.charCountText.color = Color.red;
		}
	}
}
