using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float minimalDistance = 30.0f;
    public float enemyMoveSpeed = 2.0f;
    CharacterController characterController;

    public float rotationSpeed = 1.0f;
    Quaternion lookRotation;
    Vector3 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);

        Vector3 eulerAngles = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        lookRotation = Quaternion.Euler(eulerAngles);

        transform.rotation = lookRotation;

        //Aggro check
        if (Vector3.Distance(transform.position, player.transform.position) < minimalDistance)
            MoveTowardsTarget(player.transform.position);
    }

    void MoveTowardsTarget(Vector3 target)
    {
        Vector3 offset = player.transform.position - transform.position;
        if (offset.magnitude > 0.1f)
        {
            offset.Normalize();
            offset *= enemyMoveSpeed;
            characterController.Move(offset * Time.deltaTime);
        }
    }
}
