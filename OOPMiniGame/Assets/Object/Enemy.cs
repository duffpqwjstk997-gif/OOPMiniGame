using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Hp myhp;
    Death mydeath;
    Damage mydamage;
    Move mymove;
    Knockback myknockback;
    public bool invincible = false;
    private float nextHitTime = 0f;
    public int hp = 100;
    public int maxHp = 100;
    public Slider hpBar;
    private void OnEnable()
    {
        hp = maxHp;
    }
    void Start()
    {
        mydamage = new Damage();
        myhp = new Hp();
        mydeath = new Death();
        myknockback = new Knockback();
        mymove = this.gameObject.GetComponent<Move>();

    }

    // Update is called once per frame
    void Update()
    {
        myhp.UpdateHpBar(hp, maxHp, hpBar);
        if (invincible && Time.time >= nextHitTime)
        {
            invincible = false; // 公利 秦力!
            Debug.Log("公利 矫埃捞 场车嚼聪促.");
        }

        if (hp <= 0)
        {
            mymove.StopMove();
            transform.Translate(Vector3.up * 5 * Time.deltaTime);
            Debug.Log("Enemy Dead");
            Invoke("Dead", 0.5f);
        }
    }
    public void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(20);
            Debug.Log("Damge");
        }
    }
    public void TakeDamage(int damage)
    {
        if (!invincible && hp >= 0)
        {
            hp = mydamage.Damaged(damage, hp);
            Debug.Log(hp);
            myknockback.KnockbackEffect(-mymove.EmoveDir, this.gameObject, 1f);
            invincible = true;
            nextHitTime = Time.time + 0.5f;
        }
    }
        void Dead()
        {
            mydeath.Dead(hp, this.gameObject);
        }

}
