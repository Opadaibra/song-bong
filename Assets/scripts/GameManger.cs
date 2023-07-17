  using System;
  using UnityEngine;
  using UnityEngine.SceneManagement;

  public class GameManger : MonoBehaviour
  {
      public Transform pausePanel;
      private bool _isPaused = false;

      private void Update()
      {
          if(!pausePanel) return;
          if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
          {
              pausePanel.gameObject.SetActive(true);
              _isPaused = true;
              Time.timeScale = 0;
          }
          else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
          {
              pausePanel.gameObject.SetActive(false);
              _isPaused = false;
              Time.timeScale = 1;
          }
      }
      public void ClosePausePanel()
        {
            pausePanel.gameObject.SetActive(false);
            _isPaused = false;
        }
      
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(1);
        }
        
        public void StartGame()
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            SceneManager.LoadScene(0);
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
