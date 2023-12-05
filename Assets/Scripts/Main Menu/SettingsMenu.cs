using UnityEngine;

namespace Main_Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuScreen;

        public void Back()
        {
            gameObject.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
    }
}
