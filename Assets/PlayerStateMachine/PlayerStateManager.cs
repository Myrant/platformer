using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerOnGroundState OnGroundState = new PlayerOnGroundState();
    public PlayerInAirState InAirState = new PlayerInAirState();

    public float speed = 300f;
    public float jumpforce = 7f;
    public float minGroundAngle = 0.5f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;


    private Controls inputs;
    private List<ContactPoint2D> con = new List<ContactPoint2D>();

    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        inputs = GetComponent<Controls>();
        animator = GetComponent<Animator>();
    }

    // state management
    void Start()
    {
        currentState = OnGroundState;
        currentState.EnterState(this);
    }

    
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    


    ////// methods
    public void SetAnimation(int value)
    {       
        animator.SetInteger("state", value);       
    }
    public bool IsGrounded()
    {
        bool result = false;
        con.Clear();
        rb.GetContacts(con);
        for (int i = 0; i < con.Count; i++)
        {
            Debug.DrawLine(con[i].point, con[i].point + con[i].normal, Color.white);
            if (Vector2.Dot(con[i].normal, Vector2.up) > minGroundAngle)
            {
                result = true;
            }
        }
        return result;
    }
    public void Jump()
    {
        if (inputs.keySpace)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }       
    }
    public void FlipSide()
    {
        if (inputs.dir != 0)
        {
            if (inputs.dir < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }
    public void Move()
    {
        movement = rb.velocity;
        movement.x = inputs.dir * speed * Time.deltaTime;
        rb.velocity = movement;
    }
}
