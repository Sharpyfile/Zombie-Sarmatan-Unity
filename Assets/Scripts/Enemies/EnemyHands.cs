using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHands : MonoBehaviour
{
    public EnemyAttack attack;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            attack.DealDamage();
    }
}
