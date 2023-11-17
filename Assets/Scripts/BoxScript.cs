using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject itemPrefab;

    public void Break()
    {
        var o = gameObject;
        Instantiate(itemPrefab, o.transform.position, o.transform.rotation);
        Destroy(gameObject);
    }

    public void SetItemPrefab(GameObject prefab)
    {
        itemPrefab = prefab;
    }

    void IInteractable.Interact(GameObject player)
    {
        Break();
    }
}
