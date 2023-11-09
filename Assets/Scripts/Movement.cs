using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] bool faceLeft = false;
    
    public GameObject general, Helmet, Ordinary;
    public Animator generalAnimator, helmetAnimator, ordinaryAnimator;
    public System.DateTime startTime;
    
    void OnTriggerEnter(Collider other) {  
        Debug.Log("Another object has entered the trigger");  
    } 
    
    // Start is called before the first frame update
    void Start()
    {
        generalAnimator = general.GetComponent<Animator>();
        helmetAnimator = Helmet.GetComponent<Animator>();
        ordinaryAnimator = Ordinary.GetComponent<Animator>();   
        startTime = System.DateTime.UtcNow;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        System.TimeSpan ts = System.DateTime.UtcNow - startTime;
            
        //Quaternion rotation = Quaternion.LookRotation(direction - transform.position);
        
        //generalAnimator.SetInteger("Animate", 2);
        //helmetAnimator.SetInteger("Animate", 2);
        //ordinaryAnimator.SetInteger("Animate", 2);
        
        // set rotation
        if (!faceLeft && direction.x < 0)
        {
            faceLeft = true;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        
        else if (faceLeft && direction.x > 0)
        {
            faceLeft = false;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        
        // Animation
        // TODO: separate file for animations
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
            startTime = System.DateTime.UtcNow;
            //Debug.Log("Walk");
            generalAnimator.SetInteger("Animate", 2);
        }
        
        if (faceLeft)
        {
            direction.x = -direction.x;
        }
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
