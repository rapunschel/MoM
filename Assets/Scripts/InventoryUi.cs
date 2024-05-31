using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUi : MonoBehaviour
{

    private TextMeshProUGUI diamondText;

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateDiamondText(PlayerCollection playerCollection)
    {
        diamondText.text = playerCollection.NumberOfDiamonds.ToString();
    }
}
