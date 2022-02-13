using UnityEngine;

public class PlayerInAirState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.SetAnimation(1);
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void FixedUpdateState(PlayerStateManager player)
    {
        player.Move();
        player.FlipSide();
        if (player.IsGrounded())
        {
            player.SwitchState(player.OnGroundState);
        }
    }

    
}
