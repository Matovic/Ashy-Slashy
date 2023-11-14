using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;

    public Item(int id, string name, Sprite icon)
    {
        this.id = id;
        this.name = name;
        this.icon = icon;
    }
    
    public Item(int id, string name, string iconPath)
    {
        this.id = id;
        this.name = name;
        this.icon = Resources.Load<Sprite>(iconPath);
    }
    
    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.icon = item.icon;
    }
}
