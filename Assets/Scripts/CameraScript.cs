using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform roomTriggerTransform;
    private float lerpRatio = 1.0f;
    private bool inRoom = true;
    // Update is called once per frame
    void Update()
    {
        if (inRoom)
        {
            lerpRatio = Mathf.Min(1.0f, lerpRatio + Time.deltaTime);
        }
        else
        {
            lerpRatio = Mathf.Max(0.0f, lerpRatio - Time.deltaTime);
        }
        transform.position = Vector3.Lerp(playerTransform.position + Vector3.back, roomTriggerTransform.position, lerpRatio);
    }

    public void SetRoomTriggerTransform(Transform rTT)
    {
        roomTriggerTransform = rTT;
    }

    public void SetInRoom(bool iR)
    {
        inRoom = iR;
    }
}
