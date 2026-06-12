using UnityEngine.UI;

public class Hp
{
    public int hp;
    public int maxHp;
    public Slider hpBar;
    public Hp(int hp, int maxHp, Slider hpBar)
    {
        this.hp = hp;
        this.maxHp = maxHp;
        this.hpBar = hpBar;
        UpdateHpBar();
    }
    private void UpdateHpBar()
    {
        if (hpBar != null)
        {
            float fillAmount = (float)hp / maxHp;
            hpBar.value = fillAmount;
        }
    }
}
