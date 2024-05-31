using Mirror.Examples.Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CarryDiamond : MonoBehaviour
{
    public static bool hasDiamond;

    void Start()
    {
        hasDiamond = false;
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Gem")
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            hasDiamond = true;
            //clientPlayer.speed = 1;
            
        }
        if (other.transform.tag == "Collecter")
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            hasDiamond = false;
        }
    }

}
