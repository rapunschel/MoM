using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIamond : MonoBehaviour
{
    public GameObject diamond;


    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (playerCollection != null)
        {
            gameObject.SetActive(false);
            playerMovement.speed = 1;
            
        }
        diamond.SetActive(true);
    }


}
