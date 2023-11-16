using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaminaTextScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerScript;
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = playerScript.getStamina().ToString("F2") + " / " + playerScript.getStaminaMax().ToString();
    }
}
