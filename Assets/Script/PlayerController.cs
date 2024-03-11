using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float walkSpeed;

    private float move;
    private float sneaking;
    private Vector3 theScale;

    Rigidbody rb;
    Animator anim;

    bool facingRight;

    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    private void FixedUpdate()
    {

        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            anim.SetBool("Grounded", grounded);
            rb.AddForce(new Vector3(0,jumpHeight,0));
        }

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0) grounded = true;
        else grounded = false;

        anim.SetBool("Grounded", grounded);
        float firing = Input.GetAxis("Fire1");
        anim.SetFloat("Shooting", firing);

        move = Input.GetAxis("Horizontal");
        sneaking = Input.GetAxisRaw("Fire3");

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("Sneaking", sneaking);

        if ((sneaking > 0 || firing >0) && grounded)
        {
            
            rb.velocity = new Vector3(move * walkSpeed, rb.velocity.y, 0);

        }
        else
        {
            rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0);
        }


        

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    public float GetFacing()
    {
        if (facingRight) return 1;
        else return -1;
    }
}
