using System.Collections;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PopUpText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPopUp;
        private GameObject _player;
        private Inventory inventory;

        private void Start()
        {
            textPopUp.enabled = false;
            _player = GameObject.FindWithTag("Player");
            inventory = _player.GetComponent<Inventory>();
        }
        void Update()
        {
            var potions = inventory.GetPotions();
            if (potions.Count == 0) return;
            var pGrowth = potions.Find(x => x.PotionType == "growth");
            var pShrink = potions.Find(x => x.PotionType == "shrink");
            if (pShrink != null)
            {
                StartCoroutine(ShowMessage("I can use this!", 2));
            }
        }
        
        IEnumerator ShowMessage (string message, float delay) {
            textPopUp.enabled = true;
            textPopUp.text = message;
            yield return new WaitForSeconds(delay);
            textPopUp.enabled = false;
        }
    }
}
