using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject icicle;
    public Transform bulletPos;
    private Animator anim;
    private float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetBool("IsShooting", true);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        

        if (distance < 30)
        {
            

            if (timer > 0.75)
            {
                timer = 0;
                shoot();

            }
        }
    }
    void shoot()
    {
        Instantiate(icicle, bulletPos.position, Quaternion.identity);
    }
}
