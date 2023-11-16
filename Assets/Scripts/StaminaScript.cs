using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerScript;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = playerScript.getStamina() / playerScript.getStaminaMax();
    }
}
