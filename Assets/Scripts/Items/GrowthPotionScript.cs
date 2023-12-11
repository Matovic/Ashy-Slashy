using Player;
using UnityEngine;

namespace Items
{
    public class GrowthPotionScript : MonoBehaviour, IInteractable
    {
        // Start is called before the first frame update
        public void Interact(GameObject player)
        {
            Inventory inventory = player.GetComponent<Inventory>();
            // add to inventory
            inventory.AddPotion("growth");
            // change tag
            //gameObject.tag = "Usable";
            Destroy(gameObject);
        }
    }
}
