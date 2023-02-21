using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOperator : MonoBehaviour
{
    public Transform playerTracker;
    public float updateSpeed;
    public Vector2 trackingOffset;
    private Vector3 offset;

    void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - playerTracker.position.z;
    }

   
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTracker.position + offset, updateSpeed * Time.deltaTime);
    }
}
