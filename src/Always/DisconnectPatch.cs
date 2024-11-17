using HarmonyLib;

namespace MH;

[HarmonyPatch(typeof(DisconnectPopup), nameof(DisconnectPopup.DoShow))]
internal class ShowDisconnectPopupPatch
{
    public static DisconnectReasons Reason;
    public static string ReasonByHost = string.Empty;
    public static void Postfix(DisconnectPopup __instance)
    {
        _ = new LateTask(() =>
        {
            if (__instance == null) return;
            try
            {

                void SetText(string text)
                { 
                    Logger.Info(__instance._textArea.text,"DisconnectPatch");
                    if (__instance?._textArea?.text != null)
                        __instance._textArea.text = text;
                    Logger.Info(text,"DisconnectPatch");
                }

                if (!string.IsNullOrEmpty(ReasonByHost))
                    SetText(string.Format("", ReasonByHost));
                else switch (Reason)
                    {
                        case DisconnectReasons.ExitGame:
                            SetText(__instance._textArea.text);
                            break;
                        case DisconnectReasons.Hacking:
                            SetText("停止外挂:)");
                            break;
                        case DisconnectReasons.Banned:
                            SetText("你被封禁了");
                            break;
                        case DisconnectReasons.Kicked:
                            SetText("你被踢出了");
                            break;
                        case DisconnectReasons.GameNotFound:
                            SetText("找不到房间");
                            break;
                        case DisconnectReasons.GameStarted:
                            SetText("游戏已开始");
                            break;
                        case DisconnectReasons.GameFull:
                            SetText("房间已满");
                            break;
                        case DisconnectReasons.IncorrectVersion:
                            SetText("版本不一");
                            break;
                        case DisconnectReasons.Error:
                            SetText("土豆服务器");
                            break;
                        case DisconnectReasons.Custom:
                            SetText("土豆服务器");
                            break;
                    }
            }
            catch { }
        }, 0.01f, "Override Disconnect Text");
    }
}