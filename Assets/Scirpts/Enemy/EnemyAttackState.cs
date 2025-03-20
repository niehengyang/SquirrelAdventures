using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˹���״̬
/// </summary>
public class EnemyAttackState : IState
{
    public EFSM enemy;
    public EnemyParameter parameter;
    public EnemyAttackState(EFSM stateManager)
    {
        enemy = stateManager;
        parameter = enemy.parameter;
    }

    public void OnEnter()
    {
        enemy.PlayAnimation(EFSM_AnimationName.Attack);
    }
    public void OnUpdate()
    {
    }
    public void OnFixedUpdate()
    {
    }
    public void OnExit()
    {
    }
}
