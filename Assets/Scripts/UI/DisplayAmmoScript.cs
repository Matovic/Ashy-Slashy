using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DisplayAmmoScript : MonoBehaviour
    {
        private Inventory _inventory;
        private TextMeshProUGUI _ammoText;
    
        // Start is called before the first frame update
        void Start()
        {
            _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            _ammoText = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            _ammoText.text = _inventory.GetBullets().ToString();
        }
    }
}
