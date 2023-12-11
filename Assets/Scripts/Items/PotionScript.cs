using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour, IInteractable, IUsable
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] private PlayerMovement playerMovement;
    protected string type;

    public void Interact(GameObject player)
    {
        // add to inventory
        inventory.SetItemBool(type, true);
        // change tag
        gameObject.tag = "Usable";
    }

    public void Use(GameObject player)
    {
        switch (type)
        {
            case "growth":
                if (playerMovement.GetIsShrinked())
                {
                    playerMovement.SetIsShrinked(false);
                }
                break;
            case "shrink":
                if (!playerMovement.GetIsShrinked())
                {
                    playerMovement.SetIsShrinked(true);
                }
                break;
        }
    }
}
