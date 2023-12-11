using UnityEngine;

namespace Weapons
{
    public class ShotgunScript : WeaponScript
    {
        [SerializeField] private GameObject bulletPrefab;

        private new void Start()
        {
            base.Start();
            type = "shotgun";
        }
    
        protected override void Use()
        {
            if (Inventory.GetBullets() == 0) return;
            var transform1 = transform;
            var bullet = Instantiate(bulletPrefab, transform1.position, transform1.rotation, transform1);
            bullet.transform.SetParent(null);
            Inventory.DecrementBullets();
            base.Use();
        }
    }
}