using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
