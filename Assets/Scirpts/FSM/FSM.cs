using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerParameter
{
    [Header("½ÇÉ«ÒÆ¶¯")]
    public float runSpeed = 2f;

    [Header("½ÇÉ«ÌøÔ¾")]
    [Range(1,10)]
    public float jumpSpeed;
    public bool canDoubleJump = false;
    public int jumpCount = 2;
    [HideInInspector] public Rigidbody2D playerRB;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Transform playerFoot;
    public LayerMask Ground;
    public LayerMask Enemy;

    [Header("½¡¿µ×´Ì¬")]
    public float hp;
    public float maxHP = 10;

    [Header("ÊÜÉË×´Ì¬")]
    public int numBlinks;
   [HideInInspector] public SpriteRenderer playerRenderer;
    public float hurtCD = 1.0f; 
}

public class FSM : MonoBehaviour
{
    public PlayerParameter parameter;

    public IState currentState;
    public Dictionary<StateType, IState> states = new();

    protected virtual void Start()
    {
        parameter.playerRB = GetComponent<Rigidbody2D>();
        parameter.animator = GetComponent<Animator>();
        parameter.playerRenderer = GetComponent<SpriteRenderer>();
        parameter.playerFoot = transform.Find("Foot");

        states.Add(StateType.Appering, new ApperingState(this));
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Running, new RunningState(this));
        states.Add(StateType.Jumping, new JumpingState(this));
        states.Add(StateType.DoubleJumping, new DoubleJumpingState(this));
        states.Add(StateType.Falling, new FallingState(this));
        states.Add(StateType.Death, new DeathState(this));
        states.Add(StateType.Climb, new ClimbState(this));

        TransitionState(StateType.Appering);
    }

    protected virtual void Update()
    {
        currentState.OnUpdate();
    }

    protected virtual void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }
     
    public void TransitionState(StateType type)
    {
        currentState?.OnExit();

        currentState = states[type];
        currentState.OnEnter();
    }

    public void PlayAnimation(string animation)
    {
        parameter.animator.Play(animation);
    }

    public virtual void IsHurted(int value)
    {
        parameter.hp -= value;
        if (parameter.hp <= 0)
        {
            TransitionState(StateType.Death);
            Invoke("GameOver", 1);
            return;
        }
        StartCoroutine(DoHurtAni());
    }

    /// <summary>
    /// ÓÎÏ·½áÊø
    /// </summary>
    private void GameOver()
    {
        Destroy(gameObject);
    }

    public virtual void StampEemy(GameObject enemy)
    {
        //¹¥»÷¹ÖÎï
        enemy.GetComponent<Enemy>().IsHurt(1);
    }

    IEnumerator DoHurtAni()
    {
        for (int i = 0; i < parameter.numBlinks * 2; i++)
        {
            parameter.playerRenderer.color = Color.red;
            parameter.playerRenderer.enabled = !parameter.playerRenderer.enabled;
            yield return new WaitForSeconds(parameter.hurtCD);
        }
        parameter.playerRenderer.enabled = true;
    }
}

public enum StateType
{ 
    Appering,
    Idle,
    Running, 
    Jumping,
    DoubleJumping,
    Falling,
    Climb,
    Death
}

public static class FSM_AnimationName
{
    public const string Appearing = "Appearing";
    public const string Idle = "Idle";
    public const string Running = "Run";
    public const string Jumping = "Jump";
    public const string Falling = "Fall";
    public const string Hurted = "Hurt";
    public const string Death = "Death";
    public const string Climb = "Climb";
}