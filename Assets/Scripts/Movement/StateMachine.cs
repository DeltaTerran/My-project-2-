using System;
using UnityEngine;

public abstract class State
{
    
    protected GameObject player;
    protected Animator animator;
    protected CapsuleCollider collider;
    protected PlayerStateMachine stateMachine;
    public State(GameObject player, Animator animator, CapsuleCollider collider, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.animator = animator;
        this.collider = collider;
        this.stateMachine = stateMachine;
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
    public RunningState(GameObject player, Animator animator, CapsuleCollider collider, PlayerStateMachine stateMachine) : base(player, animator, collider, stateMachine) { }



    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        //if (player.transform.position.y <= 1f)
        //{
        //    stateMachine.ChangeState(new RunningState(player, animator, collider));

        //}
    }
}
public class JumpingState : State
{
    private float jumpDuration = 2.24f;
    private float elapsedTime = 0;
    //private bool isJumping = false;
    public JumpingState(GameObject player, Animator animator, CapsuleCollider collider, PlayerStateMachine stateMachine) 
        : base(player, animator, collider, stateMachine) { }

   

    public override void Enter()
    {
        base.Enter();
        //isJumping = true;
        animator.SetBool("isJumping", true);
        SetCollider(2, new Vector3(0, 2.5f, 0)); // Меняем высоту и центр коллайдера
        //Debug.Log("Jump");
    }

    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;
        //if (!isJumping) return;
        //jumpDuration -= Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.DownArrow)) // Переход в кувырок
        //{
        //    stateMachine.ChangeState(new JumpRollState(player, animator, collider, st));
        //    return;
        //}
        //Debug.Log(elapsedTime);
        if (elapsedTime >= jumpDuration)
        {
            //isJumping = false;
            if (!PlayerController.JumpSliding)
            {
                stateMachine.ChangeState(new RunningState(player, animator, collider, stateMachine));
            }
        }
        //jumpDuration -= Time.deltaTime;
        //if (jumpDuration < 0)
        //{
        
        //    stateMachine.ChangeState(new RunningState(player, animator, collider));
        //}
        //if (player.transform.position.y <= 1f)
        //{
        //    stateMachine.ChangeState(new RunningState(player, animator, collider));

        //}
    }
    public override void HandleSwipe(SwipeDetector.PlayerSwipeDetector direction)
    {
        if (direction == SwipeDetector.PlayerSwipeDetector.Down)
        {
            stateMachine.ChangeState(new JumpSlideState(player, animator, collider, stateMachine));
        }
    } 
    public override void Exit()
    {
        base.Exit();
        SetCollider(2, new Vector3(0, 1, 0));
        animator.SetBool("isJumping", false);
        PlayerController.CanPlayAnimation = true;
        //animator.ResetTrigger("JumpTr");
        //Debug.Log("Jump end");
    }
    
}

public class SlidingState : State
{
    //private float slideDuration = 0.92f;
    private float slideDuration = 1.84f;
    private float elapsedTime = 0f;
    public SlidingState(GameObject player, Animator animator, CapsuleCollider collider, PlayerStateMachine stateMachine) : base(player, animator, collider, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        animator.SetBool("isSliding", true);
        //animator.SetBool("isAirborn", false);
        SetCollider(1, new Vector3(0, 0.5f, 0));
        //Debug.Log("Sliding");
    }

    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.UpArrow)) // Переход в прыжок
        //{
        //    stateMachine.ChangeState(new JumpingState(player, animator, collider));
        //    return;
        //}

        // Завершаем кувырок
        if (elapsedTime >= slideDuration)
        {
            stateMachine.ChangeState(new RunningState(player, animator, collider, stateMachine));
        }
    }
    //public override void HandleSwipe(SwipeDetector.PlayerSwipeDetector direction)
    //{
    //    if (direction == SwipeDetector.PlayerSwipeDetector.Up)
    //    {
    //        stateMachine.ChangeState(new JumpingState(player, animator, collider, stateMachine));
    //    }
    //}
    public override void Exit()
    {
        base.Exit();
        SetCollider(2, new Vector3(0, 1, 0)); // Возвращаем коллайдер в исходное состояние
        animator.SetBool("isSliding", false);
        PlayerController.CanPlayAnimation = true;
        PlayerController.JumpSliding = false;
        //animator.ResetTrigger("SlideTr");
        //Debug.Log("Sliding end");

    }
}
public class JumpSlideState : State
{
    //private float _rollDuration = 0.92f;
    public JumpSlideState(GameObject player, Animator animator, CapsuleCollider collider, PlayerStateMachine stateMachine) : base(player, animator, collider, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("JumpSlide");
        PlayerController.JumpSliding = true;
        PlayerController.CanPlayAnimation = false;
        //animator.SetBool("isAirborn", true);
        animator.SetTrigger("SlideTr");
        SetCollider(1, new Vector3(0, 0.5f, 0));
    }

    

    public override void Update()
    {
       
        base.Update();
        //_rollDuration -= Time.deltaTime;
        //if (_rollDuration <= 0)
        //{
        //    stateMachine.ChangeState(new SlidingState(player, animator, collider, stateMachine));
        //}
        stateMachine.ChangeState(new SlidingState(player, animator, collider, stateMachine));
    }
    
    public override void Exit()
    {
        base.Exit();
        //Debug.Log("JumpSlide end");
        //PlayerController.CanPlayAnimation = true;
        animator.ResetTrigger("SlideTr");
        SetCollider(2, new Vector3(0, 1, 0));
        //animator.ResetTrigger("JumpSlideTr");
    }
}
#endregion
