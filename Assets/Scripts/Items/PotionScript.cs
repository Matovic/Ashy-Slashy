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
        private BoxCollider2D _boxCollider;
        [SerializeField] private string type;
        private int Count = 0;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
            inventory = _player.GetComponent<Inventory>();
            playerMovement = _player.GetComponent<PlayerMovement>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        public string GetPotionType()
        {
            return type;
        }

        public void Interact(GameObject player)
        {
            inventory.AddPotion(type);
            // change tag
            var o = gameObject;
            //o.tag = "Usable";
            //transform.position = new Vector3(0.0f, 0.0f, 100.0f);
            Destroy(o);
            //_boxCollider.enabled = false;
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
