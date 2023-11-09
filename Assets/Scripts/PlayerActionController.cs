using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private GameObject general;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject shotgun;
    public bool isPickable = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // action button is submit button
        var action = Input.GetAxis("Submit");
        if (isPickable && action != 0.0f)
        {
            shotgun.transform.SetParent(general.transform);
            playerMovement.hasShotgun = true;
        }
        //if (action != 0)
    }
}
