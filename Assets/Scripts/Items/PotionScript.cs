using System;
using Player;
using UnityEngine;

namespace Items
{
    public class PotionScript : MonoBehaviour, IInteractable, IUsable
    {
        private GameObject _player;
        private Inventory inventory;
        private PlayerMovement playerMovement;
        [SerializeField] private string type;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            inventory = _player.GetComponent<Inventory>();
            playerMovement = _player.GetComponent<PlayerMovement>();
        }

        public string GetPotionType()
        {
            return type;
        }

        public void Interact(GameObject player)
        {
            inventory.AddPotion(type);
            var o = gameObject;
            Destroy(o);
        }

        public void Use(GameObject player)
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
        }
    }
}
