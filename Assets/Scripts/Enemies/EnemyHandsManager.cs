using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyAttack enemyAttack;

    void CycleAttackCollider()
    {
        enemyAttack.CycleAttackCollider();
    }
}
