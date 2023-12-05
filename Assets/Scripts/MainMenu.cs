using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject newGameScreen;
    public void NewGame()
    {
        gameObject.SetActive(false);
        newGameScreen.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}