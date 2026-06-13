using UnityEngine;

public class Death
{
    public void Dead(int Hp,GameObject Object)
    {
        int _hp = Hp;
        GameObject _object = Object;
        if (_hp <= 0)
        {
            Debug.Log("dead");
            _object.SetActive(false);
            Player.instance.exp += 15;
        }
    }
}
