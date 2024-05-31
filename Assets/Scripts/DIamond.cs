using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DIamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        
    
        if (playerCollection != null && CarryDiamond.hasDiamond == false)
        {
            gameObject.SetActive(false);
        }
    }
}
