using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxRoomScript : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private GameObject keyPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        BoxScript[] boxScripts = gameObject.transform.GetComponentsInChildren<BoxScript>();
        int keyIndex = Random.Range(0, boxScripts.Length);
        for (int i = 0; i < boxScripts.Length; i++)
        {
            if (i == keyIndex)
            {
                // TODO: add key
                boxScripts[i].SetItemPrefab(keyPrefab);
                continue;
            }
            boxScripts[i].SetItemPrefab(ammoPrefab);
        }
    }

}
