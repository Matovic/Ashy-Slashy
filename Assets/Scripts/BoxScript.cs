using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        GameObject.Instantiate(itemPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public void setItemPrefab(GameObject prefab)
    {
        itemPrefab = prefab;
    }
}
