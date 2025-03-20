using UnityEngine;
using UnityEngine.Tilemaps;

public class Spikes : MonoBehaviour
{
    private TilemapCollider2D _tilemapCollider2;

    [Header("��������")]
    public float cdHurtTime = 2.0f;
    public int hurtValue = 2;
    private float durationOfInjuryer;
    private bool isDamageDurationOf = true;

    private void Start()
    {
        _tilemapCollider2 = GetComponent<TilemapCollider2D>();
    }
    
    /// <summary>
    /// �ش̴������
    /// </summary>
    /// <param name="collision"></param>
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        Player.Instance.IsHurted(hurtValue);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D other)
    {
        //�ж��ǲ������
        if (other.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            //�ǲ��ǿ����˺�
            if (isDamageDurationOf)
            {
                isDamageDurationOf = false;
                Player.Instance.IsHurted(hurtValue);
            }
            else
            {
                //��ʱ
                durationOfInjuryer += Time.deltaTime;
                if (durationOfInjuryer >= cdHurtTime)
                {
                    isDamageDurationOf = true;
                    durationOfInjuryer = 0f;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //reset
        if (other.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            isDamageDurationOf = true;
            durationOfInjuryer = 0f;
        }
    }
}
