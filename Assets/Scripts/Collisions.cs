using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Collisions : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    private Inventory _inventory;
    [FormerlySerializedAs("_gameOverScreenUI")] [SerializeField] private GameObject gameOverScreenUI;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //_gameOverScreenUI = GameObject.FindGameObjectWithTag("GameOverUI");
        //_gameOverScreenUI.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            gameOverScreenUI.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
            //Debug.Log($"{name}");
            _inventory.IncrementBullets();
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
            interactable.Interact(player);
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
        /*else if (collision.gameObject.name == "Shotgun")
        {
            playerActionController.isPickable = false;
        }*/
    }
}
