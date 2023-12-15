using System.Collections.Generic;
using UnityEngine;

public class Potion
{
    public readonly string PotionType;
    public int Count;

    public Potion(string type, int c)
    {
        PotionType = type;
        Count = c;
    }
}

namespace Player
{
    public class Inventory : MonoBehaviour
    {

        public List<bool> isFull;
        private readonly List<Potion> potions = new List<Potion>();
        [SerializeField] private int countBullets = 0;
        private bool _hasKey = false, _hasShotgun = false, _hasTrap = false, _hasMachete = false, 
            _hasWeapon = false, _hasHeadlamp = false, _hasFuel = false;
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
                case "headlamp":
                    _hasHeadlamp = status;
                    break;
                case "fuel":
                    _hasFuel = status;
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
                "headlamp" => _hasHeadlamp,
                "fuel" => _hasFuel,
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
            var p = potions.Find(x => x.PotionType == type);
            if (p != null) p.Count++;
            else potions.Add(new Potion(type, 1));
        }
        public void RemovePotion(string type)
        {
            var p = potions.Find(x => x.PotionType == type);
            --p.Count;
            if (p.Count == 0) potions.Remove(p);
        }
        public List<Potion> GetPotions() 
        { 
            return potions; 
        }
    }
}
