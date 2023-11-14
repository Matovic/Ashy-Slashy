using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{name} because a collision with {collision.gameObject.name}");
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < _inventory.slots.Count; ++i)
            {
                if (!_inventory.isFull[i])
                {
                    Debug.Log(_inventory.slots[i].transform);
                    // item can be added
                    _inventory.isFull[i] = true;
                    Instantiate(icon, _inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
