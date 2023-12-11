using UnityEngine;

namespace Items
{
    public class BoxScript : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject itemPrefab = null;

        private void Break()
        {
            var o = gameObject;
            Instantiate(itemPrefab, o.transform.position, o.transform.rotation);
            Destroy(o);
        }

        public void SetItemPrefab(GameObject prefab)
        {
            itemPrefab = prefab;
        }

        public GameObject GetItemPrefab()
        {
            return itemPrefab;
        }

        void IInteractable.Interact(GameObject player)
        {
            Break();
        }
    }
}
