using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMsg;
        private string gameOverMsg = "You lost!", winMsg = "You won!";
        public void NewGame()
        {
            Debug.Log($"SampleScene");
            SceneManager.LoadScene("SampleScene");
        }
        public void MainMenu()
        {
            Debug.Log($"Main Menu");
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public void GameOver()
        {
            textMsg.text = gameOverMsg;
        }
        public void WinGame()
        {
            textMsg.text = winMsg;
        }
    }
}
