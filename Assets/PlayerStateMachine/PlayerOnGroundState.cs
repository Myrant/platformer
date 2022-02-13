using UnityEngine;


public class PlayerOnGroundState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.SetAnimation(0);
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
            player.Jump();
        } 
        else
        {
            player.SwitchState(player.InAirState);
        }
    }

    
}
