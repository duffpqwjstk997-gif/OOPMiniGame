using UnityEngine;

public class Damage
{
    public void Damaged(int dam,int Hp)
    {
        int _dam = dam;
        int _hp =Hp;
        _hp -= _dam;
    }
}
