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
#region States
public class JumpingState : State
{
    private float jumpDuration = 0.9f;
    private bool isJumping = false;
    public JumpingState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator,collider) { }

   

    public override void Enter()
    {
        base.Enter();
        isJumping = true;
        animator.SetTrigger("JumpTr");
        SetCollider(2, new Vector3(0, 3.5f, 0)); // ћен€ем высоту и центр коллайдера
        Debug.Log("Jumping started");
    }

    public override void Update()
    {
        base.Update();

        if (isJumping) return;
        jumpDuration -= Time.deltaTime;
        if (jumpDuration <= 0)
        {
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        }
        //jumpDuration -= Time.deltaTime;
        //if (jumpDuration < 0)
        //{
        //isJumping = false;
        //    PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        //}
        //if (player.transform.position.y <= 1f)
        //{
        //    PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));

        //}
    }
    public override void Exit()
    {
        base.Exit();
        SetCollider(2, new Vector3(0, 1, 0));
        moveorb.CanPlayAnimation = true;
        animator.ResetTrigger("JumpTr");
        Debug.Log("Jumping ended");
    }
    private void SetCollider(float height, Vector3 center)
    {
        collider.height = height;
        collider.center = center;
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
        //if (player.transform.position.y <= 1f)
        //{
        //    PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));

        //}
    }
}
public class SlidingState : State
{
    private float slideDuration = 0.9f;
    public SlidingState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator, collider) { }

    public override void Enter()
    {
        base.Enter();
        animator.SetTrigger("SlideTr");
        SetCollider(1, new Vector3(0, 0.5f, 0));
        Debug.Log("Entered Sliding State");
    }

    public override void Update()
    {
        base.Update();
        slideDuration -= Time.deltaTime;
        if (slideDuration <= 0)
        {
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        }
    }

    public override void Exit()
    {
        base.Exit();
        SetCollider(2, new Vector3(0, 1, 0)); // ¬озвращаем коллайдер в исходное состо€ние
        moveorb.CanPlayAnimation = true;
        animator.ResetTrigger("SlideTr");
        Debug.Log("Sliding ended");

    }
    private void SetCollider(float height, Vector3 center)
    {
        collider.height = height;
        collider.center = center;
    }
}
#endregion
