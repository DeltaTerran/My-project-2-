using UnityEditorInternal;
using UnityEngine;

public abstract class State
{
    protected GameObject player;
    protected Animator animator;
    protected CapsuleCollider collider;
    public State(GameObject player, Animator animator, CapsuleCollider collider)
    {
        this.player = player;
        this.animator = animator;
        this.collider = collider;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
public class JumpingState : State
{
    public JumpingState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator,collider) { }

   

    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("JumpTr");
    }

    public override void Update()
    {
        base.Update();
        if (player.transform.position.y <= 1f)
        {
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));

        }
    }
}
public class RunningState : State
{
    public RunningState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator, collider) { }



    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (player.transform.position.y <= 1f)
        {
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));

        }
    }
}
public class SlidingState : State
{
    public SlidingState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator, collider) { }

    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("SlideTr");
        Debug.Log("Entered Sliding State");
    }

    public override void Update()
    {
        base.Update();
        // Логика завершения кувырка через определенное время
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exiting Sliding State");
    }
}
public class PlayerStateMachine
{
    public static PlayerStateMachine Instance;
    private State currentState;
    public void ChangeState(State newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;

        if (currentState != null)
            currentState.Enter();
    }
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}