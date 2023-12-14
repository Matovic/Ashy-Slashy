using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour, IInteractable
    {
        protected SpriteRenderer SpriteRenderer;
        private SpriteRenderer _playerSpriteRenderer;
        private BoxCollider2D _boxCollider;
        protected Inventory Inventory;
        protected string type;

        protected void SetPosition(Vector3 localPosition, Vector3 eulerAngles)
        {
            var transformItem = transform;
            transformItem.localPosition = localPosition;
            Quaternion localRotation = default;
            localRotation.eulerAngles = eulerAngles; 
            transformItem.localRotation = localRotation;
        }
        
        protected void Start()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!Inventory.GetItemBool(type))
                return;
            if(type != "machete")
                SpriteRenderer.flipX = _playerSpriteRenderer.flipX;
            else if (SpriteRenderer.flipY != !_playerSpriteRenderer.flipX)
            {
                SpriteRenderer.flipY = !_playerSpriteRenderer.flipX;
                if (SpriteRenderer.flipY)
                {
                    SetPosition(new Vector3(0.6f, 1.2f, -0.5f), new Vector3(0.0f, 0.0f, 245.0f));
                }
                else
                {
                    SetPosition(new Vector3(-0.6f, 1.2f, -0.5f), new Vector3(0.0f, 0.0f, 285.0f));
                }
            }
            var throwAway = Input.GetAxis("Throw away");
            var use = Input.GetButtonDown("Use");
            if (throwAway != 0.0f) Drop();
            if (use) Use();
        }

        protected virtual void Use()
        {
            switch (type)
            {
                case "trap":
                    Drop();
                    break;
            }
            _boxCollider.enabled = true;
        }

        protected virtual void Drop()
        {
            // detach from player
            transform.parent = null;
            // remove from inventory
            Inventory.SetItemBool(type, false);
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
            transformItem.localPosition = new Vector3(0.0f, 0.5f, -0.5f);
            // add to inventory
            Inventory.SetItemBool(type, true);
            // change tag
            gameObject.tag = "Usable";
        
            _boxCollider.enabled = false;
        }
    }
}
