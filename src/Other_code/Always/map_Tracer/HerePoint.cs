using UnityEngine;

namespace MH;
public class HerePoint
{
    public PlayerControl player;
    public SpriteRenderer sprite;

    public HerePoint(PlayerControl player, SpriteRenderer sprite)
    {
        this.player = player;
        this.sprite = sprite;
    }
}
