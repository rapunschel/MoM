using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Collecter : MonoBehaviour
{
    public GameObject level;
    public int Diamonds;
    public UnityEvent<PlayerCollection> OndiamondCollected;
    

    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();

        if (playerCollection != null && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
        }

        if (playerCollection.NumberOfDiamonds == Diamonds)
        {
            level.SetActive(true);

        }
    }
}
