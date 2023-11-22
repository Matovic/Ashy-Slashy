using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour, IInteractable, IUsable, IDroppable
{
    protected SpriteRenderer _spriteRenderer, _playerSpriteRenderer;
    protected Inventory _inventory;
    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inventory.GetItemBool("shotgun"))
            return;
        _spriteRenderer.flipX = _playerSpriteRenderer.flipX;
        var throwAway = Input.GetAxis("Throw away");
        var use = Input.GetButtonDown("Use");//Input.GetAxis("Use");
        if (throwAway != 0.0f) Drop();
        if (use) Use();
    }
    
    private void Use()
    {
        if (_inventory.GetBullets() == 0) return;
        var transform1 = transform;
        var bullet = Instantiate(bulletPrefab, transform1.position, transform1.rotation, transform1);
        bullet.transform.SetParent(null);
        _inventory.DecrementBullets();
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
        if (_inventory.GetItemBool("weapon")) return;
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
        
    }
}
