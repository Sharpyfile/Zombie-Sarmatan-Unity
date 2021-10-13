using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatistics : MonoBehaviour
{
   // Start is called before the first frame update
    public enum WeaponType {MAIN_WEAPON, SECONDARY_WEAPON};
    public WeaponType type;
    public float attackCooldown = 1.0f;
    public float damage = 10.0f;
    private float timeStamp;
    private Animator animator;
    private string animationName;
    private void Start()
    {
        animator = GetComponent<Animator>();
        timeStamp = Time.time;
        switch(type)
        {
            case WeaponType.MAIN_WEAPON:
                animationName = "Main Attack";
                break;
            case WeaponType.SECONDARY_WEAPON:
                animationName = "Secondary Attack";
                break;
        }
    }

    public float PerformAttack()
    {
        if (Time.time > timeStamp)
        {
            animator.Play(animationName);
            timeStamp = Time.time + attackCooldown;
            return damage;            
        }
        return 0.0f;
    }

}
