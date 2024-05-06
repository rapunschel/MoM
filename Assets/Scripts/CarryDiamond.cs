using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CarryDiamond : MonoBehaviour
{
    public GameObject diamond;
    public static bool hasDiamond;

    void Start()
    {
        diamond.SetActive(false);
        hasDiamond = false;
    }
   
}
