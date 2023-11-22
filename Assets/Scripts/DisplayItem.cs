using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItem : MonoBehaviour
{
    [SerializeField] private GameObject item, trap;
    private GameObject _gameObj;
    protected Inventory Inventory;
    protected bool IsFull = false;

    protected void DrawItem(string type)
    {
        var transform1 = transform;
        var item1 = item;
        if (type == "trap") item1 = trap;
        _gameObj = Instantiate(item1, transform1.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), transform1);
    }
    
    protected void DrawItem()
    {
        var transform1 = transform;
        _gameObj = Instantiate(item, transform1.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), transform1);
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
