using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayKeyScript : DisplayItem
{
    // Update is called once per frame
    private void Update()
    {
        if (!isFull && _inventory.GetItemBool("key"))
        {
            isFull = true;
            DrawItem();
        }
        else if (isFull && !_inventory.GetItemBool("key"))
        {
            isFull = false;
            DestroyItem();
        }
    }
}
