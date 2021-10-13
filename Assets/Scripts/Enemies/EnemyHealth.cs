using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100.0f;
    public float currentHealth = 100.0f;

    public void GetHit(float incomingDamage)
    {
        currentHealth -= incomingDamage;
        if (currentHealth <= 0.0f)
            Destroy(gameObject);
    }

}
