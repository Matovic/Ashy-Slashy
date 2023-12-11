using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessUI : MonoBehaviour
{
    [SerializeField] Image darkness;
    [SerializeField] Collisions collisions;
    void Update()
    {
        var newColor = darkness.color;
        newColor.a = Mathf.Min(1.0f, collisions.GetDarknessTime() / collisions.GetDarknessTimeLimit());
        darkness.color = newColor;
    }
}
