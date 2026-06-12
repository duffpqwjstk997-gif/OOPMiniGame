using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
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
    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           mydamage.Damaged(10, collision.gameObject.GetComponent<Enemy>().hp);
        }
    }
}
