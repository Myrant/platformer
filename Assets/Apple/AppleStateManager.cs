using UnityEngine;

public class AppleStateManager : MonoBehaviour
{
    AppleBaseState currentState;
    public AppleGreenState GreenState = new AppleGreenState();
    public AppleRedState RedState = new AppleRedState();

    void Start()
    {
        currentState = RedState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AppleBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
