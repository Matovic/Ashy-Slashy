using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Collisions : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] LayerMask lightLayerMask;
    [SerializeField] private float darknessTimeLimit;
    [SerializeField] AudioSource gameOverAudio;
    private float darknessTime;
    private bool interactedRecently = false;
    [SerializeField ]private Inventory _inventory;
    [FormerlySerializedAs("_gameOverScreenUI")] [SerializeField] private GameObject gameOverScreenUI;
    [SerializeField] private CameraScript cameraScript;

    private void Update()
    {
        // check for light collider
        if (Physics2D.GetRayIntersection(new Ray(player.transform.position, Vector3.forward), Mathf.Infinity, lightLayerMask)) 
        {
            darknessTime = 0;
        }
        else
        {
            darknessTime += Time.deltaTime;
        }
        if (darknessTime >= darknessTimeLimit)
        {
            gameOverAudio.Play();
            Destroy(gameObject);
            gameOverScreenUI.SetActive(true);
        }
        // reset interaction 
        if (Input.GetAxis("Submit") == 0) interactedRecently = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOverAudio.Play();
            gameObject.SetActive(false);
            Destroy(gameObject);
            gameOverScreenUI.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
            _inventory.IncrementBullets();
        }
        if (collision.CompareTag("Room"))
        {
            cameraScript.SetRoomTriggerTransform(collision.transform);
            cameraScript.SetInRoom(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var action = Input.GetAxis("Submit");
        if (collision.CompareTag("Ladders"))
        {
            playerMovement.onLadder = true;
        }
        else if (collision.CompareTag("Interactable") && action != 0.0f && !interactedRecently)
        {
            var interactable = collision.gameObject.GetComponent<IInteractable>();
            interactable.Interact(player);
            interactedRecently = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            playerMovement.onLadder = false;
        }
        if (collision.CompareTag("Room"))
        {
            cameraScript.SetInRoom(false);
        }
    }

    public float GetDarknessTime()
    {
        return darknessTime;
    }

    public float GetDarknessTimeLimit()
    {
        return darknessTimeLimit;
    }
}
