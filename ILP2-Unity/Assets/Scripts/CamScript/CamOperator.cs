using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOperator : MonoBehaviour
{
    public Transform player;
    public float updateSpeed;
    public Vector2 trackingOffset;
    private Vector3 offset;

    void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - player.position.z;
    }

   
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, updateSpeed * Time.deltaTime);
    }
}
