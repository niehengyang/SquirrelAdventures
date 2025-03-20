using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateType
{
    Idle, Move, Attack, Hurt, Death
}

[Serializable]
public class EnemyParameter
{
    [Header("Ä¿±ê")]
    [SerializeField]
    public Transform player;

    [Header("ÒÆ¶¯×·»÷")]
    public float runSpeed = 2f;
    public Vector2 MovementInput { get; set; }
    public float chaseDistance = 3f; //×·»÷¾àÀë
    public float attackDistance = 0.8f; //¹¥»÷¾àÀë

    [Header("¹¥»÷")]
    public float meleeAttackDamage;//½üÕ½¹¥»÷ÉËº¦
    public bool isAttack = true;
    [HideInInspector] public float distanceToPlayer; //ÓëÍæ¼Ò¾àÀë
    public LayerMask Player; //Íæ¼ÒÍ¼²ã
    public float AttackCooldownDuration = 2f;//¹¥»÷CD

    [Header("½¡¿µ×´Ì¬")]
    public float hp;
    public float maxHP = 1;

    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Collider2D enemyCollider;

}

public class EFSM : MonoBehaviour
{
    public EnemyParameter parameter;
    public IState currentState;
    public Dictionary<EnemyStateType, IState> states = new();

    private void Awake()
    {
        
    }

    protected virtual void Start()
    {
        parameter.sr = GetComponent<SpriteRenderer>();
        parameter.rb = GetComponent<Rigidbody2D>();
        parameter.animator = GetComponent<Animator>();
        parameter.enemyCollider = GetComponent<Collider2D>();

        //ÊµÀý»¯µÐÈË×´Ì¬
        states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
        states.Add(EnemyStateType.Move, new EnemyMoveState(this));
        states.Add(EnemyStateType.Attack, new EnemyAttackState(this));
        states.Add(EnemyStateType.Hurt, new EnemyHurtState(this));
        states.Add(EnemyStateType.Death, new EnemyDeathState(this));
    }

    protected virtual void Update()
    {
        currentState.OnUpdate();
    }

    protected virtual void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    public void TransitionState(EnemyStateType type)
    {
        currentState?.OnExit();

        currentState = states[type];
        currentState.OnEnter();
    }

    //²¥·Å¶¯»­
    public void PlayAnimation(string animation)
    {
        parameter.animator.Play(animation);
    }

    public void GetPlayerTransform()
    {
        Collider2D[] chaseColliders = Physics2D.OverlapCircleAll(transform.position, parameter.chaseDistance, parameter.Player);

        if (chaseColliders.Length > 0)
        {
            parameter.player = chaseColliders[0].transform; //»ñÈ¡Íæ¼Òtransform
            parameter.distanceToPlayer = Vector2.Distance(parameter.player.position, transform.position);
        }
        else
        {
            parameter.player = null;
        }
    }
}

public static class EFSM_AnimationName
{
    public const string Idle = "Idle";
    public const string Move = "Move";
    public const string Attack = "Attack";
    public const string Hurt = "Hurt";
    public const string Death = "Death";
}