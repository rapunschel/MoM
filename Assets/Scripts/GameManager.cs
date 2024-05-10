using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    bool gameHasEnded;

    
    public void CompleteLevel()
    {
        Debug.Log("Level Complete");
        //LevelComplete.levelScreen.SetActive(true);
    }


}
