using UnityEngine;

namespace Weapons
{
    public class BulletScript : MonoBehaviour
    {
        private float _speed, _secondsinUse;
        private System.DateTime _startTime;
        private bool _flipX;

        private SpriteRenderer _playerSpriteRenderer;
        // Start is called before the first frame update
        private void Start()
        {
            _speed = 20.0f;
            _secondsinUse = 0.1f;
            _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
            _flipX = _playerSpriteRenderer.flipX;
            _startTime = System.DateTime.UtcNow;
        
        }

        // Update is called once per frame
        private void Update()
        {
            var ts = System.DateTime.UtcNow - _startTime;
            if (ts.Seconds >= _secondsinUse)
                Destroy(gameObject);
            if (_flipX)
                transform.position -= transform.right * (_speed * Time.deltaTime);
            else 
                transform.position += transform.right * (_speed * Time.deltaTime);
        }
    }
}
