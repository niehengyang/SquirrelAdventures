using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class EnemyEagle : Enemy
{
    public float patrolSpeed; //巡逻速度
    public float patrolCD; //巡逻CD
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos; //巡逻区域左下角
    public Transform rightUpPos; //巡逻区域右上角

    public bool faceRight = true;
    public new void Start()
    {
        base.Start();
        waitTime = patrolCD;
        movePos.localPosition = GetRandomPos();
    }

    public new void Update()
    {
        base.Update();

        PatrolMove();
    }

    private void PatrolMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos.localPosition, patrolSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.localPosition) <= Mathf.Epsilon)
        {
            Vector2 oMovePos = movePos.localPosition ;
            if (waitTime <= 0)
            {
                //重置坐标
                movePos.localPosition = GetRandomPos();
                //怪物转向
                float moveX = movePos.localPosition.x - oMovePos.x;
                transform.transform.localRotation = Quaternion.Euler(transform.transform.rotation.x, moveX > 0 ? 180 : 0, 0);
                //巡逻CD
                waitTime = patrolCD;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.localPosition.x, rightUpPos.localPosition.x), Random.Range(leftDownPos.localPosition.y, rightUpPos.localPosition.y));
        return rndPos;
    }
}
