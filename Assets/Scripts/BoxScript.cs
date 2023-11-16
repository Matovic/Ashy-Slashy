using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject itemPrefab;

    public void Break()
    {
        GameObject.Instantiate(itemPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public void setItemPrefab(GameObject prefab)
    {
        itemPrefab = prefab;
    }

    void IInteractable.interact(GameObject player)
    {
        this.Break();
    }
}
