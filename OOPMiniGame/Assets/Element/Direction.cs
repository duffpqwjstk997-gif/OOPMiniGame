using UnityEngine;

public class Direction
{
    public Vector2 Keepdir;
    public Vector2 KeepdirX;
    public  Direction(Vector2 dir,Vector2 Edir)
    {
        Keepdir = (dir - Edir).normalized;
        this.KeepdirX = new Vector2(Keepdir.x, 0);
    }
}
