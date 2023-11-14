using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<bool> isFull;
    public List<GameObject> slots = new List<GameObject>();
    [SerializeField] private int countBullets = 0;

    public void IncrementBullets()
    {
        ++countBullets;
    }
    public int GetBullets()
    {
        return countBullets;
    }
}
