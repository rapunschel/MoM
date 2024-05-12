using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (DoorOpen3.buttonPushed3 == true)
        {
            animator.SetBool("Activated", true);
        }
        else
        {
            animator.SetBool("Activated", false);
        }
    }


}
