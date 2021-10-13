using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    bool isOpen = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CycleDoors()
    {
        if (!isOpen)
        {
            Debug.Log("Opening");
            animator.Play("OpenDoors");
            isOpen = true;
        }
        else
        {
            Debug.Log("Closing");
            animator.Play("CloseDoors");
            isOpen = false;
        }
            
    
    }
}
