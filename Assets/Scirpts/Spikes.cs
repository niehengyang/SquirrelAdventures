using UnityEngine;
using UnityEngine.Tilemaps;

public class Spikes : MonoBehaviour
{
    private TilemapCollider2D _tilemapCollider2;

    [Header("陷阱配置")]
    public float cdHurtTime = 2.0f;
    public int hurtValue = 2;
    private float durationOfInjuryer;
    private bool isDamageDurationOf = true;

    private void Start()
    {
        _tilemapCollider2 = GetComponent<TilemapCollider2D>();
    }
    
    /// <summary>
    /// 地刺触发检测
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
        //判断是不是玩家
        if (other.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
        {
            //是不是可以伤害
            if (isDamageDurationOf)
            {
                isDamageDurationOf = false;
                Player.Instance.IsHurted(hurtValue);
            }
            else
            {
                //计时
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
