using System.Collections;
using System.Collections.Generic;
using Items;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct BoxItem
{
    public GameObject itemPrefab;
    public int count;
}

public class BoxRoomScript : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private List<BoxItem> boxItems;

    // Start is called before the first frame update
    private void Start()
    {
        BoxScript[] boxScripts = gameObject.transform.GetComponentsInChildren<BoxScript>();

        // initialize specific box items
        foreach (BoxItem item in boxItems) 
        {
            for (int i = 1; i <= item.count; i++)
            {
                int boxNumber = Random.Range(0, boxScripts.Length);
                while (boxScripts[boxNumber].GetItemPrefab() != null)
                {
                    boxNumber = Random.Range(0, boxScripts.Length);
                }
                boxScripts[boxNumber].SetItemPrefab(item.itemPrefab);
            }
        }

        // fill remaining boxes with ammo
        for (int i = 0; i < boxScripts.Length; i++)
        {
            if (boxScripts[i].GetItemPrefab() != null)
            {
                continue;
            }
            boxScripts[i].SetItemPrefab(ammoPrefab);
        }
    }

}
