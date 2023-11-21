using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour, IInteractable
{
    private bool _isUsable = false;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            _isUsable = false;
        }
    }
    
    public void Interact(GameObject player)
    {
        //check inventory
        if (_inventory.GetItemBool("trap")) return;
        //var playerMovement = player.GetComponent<PlayerMovement>();
        // attach to player
        Transform transformItem;
        (transformItem = transform).SetParent(player.transform);
        transformItem.localPosition = new Vector3(0.0f, 0.5f, -1.0f);
        // add to inventory
        _inventory.SetItemBool("trap", true);
        // change tag
        transform.gameObject.tag = "Usable"; 
    }
}
