using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private GameObject settingsScreen;
        [SerializeField] private GameObject pauseBackground;
        private bool isInSubMenu;

        public void RestartGame()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Scenes/SampleScene");
        }
        public void Settings()
        {
            pauseBackground.SetActive(false);
            settingsScreen.SetActive(true);
            isInSubMenu = true;
        }
        public void ContinueGame()
        {
            Time.timeScale = 1.0f;
            pauseBackground.SetActive(false);
        }
    
        public void ReturnMainMenu()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public void PauseGame()
        {
            Time.timeScale = 0.0f;
            pauseBackground.SetActive(true);
        }
        
        public void CloseSettings()
        {
            //settingsScreen.SetActive(false);
            //pauseBackground.SetActive(true);
            isInSubMenu = false; 
        }

        void Update()
        {
            var pauseButtonDown = Input.GetButtonDown("Cancel");
            if (pauseButtonDown && !isInSubMenu)
            {
                if (pauseBackground.activeSelf)
                    ContinueGame();
                else PauseGame();
            }
        }
    }
}