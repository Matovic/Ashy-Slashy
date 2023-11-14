using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private GameObject icon, bulletsText;
    //This is supposedly how I get the text
    //private Text _textUI;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //_textUI = bulletsText.GetComponent<Text>();
    }

    public void DrawShotgun()
    {
        for (int i = 0; i < _inventory.slots.Count; ++i)
        {
            // shotgun
            if (_inventory.slots[i].name == "SlotWeapon" && !_inventory.isFull[i])
            {
                // item can be added
                _inventory.isFull[i] = true;
                Instantiate(icon, _inventory.slots[i].transform, false);
                //Destroy(gameObject);
                break;
            }
        }
    }

    public void DrawAmmos(GameObject gameObj)
    {
        //Debug.Log($"{name} because a collision with {collision.gameObject.name}");
        if (_inventory.GetBullets() == 0)
        {
            for (int i = 0; i < _inventory.slots.Count; ++i)
            {
                if (_inventory.slots[i].name == "SlotAmmo")
                {
                    // item can be added
                    //_inventory.isFull[i] = true;
                    Instantiate(icon, _inventory.slots[i].transform, false);
                    break;
                }
            }
        }
        Destroy(gameObj);
        _inventory.IncrementBullets();
        //_textUI.text = _inventory.GetBullets().ToString();
    }
}
