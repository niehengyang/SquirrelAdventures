using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    [Header("坠落平台配置")]
    [Tooltip("触发后到开始下落的时间（秒）")]
    [SerializeField] private float fallDelay = 1f; //坠落时间
    [Tooltip("开始下落后到销毁的时间（秒）")]
    public float destroyAfterFallTime = 3f;

    private bool isActivated = false;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // 初始化刚体设置
        if (rb2d != null)
        {
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            rb2d.freezeRotation = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            StartCoroutine(StartFalling());
        }
    }

    private IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(fallDelay);

        // 开始物理下落
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.gravityScale = 1f;

        yield return new WaitForSeconds(destroyAfterFallTime);
        Destroy(gameObject);
    }
}
