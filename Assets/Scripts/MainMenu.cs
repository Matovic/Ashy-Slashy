using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("NewGame");
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
}