using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMunchHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float enemyHealth = 20;
    float maxeHP;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerAmmo")
        {

            enemyHealth = enemyHealth -= 1;
            if (enemyHealth <= 0)
            {

                Destroy(gameObject);
            }
        }
    }

}
