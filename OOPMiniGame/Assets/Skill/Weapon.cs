using UnityEngine;

public class Weapon : MonoBehaviour
{
    Damage mydamage;
    Direction mydirection;
    Move move;
    private Vector2 Attackdir = Vector2.right;
    public int damage = 30;
    public float LifeTime = 1f; // 공격이 지속되는 시간

    void OnEnable()
    {
        Attackdir = Player.instance.attackDir;
        transform.localPosition = Vector2.zero; // 무기의 위치를 초기화
        Invoke("DisableWeapon", LifeTime); // 일정 시간 후에 무기를 비활성화
    }
    void Start()
    {
    }
    void Update()
    {
        transform.position += (Vector3)Attackdir *10* Time.deltaTime; // 무기를 이동시킴
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void DisableWeapon()
    {
        gameObject.SetActive(false);
    }
}
