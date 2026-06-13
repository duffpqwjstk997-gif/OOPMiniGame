using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Hp myhp;
    Death mydeath;
    Damage mydamage;
    Move mymove;
    Knockback myknockback;
    public static Player instance;
    public int hp = 100;
    public int maxHp = 100;
    public int exp = 0;
    public int maxExp = 100;
    public bool invincible = false;
    private float nextHitTime = 0f;
    private float nextattackTime = 0f;
    public Vector2 attackDir = Vector2.right;

    public GameObject weapon;
    public Slider hpBar;
    public Slider ExpBar;

    void Start()
    {
        instance = this;
        mydamage = new Damage();
        mydeath = new Death();
        myhp = new Hp();
        myknockback = new Knockback();
        mymove = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        myhp.UpdateHpBar(hp, maxHp, hpBar);
        myhp.UpdateHpBar(exp, maxExp, ExpBar);
        if(exp >= maxExp)
        {
            exp = 0;
            maxExp += 50;
            maxHp += 20;
            hp = maxHp;
            Debug.Log("레벨업! 최대 체력과 경험치가 증가했습니다.");
        }
        mydeath.Dead(hp, this.gameObject);
        if (invincible && Time.time >= nextHitTime)
        {
            invincible = false; // 무적 해제!
            Debug.Log("무적 시간이 끝났습니다.");
        }
        if(Time.time >= nextattackTime)
        {
            Debug.Log("공격!");
            nextattackTime = Time.time + 1f; // 1초마다 공격 가능
            Attack();
        }
        attackDir = mymove.moveDir;
    }
    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            hp = mydamage.Damaged(damage, hp);
            myknockback.KnockbackEffect(-mymove.moveDir, this.gameObject, 1f);
            invincible = true;
            nextHitTime = Time.time + 2f;
            Debug.Log("대미지를 입었습니다! 2초간 무적입니다."+ hp);
        }
    }
    private void Attack()
    {
        weapon.SetActive(true);
    }

}
