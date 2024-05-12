using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollection : MonoBehaviour
{
   public int NumberOfDiamonds {  get; private set; }

   public UnityEvent<PlayerCollection> OnDiamondCollected;

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        OnDiamondCollected.Invoke(this);
    }
}
