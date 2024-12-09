using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private State currentState;

    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        
        currentState?.Update();
        
    }
}
