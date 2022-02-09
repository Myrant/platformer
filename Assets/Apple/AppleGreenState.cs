using UnityEngine;

public class AppleGreenState : AppleBaseState
{
    Vector3 StartSize = new Vector3(1.0f, 1.0f, 1.0f);
    Vector3 StepSize = new Vector3(0.2f, 0.2f, 0.2f);
    SpriteRenderer sprite;
    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("green");
        apple.transform.localScale = StartSize;
        sprite = apple.GetComponent<SpriteRenderer>();
        sprite.color = Color.green;
    }
    public override void UpdateState(AppleStateManager apple)
    {
        if (apple.transform.localScale.x > 0.1f)
        {
            apple.transform.localScale -= StepSize * Time.deltaTime;
        }
        else
        {
            apple.SwitchState(apple.RedState);
        }
    }
}
