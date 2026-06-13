using UnityEngine.UI;

public class Hp
{
    public int hp;
    public int maxHp;
    public Slider hpBar;
    public void UpdateHpBar(int Hp, int MaxHp, Slider HpBar)
    {
        this.hp = Hp;
        this.maxHp = MaxHp;
        this.hpBar = HpBar;
        if (hpBar != null)
        {
            float fillAmount = (float)hp / maxHp;
            hpBar.value = fillAmount;
        }
    }
}
