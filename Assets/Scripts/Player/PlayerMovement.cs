using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;
        [SerializeField] private float runMultiplier = 2.0f;
        [SerializeField] private float staminaMax = 5.0f;
        [SerializeField] private float exhaustThreshold = 2.0f;
        private float _stamina;
        private bool _isExhausted;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidBody2D;
        public bool onLadder = false;
        private bool _isShrinked = false;
        private Vector3 originalScale;
        [SerializeField] float scaleShrinkFactor;
        private string orientation;
    
        // Start is called before the first frame update
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _stamina = staminaMax;
            _isExhausted = false;
            _isShrinked = false;
            originalScale = transform.localScale;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isShrinked)
            {
                transform.localScale = originalScale * scaleShrinkFactor;
            }
            else
            {
                transform.localScale = originalScale;
            }
            var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            // for running we use "jump" button - space bar
            var isRunning = Input.GetAxis("Jump") > 0;

            // rotate player based on the horizontal key  
            var flipX = _spriteRenderer.flipX;
            flipX = direction.x switch
            {
                < 0 => true,
                > 0 => false,
                _ => flipX
            };

            _spriteRenderer.flipX = flipX;

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
                orientation = "right";
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
            {
                orientation = "left";
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
            }
            // move up
            else if (Input.GetAxis("Vertical") > 0 && onLadder)
            {
                orientation = "up";
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
            }
            // move down
            else if (Input.GetAxis("Vertical") < 0 && onLadder)
            {
                orientation = "down";
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
            }
            // standing
            else
                _stamina = Mathf.Min(staminaMax, _stamina + Time.deltaTime);
            if (_stamina > exhaustThreshold)
            {
                _isExhausted = false;
            }
        }

        public float GetStamina()
        {
            return _stamina;
        }

        public float GetStaminaMax()
        {
            return staminaMax;
        }

        public void SetIsShrinked(bool isShrinked)
        {
            _isShrinked = isShrinked;
        }

        public bool GetIsShrinked()
        {
            return _isShrinked;
        }

        public string GetOrientation()
        {
            return orientation;
        }
    }
}
