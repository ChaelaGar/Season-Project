using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.1f;
    [SerializeField]
    float bulletAmount = 10f;
    [SerializeField]
    bool bulletEnabled = true;
    [SerializeField]
    bool shootingEnabled = true;
    [SerializeField]
    float shootingReloads = 3f;
    [SerializeField]
    bool BulletPackPickup = false;
    [SerializeField]
    bool isShooting = false;
    Animator anim;
    float AnimTimeLength = 2f;
    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        //IF youc click
        if (Input.GetButton("Fire1") && timer > shootDelay && bulletEnabled == true && shootingEnabled == true)
        {
            isShooting = true;
            bulletAmount -= 1;
            timer = 0;
            //shoot towards the mouse cursor
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Vector3 mouseDir = mousePos - transform.position;
            //normalize the vector so we don't have wonky speeds
            mouseDir.Normalize();
            //spawn in the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet towards the mouse
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            isShooting = false;
        }
        else
        {
            if (bulletAmount <= 0)
            {
                bulletEnabled = false;
              
            }
        }
        anim.SetBool("atk", isShooting);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AmmoPack")
            {
                Destroy(collision.gameObject);
                bulletAmount += 10;
            }
    }
   
   
    private IEnumerator PlayLAnimation()
    {
        anim.Play("LouisThrow");
        yield return new WaitForSeconds(AnimTimeLength);
        anim.Play("idle");
    }
}