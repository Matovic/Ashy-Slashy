using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TrapScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite opened, closed;
    private Inventory _inventory;
    private SpriteRenderer _spriteRenderer;
    private bool _isUsable = true;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        if (!_inventory.GetItemBool("trap"))
            return;
        var throwAway = Input.GetAxis("Throw away");
        var use = Input.GetButtonDown("Use");
        if (throwAway != 0.0f) Drop();
        if (use) Use();
    }

    private void ChangeState(Sprite state)
    {
        _spriteRenderer.sprite = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || !_isUsable) return;
        Destroy(collision.gameObject);
        ChangeState(closed);
        _isUsable = false;
    }
    
    public void Interact(GameObject player)
    {
        //check inventory
        if (_inventory.GetItemBool("weapon")) return;
        //var playerMovement = player.GetComponent<PlayerMovement>();
        // attach to player
        Transform transformItem;
        (transformItem = transform).SetParent(player.transform);
        transformItem.localPosition = new Vector3(0.0f, 0.5f, -1.0f);
        // add to inventory
        _inventory.SetItemBool("trap", true);
        // change tag
        transform.gameObject.tag = "Usable"; 
        // open trap
        ChangeState(opened);
    }

    private void Use()
    {
        Drop();
    }

    private void Drop()
    {
        // detach to player
        transform.parent = null;
        // remove from inventory
        _inventory.SetItemBool("trap", false);
        // change tag
        transform.gameObject.tag = "Interactable";
        _isUsable = true;
    }
}
