using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayKeyScript : DisplayItem
{
    // Update is called once per frame
    private void Update()
    {
        if (!IsFull && Inventory.GetItemBool("key"))
        {
            IsFull = true;
            DrawItem();
        }
        else if (IsFull && !Inventory.GetItemBool("key"))
        {
            IsFull = false;
            DestroyItem();
        }
    }
}
