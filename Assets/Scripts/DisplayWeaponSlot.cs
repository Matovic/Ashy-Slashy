using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeaponSlot : DisplayItem
{
   // Update is called once per frame
    private void Update()
    {
        if (!IsFull && Inventory.GetItemBool("shotgun"))
        {
            IsFull = true;
            DrawItem();
        }
        else if (IsFull && !Inventory.GetItemBool("shotgun"))
        {
            IsFull = false;
            DestroyItem();
        }
    }
}
