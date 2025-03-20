using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [Header("�ƶ�ƽ̨����")]
    [SerializeField] private GameObject[] movePoints; //�ƶ���λ
    [SerializeField] private float moveSpeed = 0.3f; //�ƶ��ٶ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(movePoints[0].transform.position, movePoints[1].transform.position, Mathf.PingPong(Time.time * moveSpeed, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
