using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private System.DateTime _startTime;
    
        [SerializeField] private GameObject general;
        [SerializeField] private Animator generalAnimator;
    
        // Start is called before the first frame update
        private void Start()
        {
            generalAnimator = general.GetComponent<Animator>(); 
            _startTime = System.DateTime.UtcNow;
        }

        // Update is called once per frame
        private void Update()
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            var ts = System.DateTime.UtcNow - _startTime;
            switch (direction.x)
            {
                // Animation
                // Yawn animation
                case 0 when ts.Seconds >= 6:
                    generalAnimator.SetInteger("Animate", 1);
                    break;
                // Bored animation
                case 0 when ts.Seconds is >= 3 and < 6:
                    generalAnimator.SetInteger("Animate", 3);
                    break;
                // Idle animation
                case 0 when ts.Seconds < 3:
                    generalAnimator.SetInteger("Animate", 0);
                    break;
                // Walk animation
                default:
                {
                    if (direction.x != 0)
                    {
                        _startTime = System.DateTime.UtcNow;
                        generalAnimator.SetInteger("Animate", 2);
                    }
                    break;
                }
            }
        }
    }
}
