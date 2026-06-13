using UnityEngine;

public class Damage
{
    public int Damaged(int dam,int Hp)
    {
        int _dam = dam;
        int _hp = Hp;
        return _hp -= _dam;
    }
}
