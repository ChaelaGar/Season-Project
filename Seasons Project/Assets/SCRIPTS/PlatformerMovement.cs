using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformerMovemenrt : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float sprintSpeed = 10f;
    [SerializeField]
    float jumpSpeed = 2f;
    [SerializeField]
    float slideSpeed = 40f;
    [SerializeField]
    bool grounded = false;
    [SerializeField]

    bool dJump = false;
    bool slope = false;
    float gravityCap = 3f;
    [SerializeField]
    float forceX = 100;
    [SerializeField]
    float forceY = 0;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spre;
    BulletSpawn bulletSpawn;
    float dirX;
    AudioSource audioSrc;
    bool isMoving = false;
    [SerializeField]
    float SoundTimeLength = 1f;
    [SerializeField]
    float CoyoteTimer = 0.2f;
    float CoyoteTime;
    float JumpCharge;
    float JumpChargeLimit = 150f;
    float GravTimer = 1f;
    float GravTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spre = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CoyoteTime += Time.deltaTime;
        GravTime += Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        /*if (Input.GetButton("Jump") && grounded)
        {

            JumpCharge += 50 * Time.deltaTime;
           
           if (JumpCharge > JumpChargeLimit)
            {
                JumpCharge = JumpChargeLimit;
            }
        
        }*/
       if (Input.GetButtonDown("Jump") && grounded || Input.GetButtonUp("Jump") && CoyoteTime <= CoyoteTimer)
        {
            JUMP();
        }
        /*else if (Input.GetButtonDown("Jump") && dJump == true)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            dJump = false;
        }*/
        if (Input.GetButton("Fire3"))
        {
            velocity.x = moveX * sprintSpeed;
            rb.velocity = velocity;
        }
        anim.SetFloat("y", velocity.y);
        anim.SetBool("grounded", grounded);
        anim.SetBool("slope", slope);
        int x = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("x", x);
        if (x > 0)
        {
            spre.flipX = false;
        }
        else if (x < 0)
        {
            spre.flipX = true;
        }
        if (grounded == true || slope == false)
        {
            rb.gravityScale = 1f;
        }
        else if (slope == true)
        {
            GravTime += 0.1f;
            rb.gravityScale = slideSpeed + GravTime;

        }

        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        if (rb.velocity.x != 0)
            isMoving = true;
        else 
            isMoving = false;
        if (isMoving && grounded && slope == false)
        {
            if (!audioSrc.isPlaying)
          
            StartCoroutine(PlayFootStep());
        }
       else 
           audioSrc.Stop();
    }

    IEnumerator PlayFootStep()
    {
        audioSrc.Play();
        yield return new WaitForSeconds(SoundTimeLength);
        audioSrc.Stop();
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
            slope = false;
            CoyoteTime = 0;
        }
        if (collision.gameObject.layer == 7)
        {
            slope = true;
            grounded = false;
            GravTime += 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            grounded = false;
            JumpCharge = 100;
        }
        if (collision.gameObject.layer == 7)
        {
            slope = false;
        }


    }
    void JUMP()
    {
        rb.AddForce(new Vector2(0, 100 * jumpSpeed));
        grounded = false;
        dJump = true;
        
    }
}