using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerActionController playerActionController;
    //void private OnTriggerEnter2D(Collider2D collision)
    //{
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"{name} because a collision with {collision.gameObject.name}");
        if (collision.CompareTag("Ladders"))
        {
            playerMovement.onLadder = true;
        }
        
        else if (collision.gameObject.name == "Shotgun")
        {
            playerActionController.isPickable = true;
        }
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
