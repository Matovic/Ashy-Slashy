using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private System.DateTime _startTime;
    
    public GameObject general, Helmet, Ordinary;
    public Animator generalAnimator, helmetAnimator, ordinaryAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        generalAnimator = general.GetComponent<Animator>();
        helmetAnimator = Helmet.GetComponent<Animator>();
        ordinaryAnimator = Ordinary.GetComponent<Animator>();   
        _startTime = System.DateTime.UtcNow;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        System.TimeSpan ts = System.DateTime.UtcNow - _startTime;
        // Animation
        if (direction.x == 0 && ts.Seconds >= 6)
        {
            //Debug.Log("Yawn"); //, ts.Seconds.ToString ()
            generalAnimator.SetInteger("Animate", 1);
        }
        else if (direction.x == 0 && ts.Seconds is >= 3 and < 6)
        {
            //Debug.Log("Bored"); //, ts.Seconds.ToString ()
            generalAnimator.SetInteger("Animate", 3);
        }
        else if (direction.x == 0 && ts.Seconds < 3)
        {
            //Debug.Log("Idle");
            generalAnimator.SetInteger("Animate", 0);
        }
        else if (direction.x != 0)
        {
            _startTime = System.DateTime.UtcNow;
            //Debug.Log("Walk");
            generalAnimator.SetInteger("Animate", 2);
        }
    }
}
