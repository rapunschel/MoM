using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour
{
    public static bool buttonPushed1 = false;
    private void OnTriggerEnter(Collider other)
    {
        buttonPushed1 = true;
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPushed1 = false;
    }

}
