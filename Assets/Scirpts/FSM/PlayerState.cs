using System.Collections;
using UnityEngine;

public class ApperingState : IState
{

    public FSM manager;
    public PlayerParameter parameter;
    public ApperingState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Appearing);
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        CheckOnGround();
    }
    public void OnFixedUpdate()
    {

    }

    private void CheckOnGround()
    {
        if (Physics2D.OverlapCircle(parameter.playerFoot.position, 0.01f, parameter.Ground))
        {
            manager.TransitionState(StateType.Idle);
        }
    }
}

public class IdleState : IState
{

    public FSM manager;
    public PlayerParameter parameter;
    private float moveX;
    private bool isJump;
    public IdleState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }
    
    public void OnEnter()
    {
        parameter.jumpCount = 2;
        manager.PlayAnimation(FSM_AnimationName.Idle);
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        isJump = Input.GetButtonDown("Jump");
        Jump();
        Move();
    }
    public void OnFixedUpdate()
    {

    }

    private void Move()
    {
        var v = parameter.playerRB.velocity;
        v.x = 0;
        parameter.playerRB.velocity = v;
        if (Mathf.Abs(moveX) > Mathf.Epsilon) manager.TransitionState(StateType.Running);
    }

    private void Jump()
    {
        if (isJump && !parameter.canDoubleJump) manager.TransitionState(StateType.Jumping);


        if (isJump && parameter.canDoubleJump)
        {
            parameter.jumpCount--;
            manager.TransitionState(StateType.DoubleJumping);
        }
    }

}

public class RunningState : IState
{

    public FSM manager;
    public PlayerParameter parameter;
    private float moveX;
    private bool isJump;
    public RunningState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Running);
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        isJump = Input.GetButtonDown("Jump");
        moveX = Input.GetAxis("Horizontal");
        Jump();
        Move();
    }

    public void OnFixedUpdate()
    {
      
    }

    private void Move()
    {
        if (Mathf.Abs(moveX) > Mathf.Epsilon)
        {
            //移动
            parameter.playerRB.velocity = new Vector2(moveX * parameter.runSpeed, parameter.playerRB.velocity.y);
            //转向
            parameter.playerRB.transform.localRotation = Quaternion.Euler(parameter.playerRB.velocity.x, moveX < 0 ? 180 : 0, 0);
        }
        else
        {
            manager.TransitionState(StateType.Idle);
        }
    }

    private void Jump()
    {
        if (isJump && !parameter.canDoubleJump) manager.TransitionState(StateType.Jumping);

        if (isJump && parameter.canDoubleJump)
        {
            parameter.jumpCount--;
            manager.TransitionState(StateType.DoubleJumping);
        }
    }

   
}

public class JumpingState : IState
{

    public FSM manager;
    public PlayerParameter parameter;
    private float moveX;
    private bool isJump;
    public JumpingState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Jumping);
        parameter.playerRB.velocity = Vector2.up * parameter.jumpSpeed;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        isJump = Input.GetButtonDown("Jump");
        Jump();
        Fall();
        Move();
    }
    public void OnFixedUpdate()
    {
    }

    private void Move()
    {
        if (Mathf.Abs(moveX) > Mathf.Epsilon)
        {
            //移动
            parameter.playerRB.velocity = new Vector2(moveX * parameter.runSpeed, parameter.playerRB.velocity.y);
            //转向
            parameter.playerRB.transform.localRotation = Quaternion.Euler(parameter.playerRB.velocity.x, moveX < 0 ? 180 : 0, 0);
        }
    }
    private void Jump()
    {
        if (isJump && parameter.canDoubleJump && parameter.jumpCount > 0)
        {
            parameter.jumpCount--;
            manager.TransitionState(StateType.DoubleJumping);
        }
    }
    private void Fall()
    {
        if (parameter.playerRB.velocity.y < -0.01f) manager.TransitionState(StateType.Falling);
    }

}

public class DoubleJumpingState : IState
{

    public FSM manager;
    public PlayerParameter parameter;
    private float moveX;
    public DoubleJumpingState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Jumping);
        parameter.playerRB.velocity = Vector2.up * parameter.jumpSpeed;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        Fall();
        Move();
    }
    public void OnFixedUpdate()
    {
      
    }
    private void Move()
    {
        if (Mathf.Abs(moveX) > Mathf.Epsilon)
        {
            //移动
            parameter.playerRB.velocity = new Vector2(moveX * parameter.runSpeed, parameter.playerRB.velocity.y);
            //转向
            parameter.playerRB.transform.localRotation = Quaternion.Euler(parameter.playerRB.velocity.x, moveX < 0 ? 180 : 0, 0);
        }
    }
    private void Fall()
    {
        if (parameter.playerRB.velocity.y < -0.01f) manager.TransitionState(StateType.Falling);
    }

}

public class FallingState : IState
{

    public FSM manager; 
    public PlayerParameter parameter;
    private bool isJump;
    public FallingState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Falling);
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        isJump = Input.GetButtonDown("Jump");
        CheckStamp();
        CheckOnGround();
        Jump();
    }
    public void OnFixedUpdate()
    {
      
    }
    private void CheckStamp()
    {
        Collider2D c = Physics2D.OverlapCircle(parameter.playerFoot.position, 0.1f, parameter.Enemy);
        if (c == null)
        {
            return;
        }
        manager.StampEemy(c.gameObject);

        parameter.playerRB.velocity = new Vector2(parameter.playerRB.velocity.x, 0);
        parameter.playerRB.AddForce(new Vector2(0, 200));
    }
    private void CheckOnGround()
    {
        if (Physics2D.OverlapCircle(parameter.playerFoot.position, 0.01f, parameter.Ground))
        {
            manager.TransitionState(StateType.Idle);
            parameter.jumpCount = 2;
        }
    }

    private void Jump()
    {
        if (isJump && parameter.canDoubleJump && parameter.jumpCount > 0)
        {
            parameter.jumpCount--;
            manager.TransitionState(StateType.Jumping);
        }
    }
}

public class ClimbState : IState
{
    public FSM manager;
    public PlayerParameter parameter;
    private bool isLadder;
    public ClimbState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Climb);
        StopMove();
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
    public void OnFixedUpdate()
    {

    }

    /// <summary>
    /// 检查是否在梯子上
    /// </summary>
    private void CheckOnLadder()
    {

    }

    /// <summary>
    /// 停止移动
    /// </summary>
    private void StopMove()
    {
        var v = parameter.playerRB.velocity;
        v.x = 0;
        parameter.playerRB.velocity = v;
    }
}

/// <summary>
/// 死亡状态
/// </summary>
public class DeathState : IState
{
    public FSM manager;
    public PlayerParameter parameter;
    public DeathState(FSM stateManager)
    {
        manager = stateManager;
        parameter = manager.parameter;
    }

    public void OnEnter()
    {
        manager.PlayAnimation(FSM_AnimationName.Death);
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        
    }
    public void OnFixedUpdate()
    {
        StopMove();
    }

    private void StopMove()
    {
        var v = parameter.playerRB.velocity;
        v.x = 0;
        parameter.playerRB.velocity = v;
    }
}