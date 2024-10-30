using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantMunchAttack : MonoBehaviour
{
    float timer = 0;
    float attackTime = 0.5f;
    float dmg = 1f;
    [SerializeField]
    public PlantMunchHealth Mhealth;
    public PlayerHealth PlayerH;
    Animator animator;
    [SerializeField]
    float AnimationTimeLength = 0.2f;
    SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

     
      if (timer >= attackTime && collision.gameObject.tag == "Player" && Mhealth.isDead != true)
        {
            StartCoroutine(PlayAnimation());
            Debug.Log("BAM");
            PlayerH.health -= 1;
            timer = 0;
           
        }
    }
   
    IEnumerator PlayAnimation()
    {
        animator.Play("attack");
        yield return new WaitForSeconds(AnimationTimeLength);
        animator.Play("Idle");
    }
}
