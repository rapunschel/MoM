using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (DoorOpen2.buttonPushed2 == true)
        {
            animator.SetBool("Activated", true);
        }
        else
        {
            animator.SetBool("Activated", false);
        }
    }


}
