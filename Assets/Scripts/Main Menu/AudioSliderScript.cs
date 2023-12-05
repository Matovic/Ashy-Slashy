using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Main_Menu
{
    public class AudioSliderScript : MonoBehaviour
    {
        private Slider _slider;
        [SerializeField] private AudioSource soundtrack;
        [FormerlySerializedAs("_sliderText")] [SerializeField]private TextMeshProUGUI sliderText;
        private void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener((newValue) =>
            {
                sliderText.text = newValue.ToString("Audio: 0 %");
                soundtrack.volume = newValue;
            });
        }
    }
}
