using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Items
{
    public class LockedBoxScript : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> treasures;
        [SerializeField] private GameObject openBox;

        public void Interact(GameObject player)
        {
            // get inventory
            var inventory = player.GetComponent<Inventory>();
            // check for key
            if (!inventory.GetItemBool("key")) return;
            // set key to false, because it was used
            inventory.SetItemBool("key", false);
            // get transforms of a locked box
            var transform1 = transform;
            var position = transform1.position;
            var rotation = transform1.rotation;
            // make a open box
            Instantiate(openBox, position, rotation);
            // spawn treasures
            position.z -= 1;
            foreach (var treasure in treasures)
                Instantiate(treasure, position, rotation);
            // destroy locked box
            Destroy(gameObject);
        }
    }
}
