using TMPro;
using UnityEngine;

namespace Player
{
    public class StaminaTextScript : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private PlayerMovement _playerScript;
        private TextMeshProUGUI _tmp;
        // Start is called before the first frame update
        private void Start()
        {
            _tmp = gameObject.GetComponent<TextMeshProUGUI>();
            _playerScript = player.GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        private void Update()
        {
            _tmp.text = _playerScript.GetStamina().ToString("F2") + " / " + _playerScript.GetStaminaMax().ToString();
        }
    }
}
