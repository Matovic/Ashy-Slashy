using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameOptions : MonoBehaviour
{
    private const int MaxEnemySpawnEasy = 13;
    private const int MaxEnemySpawnNormal = 30;
    private const int MaxEnemySpawnHard = 60;
    private const float EnemyIntervalEasy = 1.5f;
    private const float EnemyIntervalNormal = 1.0f;
    private const float EnemyIntervalHard = 0.5f;
    [SerializeField] private GameObject mainMenuScreen;

    private void NewGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    
    public void Back()
    {
        gameObject.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    
    public void EasyOption()
    {
        PlayerPrefs.SetInt("maxEnemySpawn", MaxEnemySpawnEasy);
        PlayerPrefs.SetFloat("enemyInterval", EnemyIntervalEasy);
        NewGame();
    }
    
    public void NormalOption()
    {
        PlayerPrefs.SetInt("maxEnemySpawn", MaxEnemySpawnNormal);
        PlayerPrefs.SetFloat("enemyInterval", EnemyIntervalNormal);
        NewGame();
    }
    
    public void HardOption()
    {
        PlayerPrefs.SetInt("maxEnemySpawn", MaxEnemySpawnHard);
        PlayerPrefs.SetFloat("enemyInterval", EnemyIntervalHard);
        NewGame();
    }
}