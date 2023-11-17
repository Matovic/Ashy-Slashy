using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour, IInteractable, IUsable, IDroppable
{
    private SpriteRenderer _playerSpriteRenderer, _spriteRenderer;
    private Inventory _inventory;
    private GameObject _player;
    private void Start()
    {
        _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_inventory.GetItemBool("shotgun"))
            return;
        _spriteRenderer.flipX = _playerSpriteRenderer.flipX;
        var throwAway = Input.GetAxis("Throw away");
        if (throwAway != 0.0f) Drop();

    }
    
    private void Drop()
    {
        // detach to player
        transform.parent = null;
        // remove from inventory
        _inventory.SetItemBool("shotgun", false);
        // change tag
        transform.gameObject.tag = "Interactable"; 
    }

    public void Drop(GameObject player)
    {
        // TODO: remove from inventory, detach from player, keep on place, change tag to Interactable
    }

    public void Interact(GameObject player)
    {
        //check inventory
        if (_inventory.GetItemBool("shotgun")) return;
        //var playerMovement = player.GetComponent<PlayerMovement>();
        // attach to player
        Transform transformShotgun;
        (transformShotgun = transform).SetParent(player.transform);
        transformShotgun.localPosition = new Vector3(0.0f, 0.5f, -1.0f);
        // add to inventory
        _inventory.SetItemBool("shotgun", true);
        // change tag
        transform.gameObject.tag = "Usable"; 
    }

    public void Use(GameObject player)
    {
        // TODO: shoot if theres ammo in inventory
    }
}