using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GroundorSloped : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    bool ground;
    [SerializeField]
    bool slope;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ground == true || slope == false)
        {
            rb.gravityScale = 1f;
        }
        else if (slope == true)
        {
            rb.gravityScale = 30f;
        }
        
  void OnTriggerEnter2D(Collider2D collision)
        {

        }

    }
}