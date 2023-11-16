using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float runMultiplier = 2.0f;
    [SerializeField] private GameObject shotgun;
    [SerializeField] private float staminaMax = 5.0f;
    [SerializeField] private float exhaustThreshold = 2.0f;
    private float _stamina;
    private bool _isExhausted;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _shotgunSpriteRenderer;
    private Rigidbody2D _rigidBody2D;
    public bool hasShotgun = false;
    public bool onLadder = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shotgunSpriteRenderer = shotgun.GetComponent<SpriteRenderer>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _stamina = staminaMax;
        _isExhausted = false;
    }

    // Update is called once per frame
    private void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        // for running we use "jump" button - space bar
        var isRunning = Input.GetAxis("Jump") > 0 ? true : false;
        
        // rotate player based on the horizontal key  
        var flipX = _spriteRenderer.flipX;
        flipX = direction.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => flipX
        };

        // TODO: rebrík logika
        // rebríkový prefab, kde bude viac packageov, a dať na 3 trigry na rebrík
        // triger na celom, 2 trigry na konci
        // v strednom trigery sa nemôžem chýbať doľava doprava
        // on trigerEnter, Exit a vypinanie pohybových kľúčov
        
        // not moving in vertical direction, if you are not on the ladder
        //if (!onLadder) direction.y = 0.0f;
        // not moving in horizontal direction, if you are not the ladder
        //else direction.x = 0.0f;
        
        // control running 
        //speed = Math.Abs(run - 1.0f) < 0.1 ? 5.0f : 2.0f;
        
        _spriteRenderer.flipX = flipX;
        if(hasShotgun) _shotgunSpriteRenderer.flipX = flipX;
        
        if (onLadder)
        {
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.velocity = Vector3.zero;
        }
        else _rigidBody2D.gravityScale = 1;

        // moving section
        // move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (isRunning && _stamina > Time.deltaTime && _stamina - Time.deltaTime >= 0 && !_isExhausted)
            {
                transform.position += transform.right * speed * runMultiplier * Time.deltaTime;
                _stamina = Mathf.Max(0, _stamina - Time.deltaTime);
                if (_stamina < Time.deltaTime)
                {
                    _isExhausted = true;
                }
            }
            else
            {
                transform.position += transform.right * speed * Time.deltaTime;
                _stamina = Mathf.Min(staminaMax, _stamina + Time.deltaTime);
            }
        }
        // move left
        else if (Input.GetAxis("Horizontal") < 0)
            if (isRunning && _stamina > Time.deltaTime && _stamina - Time.deltaTime >= 0 && !_isExhausted)
            {
                transform.position += -transform.right * speed * runMultiplier * Time.deltaTime;
                _stamina = Mathf.Max(0, _stamina - Time.deltaTime);
                if (_stamina < Time.deltaTime)
                {
                    _isExhausted = true;
                }
            }
            else
            {
                transform.position += -transform.right * speed * Time.deltaTime;
                _stamina = Mathf.Min(staminaMax, _stamina + Time.deltaTime);
            }
        // move up
        else if (Input.GetAxis("Vertical") > 0 && onLadder)
            if (isRunning && _stamina > Time.deltaTime && _stamina - Time.deltaTime >= 0 && !_isExhausted)
            {
                transform.position += transform.up * speed * runMultiplier * Time.deltaTime;
                _stamina = Mathf.Max(0, _stamina - Time.deltaTime);
                if (_stamina < Time.deltaTime)
                {
                    _isExhausted = true;
                }
            }
            else
            {
                transform.position += transform.up * speed * Time.deltaTime;
                _stamina = Mathf.Min(staminaMax, _stamina + Time.deltaTime);
            }
        // move down
        else if (Input.GetAxis("Vertical") < 0 && onLadder)
            if (isRunning && _stamina > Time.deltaTime && _stamina - Time.deltaTime >= 0 && !_isExhausted)
            {
                transform.position += -transform.up * speed * runMultiplier * Time.deltaTime;
                _stamina = Mathf.Max(0, _stamina - Time.deltaTime);
                if (_stamina < Time.deltaTime)
                {
                    _isExhausted = true;
                }
            }
            else
            {
                transform.position += -transform.up * speed * Time.deltaTime;
                _stamina = Mathf.Min(staminaMax, _stamina + Time.deltaTime);
            }
        // standing
        else
            _stamina = Mathf.Min(staminaMax, _stamina + Time.deltaTime);
        if (_stamina > exhaustThreshold)
        {
            _isExhausted = false;
        }
    }

    public float getStamina()
    {
        return _stamina;
    }

    public float getStaminaMax()
    {
        return staminaMax;
    }
}
