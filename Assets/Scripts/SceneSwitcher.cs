
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public void OpenScene(int index){
        SceneManager.LoadScene(index);
    }

    public void QuitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
