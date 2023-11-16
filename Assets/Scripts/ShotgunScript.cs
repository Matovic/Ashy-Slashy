using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour, IInteractable, IUsable, IDroppable
{
    public void drop(GameObject player)
    {
        // TODO: remove from inventory, detach from player, keep on place, change tag to Interactable
    }

    public void interact(GameObject player)
    {
        // TODO: check inventory for space - if applicable, add to inventory, attach to player, change tag to Usable
    }

    public void use(GameObject player)
    {
        // TODO: shoot if theres ammo in inventory
    }
}