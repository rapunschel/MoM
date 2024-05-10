using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{
    public GameObject diamond;
    public GameManager manager;
    public GameObject level;
    public int numberOfDiamonds;
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (playerCollection != null && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
            playerMovement.speed = 2;
            CarryDiamond.hasDiamond = false;

        }
        if (PlayerCollection.NumberOfDiamonds == numberOfDiamonds)
        {
            level.SetActive(true);

        }
        diamond.SetActive(false);
    }
}
