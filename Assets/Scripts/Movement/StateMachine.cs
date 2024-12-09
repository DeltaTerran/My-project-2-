using System;
using System.Timers;
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
    public virtual void Enter() { SwipeDetector.OnSwipe += HandleSwipe; }

   

    public virtual void Update() { }
    public virtual void Exit() { SwipeDetector.OnSwipe -= HandleSwipe; }
    public virtual void HandleSwipe(SwipeDetector.PlayerSwipeDetector detector) { }
    public virtual void SetCollider(float height, Vector3 center) 
    {
        collider.height = height;
        collider.center = center;
    }
}

#region States
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
public class JumpingState : State
{
    private float jumpDuration = 1.5f;
    private float elapsedTime = 0;
    //private bool isJumping = false;
    public JumpingState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator,collider) { }

   

    public override void Enter()
    {
        base.Enter();
        //isJumping = true;
        animator.SetTrigger("JumpTr");
        SetCollider(2, new Vector3(0, 3.5f, 0)); // Меняем высоту и центр коллайдера
        Debug.Log("Jumping started");
    }

    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;
        //if (!isJumping) return;
        //jumpDuration -= Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.DownArrow)) // Переход в кувырок
        //{
        //    PlayerStateMachine.Instance.ChangeState(new JumpRollState(player, animator, collider));
        //    return;
        //}
        Debug.Log(elapsedTime);
        if (elapsedTime >= jumpDuration)
        {
            //isJumping = false;
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        }
        //jumpDuration -= Time.deltaTime;
        //if (jumpDuration < 0)
        //{
        
        //    PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        //}
        //if (player.transform.position.y <= 1f)
        //{
        //    PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));

        //}
    }
    public override void HandleSwipe(SwipeDetector.PlayerSwipeDetector direction)
    {
        if (direction == SwipeDetector.PlayerSwipeDetector.Down)
        {
            PlayerStateMachine.Instance.ChangeState(new JumpSlideState(player, animator, collider));
        }
    } 
    public override void Exit()
    {
        base.Exit();
        SetCollider(2, new Vector3(0, 1, 0));
        //moveorb.CanPlayAnimation = true;
        animator.ResetTrigger("JumpTr");
        Debug.Log("Jumping ended");
    }
    
}

public class SlidingState : State
{
    private float slideDuration = 1.5f;
    private float elapsedTime = 0f;
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
        elapsedTime += Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.UpArrow)) // Переход в прыжок
        //{
        //    PlayerStateMachine.Instance.ChangeState(new JumpingState(player, animator, collider));
        //    return;
        //}

        // Завершаем кувырок
        if (elapsedTime >= slideDuration)
        {
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        }
    }
    public override void HandleSwipe(SwipeDetector.PlayerSwipeDetector direction)
    {
        if (direction == SwipeDetector.PlayerSwipeDetector.Up)
        {
            PlayerStateMachine.Instance.ChangeState(new JumpingState(player, animator, collider));
        }
    }
    public override void Exit()
    {
        base.Exit();
        SetCollider(2, new Vector3(0, 1, 0)); // Возвращаем коллайдер в исходное состояние
        //moveorb.CanPlayAnimation = true;
        animator.ResetTrigger("SlideTr");
        Debug.Log("Sliding ended");

    }
}
public class JumpSlideState : State
{
    private float _rollDuration = 0.9f;
    public JumpSlideState(GameObject player, Animator animator, CapsuleCollider collider) : base(player, animator, collider)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("EnterJumpSlide");
        animator.SetTrigger("JumpSlideTr");
        SetCollider(1, new Vector3(0, 0.5f, 0));
    }

    

    public override void Update()
    {
       
        base.Update();
        _rollDuration -= Time.deltaTime;
        if (_rollDuration <= 0)
        {
            PlayerStateMachine.Instance.ChangeState(new RunningState(player, animator, collider));
        }

    }
    
    public override void Exit()
    {
        base.Exit();
        Debug.Log("ResetJumpSlide");
        SetCollider(2, new Vector3(0, 1, 0));
        animator.ResetTrigger("JumpSlideTr");
    }
}
#endregion
