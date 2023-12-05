using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class NewGameOptions : MonoBehaviour
    {
        private int _maxEnemySpawn = 13;
        private float _enemyInterval = 1.5f;
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private AudioSource soundtrack;

        private void NewGame()
        {
            PlayerPrefs.SetInt("maxEnemySpawn", _maxEnemySpawn);
            PlayerPrefs.SetFloat("enemyInterval", _enemyInterval);
            PlayerPrefs.SetFloat("volume", soundtrack.volume);
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
            NewGame();
        }
    
        public void NormalOption()
        {
            _maxEnemySpawn = 30;
            _enemyInterval = 1.0f;
            NewGame();
        }
    
        public void HardOption()
        {
            _maxEnemySpawn = 60;
            _enemyInterval = 0.5f;
            NewGame();
        }
    }
}