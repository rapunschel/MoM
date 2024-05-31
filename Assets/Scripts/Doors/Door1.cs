using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (DoorOpen1.buttonPushed1 == true)
        {
            animator.SetBool("Activated", true);
        }
        else
        {
            animator.SetBool("Activated", false);
        }
    }


}
