using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPotionScript : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        // add to inventory
        inventory.AddPotion("shrink");
        // change tag
        //gameObject.tag = "Usable";
        Destroy(gameObject);
    }
}
