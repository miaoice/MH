
using HarmonyLib;
namespace MH
{
    [HarmonyPatch(typeof(ControllerManager), nameof(ControllerManager.Update))]
    class AS
    {
        public static void Postfix()
        {
            if (C.Lazy && GameStates.IsLobby )
            {
                if(GameStates.IsHost)
                {
                    Main.updateTime++;
                    if (Main.updateTime >= 50)
                    {
                        Main.updateTime = 0;
                        if (!GameStates.IsCountDown)
                        {
                            if (GameData.Instance.PlayerCount >= 14)
                            {
                                BeginAutoStart(10f);
                                return;
                            }
                        }
                    }
                }
                else
                { 
                    C.Lazy = false;
                    S.Tip("不是房主，必须变勤快");
                }
            }
        }
            public static void BeginAutoStart(float countdown)
        {

                GameStartManager.Instance.startState = GameStartManager.StartingStates.Countdown;
                GameStartManager.Instance.countDownTimer = (countdown == 0 ? 0.2f : countdown);
                GameStartManager.Instance.StartButton.gameObject.SetActive(false);
        }
        
    }
}
