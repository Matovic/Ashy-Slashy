using System;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    /*
     * Used for potion controls.
     */
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerMovement playerMovement;
        private bool allPotions = false;
        private const uint MaxPotions = 2;
        public bool HasWeapon { get; private set; }
        public bool NotCollectedAll { get; private set; }

        private void Update()
        {
            var potions = inventory.GetPotions();
            //if (potions.Count == 0) return;
            var pGrowth = potions.Find(x => x.PotionType == "growth");
            var pShrink = potions.Find(x => x.PotionType == "shrink");
            var fire = Input.GetButtonDown("Fire1");
            NotCollectedAll = false;
            /*if (fire)
            {
                Debug.Log($"pShrink:{pShrink}");
            }*/
            /*if (fire && !allPotions && (pShrink == null || pGrowth == null || 
                                    pShrink is not { Count: 2 } || pGrowth is not { Count: 2 }))
            {
                NotCollectedAll = true;
                return;
            }*/
            
            switch (allPotions)
            {
                case false when pShrink != null && pGrowth != null && 
                                pGrowth.Count == MaxPotions && pShrink.Count == MaxPotions:
                    allPotions = true;
                    break;
                case false when fire && (pShrink == null || pGrowth == null || 
                                         pShrink is not { Count: 2 } || pGrowth is not { Count: 2 }):
                    NotCollectedAll = true;
                    return;
                case false:
                    return;
            }
            HasWeapon = false;
            if (inventory.GetItemBool("weapon"))
            {
                HasWeapon = true;
                return;
            }
            if (fire)
                Use(pShrink != null && pGrowth != null && pGrowth.Count == pShrink.Count ? "shrink" : "growth");
        }

        private void Use(string type)
        {
            switch (type)
            {
                case "growth":
                    if (playerMovement.GetIsShrinked())
                    {
                        playerMovement.SetIsShrinked(false);
                    }
                    break;
                case "shrink":
                    if (!playerMovement.GetIsShrinked())
                    {
                        playerMovement.SetIsShrinked(true);
                    }
                    break;
            }
            inventory.RemovePotion(type);
        }
    }
}