using UnityEngine;

public class KeyScript : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        var inventory = player.GetComponent<Inventory>();
        // add to player inventory
        inventory.SetItemBool("key", true);
        // destroy game object
        Destroy(gameObject);
    }
}
