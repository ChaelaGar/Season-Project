using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float enemyHealth = 20;
    float maxHP;
   /* Animator animator;
    float AnimationTimeLength = 0.2f;
    public bool isDead = false;*/
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player ammo" && enemyHealth > 0)
        {
           // StartCoroutine(PlayAnimationHurt());
            enemyHealth = enemyHealth -= 1;
            
        }
        /* else if (enemyHealth < 1)
          {
            //  isDead = true;
             // StartCoroutine(PlayAnimationDead());

           //>PLACEHOLDER SCRIPT BELOW, USE IF NO ANIMATION<

        //Destroy(gameObject);
          }*/
    }
   /* IEnumerator PlayAnimationHurt()
    {
        animator.Play("hurt");
        yield return new WaitForSeconds(AnimationTimeLength);
        animator.Play("Idle");
    }
    IEnumerator PlayAnimationDead()
    {
        animator.Play("dead");
        yield return new WaitForSeconds(AnimationTimeLength);
       
    }*/
}
