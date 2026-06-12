using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Hp myhp;
    Death mydeath;
    Damage mydamage;
    public int hp = 100;
    public int maxHp = 100;
    public Slider hpBar;
    void Start()
    {
        mydamage = new Damage();
    }

    // Update is called once per frame
    void Update()
    {
        myhp = new Hp(hp, maxHp, hpBar);
        mydeath = new Death(hp, this.gameObject);
    }
    public void TakeDamage(int damage)
    {
        mydamage.Damaged(damage, hp);
    }
}
