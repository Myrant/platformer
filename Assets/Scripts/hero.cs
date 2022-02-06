using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpforce = 7f;
    [SerializeField] private float minGroundAngle = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isGrounded = false;


    private Controls inputs;
    private List<ContactPoint2D> con = new List<ContactPoint2D>();
    // Start is called before the first frame update

    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        inputs = GetComponent<Controls>();
    }

    private void Run()
    {
        
        
        
       // sprite.flipX = dir.x < 0.0f;
    }
    private void jump()
    {
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        con.Clear();
        rb.GetContacts(con);
        for(int i = 0; i < con.Count; i++)
        {
            Debug.DrawLine(con[i].point, con[i].point + con[i].normal, Color.white);
            if (Vector2.Dot(con[i].normal, Vector2.up) > minGroundAngle)
            {
                isGrounded = true;
                
            }
        }
    }
    void Start()
    {
        
    }

    private void move()
    {
        movement.x = inputs.dir * speed * Time.deltaTime;
        rb.position += movement;
    }
    private void move2()
    {
        movement = rb.position;
        movement.x += inputs.dir * speed * Time.deltaTime;
        rb.MovePosition(movement);
    }
    private void move3()
    {
        movement = rb.velocity;
        movement.x = inputs.dir * speed * Time.deltaTime;
        rb.velocity = movement;
    }
    private void FixedUpdate()
    {
        isGrounded = false;

        CheckGround();
        move3();
        if (inputs.dir != 0)
        {
            if  (inputs.dir < 0)
            {
                sprite.flipX = true;
            } else
            {
                sprite.flipX = false;
            }
        }
 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump();
        }

    }
}
