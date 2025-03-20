using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("����")]
    public int hp = 1; //Ѫ��

    [Header("����")]
    public int damage; //����
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
    /// �ܻ�
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
    /// ���ﴥ��
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
