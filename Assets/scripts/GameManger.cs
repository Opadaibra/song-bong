using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Transform pausePanel;
    private bool _isPaused = false;
    private playerMovment player;
    private void Start()
    {
        player= new playerMovment();
        if(SceneManager.GetActiveScene().buildIndex == 1)
        Cursor.visible = false;
        else
        {
            Cursor.visible = true;
            
        }
    }

    private void Update()
    {
        
        if (!pausePanel) return;
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused )
        {
            pausePanel.gameObject.SetActive(true);
            _isPaused = true;
            Time.timeScale = 0;
            Cursor.visible = true; // Show the mouse cursor when the pause menu is active
           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
        {
            pausePanel.gameObject.SetActive(false);
            
            _isPaused = false;
            Time.timeScale = 1;
            Cursor.visible = false; // Hide the mouse cursor when the pause menu is deactivated
        
        }
    }

    public void ClosePausePanel()
    {
        pausePanel.gameObject.SetActive(false);
        _isPaused = false;
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Cursor.visible = false; // Hide the mouse cursor when the pause menu is deactivated through the button
         
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Cursor.visible = false; // Hide the mouse cursor when the game is started
           
        }
        SceneManager.LoadScene(1);
    }

    public void AboutUs()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
