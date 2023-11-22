using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<bool> isFull;
    public List<GameObject> slots = new List<GameObject>();
    [SerializeField] private int countBullets = 0;
    private bool _hasKey = false, _hasShotgun = false, _hasTrap = false, _hasWeapon = false;

    public void SetItemBool(string item, bool status)
    {
        switch (item)
        {
            case "key":
                _hasKey = status;
                break;
            case "shotgun":
                _hasShotgun = status;
                _hasWeapon = status;
                break;
            case "trap":
                _hasTrap = status;
                _hasWeapon = status;
                break;
        }
    }
    
    public bool GetItemBool(string item)
    {
        return item switch
        {
            "key" => _hasKey,
            "trap" => _hasTrap,
            "shotgun" => _hasShotgun,
            _ => _hasWeapon
        };
    }
    
    public void IncrementBullets()
    {
        ++countBullets;
    }
    public void DecrementBullets()
    {
        --countBullets;
    }
    public int GetBullets()
    {
        return countBullets;
    }
}
