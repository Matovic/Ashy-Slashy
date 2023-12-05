using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    /*[SerializeField] private Animator walkingAnimation;
    [SerializeField] private float speed;
    private GameObject _player;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody2D;
    private bool _onLadder = false;*/

    private Transform _player;
    private NavMeshAgent _agent;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        /*_spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        walkingAnimation = GetComponent<Animator>();   */
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player").transform;
        _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_player == null) Destroy(gameObject);
        _agent.SetDestination(_player.position);
        _spriteRenderer.flipX = !(_agent.velocity.x >= 0);
        /*if (_onLadder)
        {
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.velocity = Vector3.zero;
        }
        else _rigidBody2D.gravityScale = 1;
        
        var playerTransform = _player.transform;
        //Vector3 forwardAxis = new Vector3 (0, 0, -2);
        
        Vector3 difference = playerTransform.position - transform.position;
        difference = difference.normalized;

        if (difference.x < 0) _spriteRenderer.flipX = true;

        var distance = Vector2.Distance(playerTransform.position, transform.position);
        //Debug.Log($"{difference}");
        if (distance > 1.0f) {
            transform.position += (difference * (speed * Time.deltaTime));
            walkingAnimation.SetInteger("Animate", 2);
        } 
        else{
            //do whatever the enemy has to do with the player
        }

        transform.LookAt(target.position, forwardAxis);
        Debug.DrawLine(transform.position, target.position);
        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.position -= transform.TransformDirection(Vector2.up) * speed * Time.deltaTime; */
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
    
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladders"))
        {
            _onLadder = true;
        }
        else _onLadder = false;
    }*/
}
