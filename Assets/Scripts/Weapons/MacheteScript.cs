using UnityEngine;

namespace Weapons
{
    public class MacheteScript : WeaponScript
    {
        private bool _isAttacking = false;
        private const float AttackInterval = 1.0f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy") || !_isAttacking) return;
            Destroy(collision.gameObject);
        }
    
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy") || !_isAttacking) return;
            Destroy(collision.gameObject);
        }
    
        // Start is called before the first frame update
        private new void Start()
        {
            base.Start();
            type = "machete";
        }

        private void AttackWait()
        {
            if (gameObject.CompareTag("Usable"))
            {
                var originalLocalPosition = transform.localPosition;
                var localPosition = new Vector3(originalLocalPosition.x, 1.2f, originalLocalPosition.z);
                var eulerAngles = new Vector3(0.0f, 0.0f, SpriteRenderer.flipY ? 245.0f : 285.0f);
                SetPosition(localPosition, eulerAngles);
            }
            _isAttacking = false;
        }

        protected override void Use()
        {
            if (_isAttacking) return;
            base.Use();
            var originalLocalPosition = transform.localPosition;
            var localPosition = new Vector3(originalLocalPosition.x, 0.5f, originalLocalPosition.z);
            var eulerAngles = new Vector3(0.0f, 0.0f, SpriteRenderer.flipY ? 185.0f : 355.0f);
            _isAttacking = true;
            SetPosition(localPosition, eulerAngles);
            Invoke(nameof(AttackWait), AttackInterval);
        }
    
        public override void Interact(GameObject player)
        {
            if (Inventory.GetItemBool("weapon")) return;
            base.Interact(player);
            SetPosition(new Vector3(-0.6f, 1.2f, -0.5f), new Vector3(0.0f, 0.0f, 285.0f));
        }
    }
}
