using System;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Inventory inventory;
        private GameObject _player;
        private PlayerMovement playerMovement;
        private bool allPotions = false;
        private const uint MaxPotions = 2;
        public bool HasWeapon { get; private set; } 

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            inventory = _player.GetComponent<Inventory>();
            playerMovement = _player.GetComponent<PlayerMovement>();
        }
        private void Update()
        {
            var potions = inventory.GetPotions();
            if (potions.Count == 0) return;
            var pGrowth = potions.Find(x => x.PotionType == "growth");
            var pShrink = potions.Find(x => x.PotionType == "shrink");
            
            switch (allPotions)
            {
                case false when pShrink != null && pGrowth != null && 
                                pGrowth.Count == MaxPotions && pShrink.Count == MaxPotions:
                    allPotions = true;
                    break;
                case false:
                    return;
            }
            HasWeapon = false;
            var usePotion = Input.GetButtonDown("Fire1");
            if (!usePotion) return;
            if (inventory.GetItemBool("weapon"))
            {
                HasWeapon = true;
                return;
            }
            Use(pShrink != null && pGrowth.Count == pShrink.Count ? "shrink" : "growth");
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