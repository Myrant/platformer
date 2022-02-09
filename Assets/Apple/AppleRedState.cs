using UnityEngine;

public class AppleRedState : AppleBaseState
{
    Vector3 StartSize = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 StepSize = new Vector3(0.2f, 0.2f, 0.2f);
    SpriteRenderer sprite;
    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("now its red state");
        apple.transform.localScale = StartSize;
        sprite = apple.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
    }
    public override void UpdateState(AppleStateManager apple)
    {
        if (apple.transform.localScale.x < 1)
        {
            apple.transform.localScale += StepSize * Time.deltaTime;
        } else
        {
            apple.SwitchState(apple.GreenState);
        }
    }
}
