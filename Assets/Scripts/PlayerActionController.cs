using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerActionController : MonoBehaviour
{
    private Inventory _inventory;
    private ShotgunScript _shotgun;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject shotgun;
    private static GameObject _box;
    public bool isPickable, isBreakable = false;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _shotgun = GameObject.FindGameObjectWithTag("Player").GetComponent<ShotgunScript>();
    }

    /*public static void SetGameObject(string typeGameObject, GameObject gameObj)
    {
        if(typeGameObject.ToLower() == "box")
        {
            //Debug.Log("box");
            _box = gameObj;
        }
    }*/

    // Update is called once per frame
    private void Update()
    {
        // action button is submit button
        /*var action = Input.GetAxis("Submit");
        if (isBreakable && action != 0.0f)
        {
            var script = _box.GetComponent<BoxScript>();
            script.Break();
            isBreakable = false;
        }*/
    }
}
