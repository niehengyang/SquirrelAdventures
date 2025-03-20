using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [Header("移动平台配置")]
    [SerializeField] private GameObject[] movePoints; //移动点位
    [SerializeField] private float moveSpeed = 0.3f; //移动速度

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
