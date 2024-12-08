using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFun : MonoBehaviour
{
    //Ints and floats
    [SerializeField]
    float walkSpeed = 7f;
    float defaultWalkSpeed;
    [SerializeField]
    float sprintSpeed = 10f;
    [SerializeField]
    float jumpSpeed = 4f;
    float y;
    //Gravity related crud
    [SerializeField]
    float defaultGravity = 1.5f;
    [SerializeField]
    float fallStrength = 3f;
    [SerializeField]
    float slideSpeed = 35f;
    float slideMomentum;

    //Timers
    [SerializeField]
    float coyoteTimer = 0.2f;
    float coyoteTime;
    [SerializeField]
    float jumpGraceTimer = 0.1f;
    float jumpGraceTime = 1000f;
    float AnimationTimeLength = 0.2f;

    //Bools
    [SerializeField]
    bool grounded = false;
    bool slide = false;
    bool atking;
   
    //Components 
    Rigidbody2D rb;
    public Animator anim;
    SpriteRenderer spre;

    //Public References
    public bool isFlipped = false;
    public LouisAttack atk;


    // Start is called before the first frame update
    void Start()
    {
        defaultWalkSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spre = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Status checks
        y = GetComponent<Rigidbody2D>().velocity.y;
        //walking things
        Walk();

        if (Input.GetButtonDown("Fire3"))
        {
            walkSpeed = sprintSpeed;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            walkSpeed = defaultWalkSpeed;
        }
        //jumping things
        if (Input.GetButtonDown("Jump") && grounded || Input.GetButtonDown("Jump") && coyoteTime <= coyoteTimer && y <= 0 || grounded && jumpGraceTime <= jumpGraceTimer)
        {
            Jump();
        }
        else if (Input.GetButtonUp("Jump") && !grounded)
        {
            rb.gravityScale = fallStrength;
        }
        else if (Input.GetButtonDown("Jump") && !grounded)
        {
            jumpGraceTime = 0;
        }

       
        //Timers
        coyoteTime += Time.deltaTime;
        jumpGraceTime += Time.deltaTime;

        //anime stuff
        Animation();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
            coyoteTime = 0;
        }
        else if (collision.gameObject.layer == 7)
        {
            slide = false;
            slideMomentum = 0;
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.gravityScale = defaultGravity;
            grounded = true;
           

        }
        if (collision.gameObject.layer == 7)
        {
            slide = true;
            slideMomentum += 0.1f;
            rb.gravityScale = slideSpeed * slideMomentum;
        }
    }
    void Walk()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * walkSpeed;
        rb.velocity = velocity;

    }
    void Jump()
    {
        rb.AddForce(new Vector2(0, 100 * jumpSpeed));
        grounded = false;
        
    }
    void Animation()
    {
        anim.SetFloat("y", y);
        anim.SetBool("grounded", grounded);
        anim.SetBool("slope", slide);
    
        int x = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("x", x);
        if (x > 0)
        {
            spre.flipX = false;
            isFlipped = false;
        }
        else if (x < 0)
        {
            spre.flipX = true;
            isFlipped = true;
        }
     
    }
  
}
