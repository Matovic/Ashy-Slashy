using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerActionController playerActionController;
    private PickUp _pickUp;

    private void Start()
    {
        _pickUp = GameObject.FindGameObjectWithTag("Ammo").GetComponent<PickUp>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            //GameObject o;
            _pickUp = collision.gameObject.GetComponent<PickUp>();
            _pickUp.DrawAmmos(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var action = Input.GetAxis("Submit");
        //Debug.Log($"{name} because a collision with {collision.gameObject.name}");
        if (collision.CompareTag("Ladders"))
        {
            playerMovement.onLadder = true;
        }
        else if (collision.CompareTag("Interactable") && action != 0.0f)
        {
            //Debug.Log($"{name} because a collision with {collision.gameObject.name}");
            var interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.interact(player);
            //playerActionController.isBreakable = true;
            //PlayerActionController.SetGameObject("Box", collision.gameObject);
        }
        /*else if (collision.CompareTag("Ammo"))
        {
            playerActionController.isPickable = true;
            //Debug.Log($"AMMO: {name} because a collision with {collision.gameObject.name}");
            //playerActionController.isBreakable = true;
            //PlayerActionController.SetGameObject("Box", collision.gameObject);
        }*/
        /*else if (collision.gameObject.name == "Shotgun")
        {
            playerActionController.isPickable = true;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            playerMovement.onLadder = false;
        }
        else if (collision.gameObject.name == "Shotgun")
        {
            playerActionController.isPickable = false;
        }
    }
}
