using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen3 : MonoBehaviour
{
    public static bool buttonPushed3 = false;
    private void OnTriggerEnter(Collider other)
    {
        buttonPushed3 = true;
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPushed3 = false;
    }

}
