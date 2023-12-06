using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class DisplayItem : MonoBehaviour
    {
        [FormerlySerializedAs("item")] [SerializeField] private GameObject shotgun;
        [SerializeField] private GameObject trap, machete;
        private GameObject _gameObj;
        protected Inventory Inventory;
        protected bool IsFull = false;

        protected void DrawItem(string type)
        {
            var transform1 = transform;
            var item1 = type switch
            {
                "trap" => trap,
                "machete" => machete,
                _ => shotgun
            };
            _gameObj = Instantiate(item1, transform1.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), transform1);
        }
    
        protected void DrawItem()
        {
            var transform1 = transform;
            _gameObj = Instantiate(shotgun, transform1.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), transform1);
        }

        protected void DestroyItem()
        {
            Destroy(_gameObj);
        }
    
        // Start is called before the first frame update
        private void Start()
        {
            Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }
    }
}
