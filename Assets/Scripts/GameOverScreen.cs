using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
