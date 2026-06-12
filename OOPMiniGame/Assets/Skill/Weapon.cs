using UnityEngine;

public class Weapon : MonoBehaviour
{
    Damage mydamage;
    Direction mydirection;
    Move move;
    private Vector2 Attackdir;
    public int damage = 30;
    void Start()
    {
        move = GetComponent<Move>();
        Attackdir = move.moveDir;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            mydamage = new Damage();
            mydamage.Damaged(damage, collision.GetComponent<Enemy>().hp);
        }
    }
}
