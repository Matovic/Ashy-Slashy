using UnityEngine;

namespace Weapons
{
    public class TrapScript : WeaponScript
    {
        [SerializeField] private Sprite opened, closed;
        private bool _isUsable = true;

        private new void Start()
        {
            base.Start();
            type = "trap";
        }

        private void ChangeState(Sprite state)
        {
            SpriteRenderer.sprite = state;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy") || !_isUsable) return;
            Destroy(collision.gameObject);
            ChangeState(closed);
            _isUsable = false;
        }
    
        public override void Interact(GameObject player)
        {
            if (Inventory.GetItemBool("weapon")) return;
            _isUsable = false;
            ChangeState(opened);
            base.Interact(player);
        }
    
        protected override void Use()
        {
            _isUsable = true;
            base.Use();
        }
    
        protected override void Drop()
        {
            _isUsable = true;
            base.Drop();
        }
    }
}
