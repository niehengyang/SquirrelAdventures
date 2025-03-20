using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemItem : MonoBehaviour
{
    private CapsuleCollider2D _capsuleCollider2;

    private void Start()
    {
        _capsuleCollider2 = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _capsuleCollider2.enabled = false;
            GameScore.Instance.gemCount ++;
            GameScore.Instance.UpdateGemTotal();
            Destroy(gameObject);
        }
    }
}
