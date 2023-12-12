using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
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
}
