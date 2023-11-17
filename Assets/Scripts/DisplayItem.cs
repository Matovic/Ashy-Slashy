using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItem : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private GameObject _gameObj;
    protected Inventory _inventory;
    protected bool isFull = false;

    public void DrawItem()
    {
        var transform1 = transform;
        _gameObj = Instantiate(item, transform1.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), transform1);
    }
    
    public void DestroyItem()
    {
        Debug.Log($"{_gameObj.name} destroyed!");
        Destroy(_gameObj);
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
}
