using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public static class Dialogues
    {
        public static readonly string
            ShrinkText = "Shrinking potion?",
            GrowthText = "Potion for growth? Nah, I'm good.",
            KeyText = "Key to open that box!",
            ShotgunText = "This is my boomstick!",
            TrapText = "Groovy!",
            AmmoText = "That's good for my boomstick!", 
            MacheteText = "This should have been a chainsaw, but we are out of budget.", 
            LampText = "Finally, some light.",
            FuelText = "This should be in my car.",
            PotionWeaponText = "I can not use a potion with a weapon.",
            PotionNotAll = "I need to collect all the potions! Otherwise, I will be stuck.";

        private static readonly string
            DarknessText1 = "I should not be here without a light.",
            DarknessText2 = "I think I am...dying.",
            DarknessText3 = "Get away, demon!";

        public static string GetRandomDarknessText()
        {
            string[] darknessTexts = {DarknessText1, DarknessText2, DarknessText3};
            var randomIndex = Random.Range(0, darknessTexts.Length);
            return darknessTexts[randomIndex];
        }
    }
    [System.Serializable]
    internal class InventoryItem
    {
        public string itemType;
        public string dialogue;
        public bool hasBeenPickedUp;
    }
    public class PopUpText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPopUp;
        [FormerlySerializedAs("Delay")] [SerializeField] private uint delay = 3;
        private GameObject _player;
        private Inventory inventory;
        private Collisions playerCollisions;
        private PlayerController playerController;
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private bool growthPickUp, shrinkPickUp, ammoPickUp, darknessTextDisplayed, hasWeapon, notCollectedAll;
        private void Start()
        {
            textPopUp.enabled = false;
            _player = GameObject.FindWithTag("Player");
            inventory = _player.GetComponent<Inventory>();
            playerCollisions = _player.GetComponent<Collisions>();
            playerController = _player.GetComponent<PlayerController>();
            // init inventory items
            inventoryItems.Add(new InventoryItem{itemType="key", dialogue=Dialogues.KeyText});
            inventoryItems.Add(new InventoryItem{itemType="shotgun", dialogue=Dialogues.ShotgunText});
            inventoryItems.Add(new InventoryItem{itemType="trap", dialogue=Dialogues.TrapText});
            inventoryItems.Add(new InventoryItem{itemType="machete", dialogue=Dialogues.MacheteText});
            inventoryItems.Add(new InventoryItem{itemType="headlamp", dialogue=Dialogues.LampText});
            inventoryItems.Add(new InventoryItem{itemType="fuel", dialogue=Dialogues.FuelText});
        }
        void Update()
        {
            var potions = inventory.GetPotions();
            var pGrowth = potions.Find(x => x.PotionType == "growth");
            var pShrink = potions.Find(x => x.PotionType == "shrink");
            if (pShrink != null && !shrinkPickUp)
            {
                shrinkPickUp = true;
                StartCoroutine(ShowMessage(Dialogues.ShrinkText, delay));
            }
            else if (pGrowth != null && !growthPickUp)
            {
                growthPickUp = true;
                StartCoroutine(ShowMessage(Dialogues.GrowthText, delay));
            }
            else if (inventory.GetBullets() != 0 && !ammoPickUp)
            {
                ammoPickUp = true;
                StartCoroutine(ShowMessage(Dialogues.AmmoText, delay));
            }
            else if (playerCollisions.GetDarknessTime() > 0.8f && !darknessTextDisplayed)
            {
                darknessTextDisplayed = true;
                StartCoroutine(ShowMessage(Dialogues.GetRandomDarknessText(), delay));
                StartCoroutine(TextPause(delay));
            }
            else if (playerController.HasWeapon && !hasWeapon)
            {
                hasWeapon = true;
                StartCoroutine(ShowMessage(Dialogues.PotionWeaponText, delay));
                StartCoroutine(TextPause(delay));
            }
            else if (playerController.NotCollectedAll && !notCollectedAll)
            {
                notCollectedAll = true;
                StartCoroutine(ShowMessage(Dialogues.PotionNotAll, delay));
                StartCoroutine(TextPause(delay));
            }
            else foreach (var item in inventoryItems.Where(item => inventory.GetItemBool(item.itemType) && !item.hasBeenPickedUp))
            {
                item.hasBeenPickedUp = true;
                StartCoroutine(ShowMessage(item.dialogue, delay));
                return;
            }
        }
        IEnumerator ShowMessage(string message, float delayTime)
        {
            textPopUp.enabled = true;
            textPopUp.text = message;
            yield return new WaitForSeconds(delayTime);
            textPopUp.enabled = false;
        }
        IEnumerator TextPause(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            darknessTextDisplayed = false;
            hasWeapon = false;
            notCollectedAll = false;
        }
    }
}
