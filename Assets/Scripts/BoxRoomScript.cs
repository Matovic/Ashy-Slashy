using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxRoomScript : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] GameObject keyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        BoxScript[] boxScripts = gameObject.transform.GetComponentsInChildren<BoxScript>();
        int keyIndex = Random.Range(0, boxScripts.Length);
        for (int i = 0; i < boxScripts.Length; i++)
        {
            if (i == keyIndex)
            {
                // TODO: add key
                boxScripts[i].itemPrefab = keyPrefab;
                continue;
            }
            boxScripts[i].itemPrefab = ammoPrefab;
        }
        Debug.Log(boxScripts.Length);
    }

}
