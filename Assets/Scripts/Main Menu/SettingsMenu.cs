using UnityEngine;

namespace Main_Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject controlsScreen;
        [SerializeField] private GameObject audioScreen;
        public void ControlsSettings()
        {
            gameObject.SetActive(false);
            controlsScreen.SetActive(true);
        }
        public void AudioSettings()
        {
            gameObject.SetActive(false);
            audioScreen.SetActive(true);
        }
        public void Back()
        {
            gameObject.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
    }
}
