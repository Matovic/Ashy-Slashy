using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private GameObject _player;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        var target = _player.transform;
        Vector3 forwardAxis = new Vector3 (0, 0, -2);
        
        Vector3 displacement = target.position - transform.position;
        displacement = displacement.normalized;
        
        var distance = Vector2.Distance(target.position, transform.position);
        Debug.Log($"{displacement}");
        if (distance > 1.0f) {
            transform.position += (displacement * speed * Time.deltaTime);
        } 
        /*else{
            //do whatever the enemy has to do with the player
        }
        
        transform.LookAt(target.position, forwardAxis);
        Debug.DrawLine(transform.position, target.position);
        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.position -= transform.TransformDirection(Vector2.up) * speed * Time.deltaTime;*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
