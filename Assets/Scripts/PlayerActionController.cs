using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private GameObject general;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject shotgun;
    private static GameObject _box;
    private PickUp _pickUp;
    public bool isPickable, isBreakable = false;

    public static void SetGameObject(string typeGameObject, GameObject gameObj)
    {
        if(typeGameObject.ToLower() == "box")
        {
            //Debug.Log("box");
            _box = gameObj;
        }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _pickUp = shotgun.GetComponent<PickUp>();
    }

    // Update is called once per frame
    private void Update()
    {
        // action button is submit button
        var action = Input.GetAxis("Submit");
        if (isPickable && action != 0.0f)
        {
            shotgun.transform.SetParent(general.transform);
            shotgun.transform.localPosition = new Vector3(0.0f, 0.5f, -1.0f);
            playerMovement.hasShotgun = true;
            _pickUp.DrawShotgun();
        }
        else if (isBreakable && action != 0.0f)
        {
            var script = _box.GetComponent<BoxScript>();
            script.Break();
            isBreakable = false;
            //Destroy(_box);
            //Debug.Log("Destroy!");
        }
        /*else if (isPickable && action != 0.0f)
        {
            Destroy(box);
            //Debug.Log("Destroy!");
        }*/
        //if (action != 0)
    }
}
