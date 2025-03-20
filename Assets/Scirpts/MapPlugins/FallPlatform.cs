using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    [Header("׹��ƽ̨����")]
    [Tooltip("�����󵽿�ʼ�����ʱ�䣨�룩")]
    [SerializeField] private float fallDelay = 1f; //׹��ʱ��
    [Tooltip("��ʼ��������ٵ�ʱ�䣨�룩")]
    public float destroyAfterFallTime = 3f;

    private bool isActivated = false;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // ��ʼ����������
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

        // ��ʼ��������
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.gravityScale = 1f;

        yield return new WaitForSeconds(destroyAfterFallTime);
        Destroy(gameObject);
    }
}
