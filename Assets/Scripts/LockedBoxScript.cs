using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBoxScript : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject treasure;
    [SerializeField] GameObject openBox;
    public void interact(GameObject player)
    {
        var inv = player.GetComponent<Inventory>();
        // TODO: get inventory, check for key, if key present - destroy lockedbox, instantiate openBox and shotgun
    }
}
