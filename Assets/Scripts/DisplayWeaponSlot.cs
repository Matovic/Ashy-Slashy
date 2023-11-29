using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeaponSlot : DisplayItem
{
   // Update is called once per frame
    private void Update()
    {
        switch (IsFull)
        {
            case false when Inventory.GetItemBool("shotgun"):
                IsFull = true;
                DrawItem("shotgun");
                break;
            case false when Inventory.GetItemBool("trap"):
                IsFull = true;
                DrawItem("trap");
                break;
            case false when Inventory.GetItemBool("machete"):
                IsFull = true;
                DrawItem("machete");
                break;
            case true when !Inventory.GetItemBool("weapon"):
                IsFull = false;
                DestroyItem();
                break;
        }
    }
}
