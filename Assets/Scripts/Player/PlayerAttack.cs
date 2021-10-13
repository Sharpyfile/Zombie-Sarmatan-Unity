using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    Transform cameraTransform;
    RaycastHit hit;
    public GameObject mainWeapon;
    public GameObject secondaryWeapon;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
            float damage = mainWeapon.GetComponentInChildren<WeaponStatistics>().PerformAttack();
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 5.0f))
            {
                string tag = CheckRaycast(hit,5.0f, Color.red);
                switch(tag)
                {
                    case "Enemy":                        
                        hit.transform.GetComponent<EnemyHealth>().GetHit(damage);              
                        break;
                    
                    default:
                        break;
                }
            }
        }
        if (Input.GetButton("Fire2"))
        {
            float damage = secondaryWeapon.GetComponentInChildren<WeaponStatistics>().PerformAttack();
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100.0f))
            {
                string tag = CheckRaycast(hit, 100.0f, Color.red);
                switch(tag)
                {
                    case "Enemy":                        
                        hit.transform.GetComponent<EnemyHealth>().GetHit(damage);              
                        break;
                    
                    default:
                        break;
                }
            }
        }
        if (Input.GetButtonDown("Use"))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 5.0f))
            {
                string tag = CheckRaycast(hit, 10.0f, Color.red);
                switch(tag)
                {
                    case "Door":
                        hit.transform.GetComponent<DoorManager>().CycleDoors();
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }

    private string CheckRaycast(RaycastHit raycastHit, float distance, Color color)
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, distance))
        {
            Debug.DrawRay(cameraTransform.transform.position, cameraTransform.forward * distance, color);
            return hit.transform.tag;
        }
        else
            return "Nothing";
    }

}

