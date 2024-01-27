using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Playgame()
    {
        SceneManager.LoadSceneAsync("Game");
        
        Debug.Log("Play");
    }
    public void QuitGmae()
    {
        Application.Quit();
    }
    public void GoBack()
    {
        SceneManager.LoadSceneAsync("Menu");
        Debug.Log("Goback");

    }
}
