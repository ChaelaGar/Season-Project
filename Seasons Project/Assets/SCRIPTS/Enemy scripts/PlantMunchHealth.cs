using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantMunchHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float enemyHealth = 20;
    float maxHP;
    Animator animator;
    float AnimationTimeLength = 0.2f;
    public bool isDead = false;
    float hurtTimer;
    float hurtCoolDown = 0.1f;
    public LouisAttack attack;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hurtTimer += Time.deltaTime;
    }
    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "AOA" && enemyHealth > 0 && hurtTimer >= hurtCoolDown && attack.isAttacking)
        {
            StartCoroutine(PlayAnimationHurt());
            enemyHealth = enemyHealth -= 1;
            hurtTimer = 0f;
        }
       else if (enemyHealth < 1)
        {
            isDead = true;
            StartCoroutine(PlayAnimationDead());
         
        }
    }
    IEnumerator PlayAnimationHurt()
    {
        animator.Play("hurt");
        yield return new WaitForSeconds(AnimationTimeLength);
        animator.Play("Idle");
    }
    IEnumerator PlayAnimationDead()
    {
        animator.Play("dead");
        yield return new WaitForSeconds(AnimationTimeLength);
       
    }
}
