using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private System.DateTime _startTime;
    
    [SerializeField] private GameObject general, Helmet, Ordinary;
    [SerializeField] private Animator generalAnimator, helmetAnimator, ordinaryAnimator;
    
    // Start is called before the first frame update
    private void Start()
    {
        generalAnimator = general.GetComponent<Animator>();
        //helmetAnimator = Helmet.GetComponent<Animator>();
        //ordinaryAnimator = Ordinary.GetComponent<Animator>();   
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
                //Debug.Log("Yawn"); //, ts.Seconds.ToString ()
                generalAnimator.SetInteger("Animate", 1);
                break;
            // Bored animation
            case 0 when ts.Seconds is >= 3 and < 6:
                //Debug.Log("Bored"); //, ts.Seconds.ToString ()
                generalAnimator.SetInteger("Animate", 3);
                break;
            // Idle animation
            case 0 when ts.Seconds < 3:
                //Debug.Log("Idle");
                generalAnimator.SetInteger("Animate", 0);
                break;
            // Walk animation
            default:
            {
                if (direction.x != 0)
                {
                    _startTime = System.DateTime.UtcNow;
                    //Debug.Log("Walk");
                    generalAnimator.SetInteger("Animate", 2);
                }
                break;
            }
        }
    }
}
