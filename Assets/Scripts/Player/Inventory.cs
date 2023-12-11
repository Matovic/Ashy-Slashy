using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Potion
{
    public string potionType;
    public int count;

    public Potion(string type, int c)
    {
        this.potionType = type;
        this.count = c;
    }
}

namespace Player
{
    public class Inventory : MonoBehaviour
    {

        public List<bool> isFull;
        private List<Potion> potions = new List<Potion>();
        [SerializeField] private int countBullets = 0;
        private bool _hasKey = false, _hasShotgun = false, _hasTrap = false, _hasMachete = false, _hasWeapon = false;

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
                case "machete":
                    _hasMachete = status;
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
                "machete" => _hasMachete,
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

        public void AddPotion(string type)
        {
            var p = potions.Find(x => x.potionType == type);
            if (p != null) p.count++;
            else potions.Add(new Potion(type, 1));
        }

        public List<Potion> GetPotions() 
        { 
            return potions; 
        }
    }
}
