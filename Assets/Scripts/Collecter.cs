using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Collecter : MonoBehaviour
{
    public GameObject level;
    public int diamonds = 0;
    public GameObject diamond1;
    public GameObject diamond2;
    public GameObject diamond3;
    public GameObject diamond4;
    public GameObject diamond5;


    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();

        if (diamonds == 0 && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
            diamond1.SetActive(true);
            diamonds++;
        }
        else if (diamonds == 1 && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
            diamond2.SetActive(true);
            diamonds++;
        }
        else if (diamonds == 2 && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
            diamond3.SetActive(true);
            diamonds++;
        }
        else if (diamonds == 3 && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
            diamond4.SetActive(true);
            diamonds++;
        }
        else if (diamonds == 4 && CarryDiamond.hasDiamond == true)
        {
            playerCollection.DiamondCollected();
            diamond5.SetActive(true);
            level.SetActive(true);
        }
    }

}
