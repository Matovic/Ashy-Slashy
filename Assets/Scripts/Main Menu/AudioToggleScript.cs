using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Main_Menu
{
    public class AudioToggleScript : MonoBehaviour
    {
        private Toggle _toggle;
        [SerializeField] private AudioSource soundtrack;
        [SerializeField] private TextMeshProUGUI audioText;
        private void Start()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener((newValue) =>
            {
                var status = newValue == true ? "on" : "off";
                audioText.text = $"Audio: {status}";
                soundtrack.mute = !newValue;
            });
        }
    }
}
