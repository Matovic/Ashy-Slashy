using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBoxScript : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject treasure;
    [SerializeField] private GameObject openBox;

    private void Start()
    {
        //treasure.transform.localScale = new Vector3(1, 1, 1);
        //openBox.transform.localScale = new Vector3(1, 1, 1);
    }

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
        Instantiate(treasure, position, rotation);
    }
}
