using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI
{
    public class StaminaScript : MonoBehaviour
    {
        [SerializeField] PlayerMovement playerScript;
        [SerializeField] Image img;

        void Update()
        {
            img.fillAmount = playerScript.GetStamina() / playerScript.GetStaminaMax();
        }
    }
}
