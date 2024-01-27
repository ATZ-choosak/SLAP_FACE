using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAndPause : MonoBehaviour
{
    public GameObject menuCanvas; 
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        // Toggle the menu canvas on and off
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
            Cursor.lockState = CursorLockMode.None;
        }

        // Pause or unpause the game
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f; // Unpause the game
        }
        else
        {
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void LoadMenuScene()
    {
        
        SceneManager.LoadScene("Menu");
        
        
    }
}
