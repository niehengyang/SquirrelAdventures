using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������״̬
/// </summary>
public class EnemyHurtState : IState
{
    public EFSM enemy;
    public EnemyParameter parameter;
    public EnemyHurtState(EFSM stateManager)
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
