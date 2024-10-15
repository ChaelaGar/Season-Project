using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformerMovemenrt : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float sprintSpeed = 10f;
    [SerializeField]
    float jumpSpeed = 2f;
    [SerializeField]
    float slideSpeed = 2f;
    [SerializeField]
    bool grounded = false;
    [SerializeField]
    bool sliding = false;
    bool dJump = false;
    float gravityCap = 3f;
    [SerializeField]
    float forceX = 100;
    [SerializeField]
    float forceY = 0;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spre;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spre = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
            dJump = true;
        }
        else if (Input.GetButtonDown("Jump") && dJump == true)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            dJump = false;
        }
        if (Input.GetButton("Fire3"))
        {
            velocity.x = moveX * sprintSpeed;
            rb.velocity = velocity;
        }
        anim.SetFloat("y", velocity.y);
        anim.SetBool("grounded", grounded);
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
        if (collision.gameObject.layer == 7)
        {
            sliding = true;
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            grounded = false;
        }
        if (collision.gameObject.layer == 7)
        {
            sliding = false;
            grounded = false;
        }
    }
}