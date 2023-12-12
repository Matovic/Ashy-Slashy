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
        [SerializeField] private PauseScreen pauseScreenUI;
        
        private Inventory inventory;
        private GameObject _player;
        private PlayerMovement playerMovement;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            inventory = _player.GetComponent<Inventory>();
            playerMovement = _player.GetComponent<PlayerMovement>();
        }
        private void UsePotion(List<Potion> potions, string type)
        {
            Debug.Log($"potions.{type}:{potions.Count}");
            var p = potions.Find(x => x.PotionType == type);
            if (p != null)
                Use(type);
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