using UnityEngine;

namespace Main_Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject newGameScreen;
        [SerializeField] private GameObject settingsScreen;
        public void NewGame()
        {
            gameObject.SetActive(false);
            newGameScreen.SetActive(true);
        }
        public void Settings()
        {
            gameObject.SetActive(false);
            settingsScreen.SetActive(true);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}