using UnityEngine;

public abstract class PlayerBaseState

{
    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);

    public abstract void FixedUpdateState(PlayerStateManager player);
    /*
    public bool IsGrounded(PlayerStateManager player)
    {
        bool result = false;
        player.con.Clear();
        player.rb.GetContacts(player.con);
        for (int i = 0; i < player.con.Count; i++)
        {
            Debug.DrawLine(player.con[i].point, player.con[i].point + player.con[i].normal, Color.white);
            if (Vector2.Dot(player.con[i].normal, Vector2.up) > player.minGroundAngle)
            {
                result = true;
            }
        }
        return result;
    }
    */
}
