using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private GameObject settingsScreen;
        public void RestartGame()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Scenes/SampleScene");
        }
        public void Settings()
        {
            gameObject.SetActive(false);
            settingsScreen.SetActive(true);
        }
        public void ContinueGame()
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    
        public void ReturnMainMenu()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public void PauseGame()
        {
            Time.timeScale = 0.0f;
            gameObject.SetActive(true);
        }
    }
}