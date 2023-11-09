using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] bool onLedder = false;
    [SerializeField] GameObject shotgun;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _shotgunSpriteRenderer;

    private void OnTriggerEnter(Collider other) {  
        Debug.Log("Another object has entered the trigger");  
    } 
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shotgunSpriteRenderer = shotgun.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        // rotate player based on horizontal key  
        var flipX = _spriteRenderer.flipX;
        flipX = direction.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => flipX
        };
        _spriteRenderer.flipX = flipX;
        _shotgunSpriteRenderer.flipX = flipX;
        // move
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
