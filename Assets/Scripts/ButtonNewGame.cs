using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNewGame : MonoBehaviour
{

    private Button _button;
    // Start is called before the first frame update
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Debug.Log ("You have clicked the button!");
    }
}
