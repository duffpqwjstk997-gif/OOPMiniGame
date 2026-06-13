using UnityEngine;

public class Knockback
{
    public Vector2 Knockbackdir;
    public void KnockbackEffect(Vector2 dir,GameObject gameObject,float amount)
    {
        Knockbackdir = dir.normalized;
        gameObject.transform.position += (Vector3)Knockbackdir * amount;  

    }

}
