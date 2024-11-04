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
    
   public int buttonspressed;

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
       
      Debug.Log(buttonspressed);

        if (buttonspressed >= 3)
        {
            Destroy(gameObject);
        }


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
