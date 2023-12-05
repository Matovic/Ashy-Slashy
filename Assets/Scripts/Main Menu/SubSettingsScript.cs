using UnityEngine;

namespace Main_Menu
{
    public class SubSettingsScript : MonoBehaviour
    {
        [SerializeField] private GameObject settingScreen;
        
        public void Back()
        {
            gameObject.SetActive(false);
            settingScreen.SetActive(true);
        }
    }
}