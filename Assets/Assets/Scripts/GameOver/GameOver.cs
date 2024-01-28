using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton(){
        SceneManager.LoadScene("Game");
        
        Debug.Log("Play");
    }
    public void MainMenuButton(){
        SceneManager.LoadScene("Menu");

        Debug.Log("Main Menu");
    }
}
