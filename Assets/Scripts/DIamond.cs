using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollection playerCollection = other.GetComponent<PlayerCollection>();

        if (playerCollection != null)
        {
            playerCollection.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}
