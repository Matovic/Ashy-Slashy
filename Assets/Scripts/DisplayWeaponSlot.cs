using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeaponSlot : DisplayItem
{
   // Update is called once per frame
    private void Update()
    {
        if (!isFull && _inventory.GetItemBool("shotgun"))
        {
            isFull = true;
            DrawItem();
        }
        else if (isFull && !_inventory.GetItemBool("shotgun"))
        {
            isFull = false;
            DestroyItem();
        }
    }
}
