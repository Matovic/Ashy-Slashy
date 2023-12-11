using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [System.Serializable]
    public struct PotionUI
    {
        public Image potionImage;
        public TextMeshProUGUI tmp;
        public string potionType;
    }

    public class PotionsUIScript : MonoBehaviour
    {
        [SerializeField] Inventory inventory;
        [SerializeField] List<PotionUI> potionsUI;
        //private BoxCollider2D _boxCollider;
    
        void Start()
        {
            //_boxCollider = GetComponent<BoxCollider2D>();
        }
        void Update()
        {
            var potions = inventory.GetPotions();
            foreach (PotionUI pui in potionsUI)
            {
                var p = potions.Find(x => x.PotionType == pui.potionType);
                if (p == null)
                {
                    pui.potionImage.enabled = false;
                    pui.tmp.enabled = false;
                }
                else
                {
                    pui.potionImage.enabled = true;
                    pui.tmp.enabled = true;
                    pui.tmp.SetText(p.Count.ToString());
                }
            }
        }
    }
}