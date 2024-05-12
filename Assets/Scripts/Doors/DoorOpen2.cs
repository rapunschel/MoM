using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen2 : MonoBehaviour
{
    public static bool buttonPushed2 = false;
    private void OnTriggerEnter(Collider other)
    {
        buttonPushed2 = true;
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPushed2 = false;
    }

}
