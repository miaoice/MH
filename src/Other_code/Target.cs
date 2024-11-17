using Hazel;
using InnerNet;
namespace MH;
public static class Target{
    private static string target;
    
    public static void All()
    {
        foreach (var player in PlayerControl.AllPlayerControls)
            {
                target = player.ToString();
                S.Tip(target);
            }
    }
}
/*
                foreach (var player in PlayerControl.AllPlayerControls)
                {
                    if (player.Data.Role.TeamType == RoleTeamTypes.Impostor){
                        Utils.murderPlayer(player, MurderResultFlags.Succeeded);
                    }
                }*/