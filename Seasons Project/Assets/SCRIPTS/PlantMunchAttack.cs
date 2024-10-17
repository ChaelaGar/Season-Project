using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMunchAttack : MonoBehaviour
{
    float timer = 0;
    float attackTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
   
            if (timer >= attackTime) 
        {
            
        }
    }
}
