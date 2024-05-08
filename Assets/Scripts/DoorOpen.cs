using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public static bool buttonPushed = false;
    private void OnTriggerEnter(Collider other)
    {
        buttonPushed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPushed = false;
    }

}
