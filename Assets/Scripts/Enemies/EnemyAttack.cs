using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public float attackDistance = 3.0f;
    public float attackCooldown = 1.0f;
    public float damageValue = 10.0f;
    Animator animator;
    bool areHandsActive = false;
    public GameObject attackCollider;

    //float timeStamp;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        //timeStamp = Time.time;
    }

    void Update()
    {
        //Debug.Log(Time.time > timeStamp);
        if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
        {
            animator.Play("Attack");
            //timeStamp = Time.time + attackCooldown;
        }
            
    }

    public void DealDamage()
    {
        //deal damage to player
        Debug.Log("Player got hit for: " + damageValue.ToString());
    }

    public void CycleAttackCollider()
    {
        attackCollider.SetActive(!areHandsActive);
    }
}
