using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour, IInteractable
{
    protected SpriteRenderer SpriteRenderer;
    private SpriteRenderer _playerSpriteRenderer;
    private BoxCollider2D _boxCollider;
    protected Inventory Inventory;
    protected string Type;
    //[SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    protected void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Inventory.GetItemBool(Type))
            return;
        if(Type != "machete")
            SpriteRenderer.flipX = _playerSpriteRenderer.flipX;
        else
        {
            SpriteRenderer.flipY = !_playerSpriteRenderer.flipX;
            if (SpriteRenderer.flipY)
            {
                var transformItem = transform;
                transformItem.localPosition = new Vector3(0.5f, 1.2f, -1.0f);
                Quaternion localRotation = default;
                localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 245.0f);
                transformItem.localRotation = localRotation;
                //transformRotation.z = 245.0f;
            }
            else
            {
                var transformItem = transform;
                transformItem.localPosition = new Vector3(-0.5f, 1.2f, -1.0f);
                Quaternion localRotation = default;
                localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 285.0f);
                transformItem.localRotation = localRotation;
            }
        }
        var throwAway = Input.GetAxis("Throw away");
        var use = Input.GetButtonDown("Use");
        if (throwAway != 0.0f) Drop();
        if (use) Use();
    }

    protected virtual void Use()
    {
        switch (Type)
        {
            case "trap":
                Drop();
                break;
        }
        _boxCollider.enabled = true;
    }

    protected virtual void Drop()
    {
        // detach to player
        transform.parent = null;
        // remove from inventory
        Inventory.SetItemBool(Type, false);
        // change tag
        transform.gameObject.tag = "Interactable"; 
        
        _boxCollider.enabled = true;
    }

    public virtual void Interact(GameObject player)
    {
        //check inventory
        if (Inventory.GetItemBool("weapon")) return;
        // attach to player
        Transform transformItem;
        (transformItem = transform).SetParent(player.transform);
        transformItem.localPosition = new Vector3(0.0f, 0.5f, -1.0f);
        // add to inventory
        Inventory.SetItemBool(Type, true);
        // change tag
        transform.gameObject.tag = "Usable";
        
        _boxCollider.enabled = false;
    }
}
