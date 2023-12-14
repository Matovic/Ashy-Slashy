using Player;
using UnityEngine;

namespace Items
{
    public class ShrinkingPotionScript : MonoBehaviour, IInteractable
    {
        public void Interact(GameObject player)
        {
            Inventory inventory = player.GetComponent<Inventory>();
            // add to inventory
            inventory.AddPotion("shrink");
            Destroy(gameObject);
        }
    }
}
