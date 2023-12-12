using TMPro;
using UnityEngine;
using Player;

namespace UI
{
    public class StaminaTextScript : MonoBehaviour
    {
        [SerializeField] PlayerMovement _playerScript;
        [SerializeField] TextMeshProUGUI _tmp;

        private void Update()
        {
            _tmp.text = _playerScript.GetStamina().ToString("F2") + " / " + _playerScript.GetStaminaMax().ToString();
        }
    }
}
