using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadlampScript : MonoBehaviour, IInteractable
{
    private bool isEquiped = false;
    [SerializeField] GameObject lights;
    [SerializeField] Transform lightTransform;
    [SerializeField] SpriteRenderer flashlightSpriteRenderer;
    [SerializeField] Transform flashlightTransform;
    private Vector3 flashlightOriginalLocalPosition;
    private Vector3 flashlightFlippedLocalPosition;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] PlayerMovement movement;
    [SerializeField] Inventory inventory;
    private BoxCollider2D _boxCollider;

    void Start()
    {
        flashlightOriginalLocalPosition = flashlightTransform.localPosition;
        flashlightFlippedLocalPosition = flashlightTransform.localPosition;
        flashlightFlippedLocalPosition.x = -flashlightOriginalLocalPosition.x;
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isEquiped)
        {
            // update light orientation
            Quaternion localRotation = default;
            switch (movement.GetOrientation())
            {
                case "up":
                    localRotation.eulerAngles = new Vector3(0, 0, 0);
                    lightTransform.localRotation = localRotation;
                    break;
                case "down":
                    localRotation.eulerAngles = new Vector3(0, 0, 180);
                    lightTransform.localRotation = localRotation;
                    break;
                case "right":
                    localRotation.eulerAngles = new Vector3(0, 0, 270);
                    lightTransform.localRotation = localRotation;
                    break;
                case "left":
                    localRotation.eulerAngles = new Vector3(0, 0, 90);
                    lightTransform.localRotation = localRotation;
                    break;
            }

            // move flashlight on flip
            if (playerSpriteRenderer.flipX)
            {
                flashlightTransform.localPosition = flashlightFlippedLocalPosition;
                flashlightSpriteRenderer.flipY = true;
            }
            else
            {
                flashlightTransform.localPosition = flashlightOriginalLocalPosition;
                flashlightSpriteRenderer.flipY = false;
            }
        }
    }
    public void Interact(GameObject player)
    {
        // attach to player
        Transform transformItem;
        (transformItem = transform).SetParent(player.transform);
        transformItem.localPosition = new Vector3(0.0f, 1.7f, -0.5f);
        // add to inventory
        inventory.SetItemBool("headlamp", true);
        lights.SetActive(true);
        isEquiped = true;
        _boxCollider.enabled = false;
    }
}
