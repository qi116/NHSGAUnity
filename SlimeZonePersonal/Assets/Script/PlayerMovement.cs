using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int speed = 10, jumpForce = 5;
    [SerializeField]
    float horizMove = 0f;

    private Rigidbody2D rb;

    private bool right = true;

    //For this fancy Smooth Damp movement
    private Vector3 startVelocity = Vector3.zero;
    private float smoothTime = 0.5f;

    private PlayerState state;

    private Animator anim;

    enum PlayerState
    {
        Idle,
        Move,
        Flat
    }

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        state = PlayerState.Idle;
        anim = this.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizMove = Input.GetAxisRaw("Horizontal") * speed;

        
    }
    private void FixedUpdate()
    {
        Move(horizMove);
    }
    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * speed, rb.velocity.y);

        if (state != PlayerState.Flat)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref startVelocity, smoothTime);
        }

        if (move > 0 && !right)
        {
            Flip();
        }
        else if (move < 0 && right)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.S) && state != PlayerState.Flat)
        {

            Flatten();
        }
        if (Input.GetKeyDown(KeyCode.W) && state == PlayerState.Flat)
        {

            Unflatten();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);

        }
    }
    //Plays flatten anim
    public void Flatten()
    {
        state = PlayerState.Flat;
        anim.SetBool("Flattening", true);
    }
    //Plays unflatten anim
    public void Unflatten()
    {
        state = PlayerState.Idle;
        anim.SetBool("Flattening", false);

    }
    //Do an 180
    public void Flip()
    {
        right = !right;
        transform.Rotate(0f, 180f, 0f);

    }
}
