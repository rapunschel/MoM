using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public static bool buttonPushed;
    private void OnTriggerEnter(Collider other)
    {
        buttonPushed = true;
    }
}
