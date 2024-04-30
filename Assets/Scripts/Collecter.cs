using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{
    public GameObject diamond;
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (playerCollection != null)
        {
            playerCollection.DiamondCollected();
            playerMovement.speed = 2;

        }
        diamond.SetActive(false);
    }
}
