using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouisAttack : MonoBehaviour
{

    [SerializeField]
    float attackDmg = 2f;

    public bool isAttacking = false;

    float coolDown;
    [SerializeField]
    float coolDownTime = 0.5f;
    float attackTime;
    [SerializeField]
    float attackDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;
        attackTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && coolDown >= coolDownTime)
        {
            Debug.Log("eggsbene");
            attackTime = 0f;
            coolDown = 0f;
            isAttacking = true;
        }
        else if (attackTime >= attackDuration && isAttacking)
        {
            Debug.Log("Staph");
            isAttacking = false;
        }
    }
}
