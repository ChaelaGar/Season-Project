using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platformermov : MonoBehaviour
{
    [SerializeField]
    float MSpeed = 5f;
    [SerializeField]
    float JumpSp = 2f;
    bool grounded = true;
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
        velocity.x = moveX * MSpeed;
        rb.velocity = velocity;
        //if on ground
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * JumpSp));
            grounded = false;
        }
        anim.SetFloat("y", velocity.y);
        anim.SetBool("grounded", grounded);
        int x = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("x", x);
        if (x > 0)
        {
            spre.flipX = false;
        }else if(x < 0)
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
      else if (collision.gameObject.tag == "Reload level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
}
