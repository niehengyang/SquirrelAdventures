using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// µÐÈËÒÆ¶¯×´Ì¬
/// </summary>
public class EnemyMoveState : IState
{
    public EFSM enemy;
    public EnemyParameter parameter;
    public EnemyMoveState(EFSM stateManager)
    {
        enemy = stateManager;
        parameter = enemy.parameter;
    }

    public void OnEnter()
    {
        enemy.PlayAnimation(EFSM_AnimationName.Move);
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
