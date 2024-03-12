using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject flipModel;

    //audio option
    public AudioClip[] idleSounds;
    public float idleSoundTime;
    AudioSource enemyMoveAS;
    float nextIdleSound = 0f;

    public float detectionTime;
    float startRun;
    bool firstDectection;

    public float runSpeed;
    public float walkSpeed;
    public bool facingRight = true;

    float moveSpeed;
    bool running;

    Rigidbody rb;
    Animator anim;
    Transform detectedPlayer;

    bool Detected;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        enemyMoveAS = GetComponent<AudioSource>();

        running = false;
        Detected = false;
        firstDectection = false;
        moveSpeed = walkSpeed;

        if (Random.Range(0, 10) > 5) Flip();
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Detected)
        {
            if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();

            if (!firstDectection)
            {
                startRun = Time.time + detectionTime;
                firstDectection=true;
            }
            
        }
        if (Detected && !facingRight) rb.velocity = new Vector3((moveSpeed * -1), rb.velocity.y, 0);
        else if(Detected && facingRight) rb.velocity = new Vector3(moveSpeed,rb.velocity.y, 0);

        if(!running && Detected)
        {
            if (startRun<Time.time)
            {
                moveSpeed = runSpeed;
                anim.SetTrigger("Run");
                running = true;
            }
        }

        if (!running)
        {
            if((Random.Range(0, 10) > 5) && nextIdleSound < Time.time) {
                AudioClip tempClip = idleSounds[Random.Range(0, idleSounds.Length)];
                enemyMoveAS.clip = tempClip;
                enemyMoveAS.Play();
                nextIdleSound = idleSoundTime+Time.time;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !Detected)
        {
            Detected = true;
            detectedPlayer = other.transform;
            anim.SetBool("Detected",Detected);
            if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            firstDectection = false;
            if (running)
            {
                anim.SetTrigger("Run");
                moveSpeed = walkSpeed;
                running = false;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = flipModel.transform.localScale;
        theScale.z *= -1;
        flipModel.transform.localScale = theScale;
    }
}
