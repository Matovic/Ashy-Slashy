using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {

        private Transform _player;
        private NavMeshAgent _agent;
        private SpriteRenderer _spriteRenderer;
    
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = GameObject.FindWithTag("Player").transform;
            _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (_player == null) Destroy(gameObject);
            _agent.SetDestination(_player.position);
            _spriteRenderer.flipX = !(_agent.velocity.x >= 0);
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
}
