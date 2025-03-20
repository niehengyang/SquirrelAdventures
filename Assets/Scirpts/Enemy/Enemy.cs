using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("生命")]
    public int hp = 1; //血量

    [Header("攻击")]
    public int damage; //攻击
                       // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (hp <= 0)
        {

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 受击
    /// </summary>
    /// <param name="hurtValue"></param>
    public void IsHurt(int hurtValue)
    {
        if (hp > 0)
        {
            hp -= hurtValue;
        }
    }

    /// <summary>
    /// 怪物触发
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.Instance.IsHurted(damage);
        }
    }
}
