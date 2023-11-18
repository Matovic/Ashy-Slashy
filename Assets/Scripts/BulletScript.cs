using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float _speed, _secondsinUse;
    private System.DateTime _startTime;
    private bool flipX;

    private SpriteRenderer _playerSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 20.0f;
        _secondsinUse = 0.1f;
        _playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        flipX = _playerSpriteRenderer.flipX;
        _startTime = System.DateTime.UtcNow;
        
    }

    // Update is called once per frame
    private void Update()
    {
        var ts = System.DateTime.UtcNow - _startTime;
        if (ts.Seconds >= _secondsinUse)
            Destroy(gameObject);
        if (flipX)
            transform.position -= transform.right * (_speed * Time.deltaTime);
        else 
            transform.position += transform.right * (_speed * Time.deltaTime);
    }
}
