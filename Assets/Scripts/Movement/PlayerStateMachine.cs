using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerStateMachine Instance;
    private State currentState;

    private void Awake()
    {
        Instance = this;
    }
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
