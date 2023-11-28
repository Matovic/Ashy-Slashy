using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // destroy locked box
        Destroy(this);
        // make a open box
        Instantiate(openBox, position, rotation);
        // make a shotgun
        position.z = -1;
        foreach (var treasure in treasures)
            Instantiate(treasure, position, rotation);
    }
}
