using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������״̬
/// </summary>
public class EnemyDeathState : IState
{

    public EFSM enemy;
    public EnemyParameter parameter;
    public EnemyDeathState(EFSM stateManager)
    {
        enemy = stateManager;
        parameter = enemy.parameter;
    }
    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnFixedUpdate()
    {
    }

    public void OnUpdate()
    {
    }
}
