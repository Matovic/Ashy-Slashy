using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour, IInteractable
{
    public void interact(GameObject player)
    {
        // TODO: add to player inventory
        Destroy(gameObject);
    }
}
