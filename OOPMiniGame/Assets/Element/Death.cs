using UnityEngine;

public class Death
{
    public Death(int Hp,GameObject Object)
    {
        int _hp = Hp;
        GameObject _object = Object;
        if (_hp <= 0)
        {
            Debug.Log("You are dead");
            _object.SetActive(false);
        }
    }
}
