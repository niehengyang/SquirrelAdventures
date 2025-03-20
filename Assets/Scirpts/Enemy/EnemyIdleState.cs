using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

/// <summary>
/// 敌人待机状态
/// </summary>
public class EnemyIdleState : IState
{
    public EFSM enemy;
    public EnemyParameter parameter;
    public EnemyIdleState(EFSM stateManager)
    {
        enemy = stateManager;
        parameter = enemy.parameter;
    }
    public void OnEnter()
    {
        enemy.PlayAnimation(EFSM_AnimationName.Idle);
    }

    public void OnExit()
    {
    }
    public void OnUpdate()
    {
        enemy.GetPlayerTransform();
        if (parameter.player != null) //玩家不为空
        {
            if (parameter.distanceToPlayer > parameter.attackDistance) //大于攻击距离切换到追击
            {
                enemy.TransitionState(EnemyStateType.Move);
            }
            else if (parameter.distanceToPlayer <= parameter.attackDistance)
            {
                enemy.TransitionState(EnemyStateType.Attack);
            }
        }
    }
    public void OnFixedUpdate()
    {
    }

}
