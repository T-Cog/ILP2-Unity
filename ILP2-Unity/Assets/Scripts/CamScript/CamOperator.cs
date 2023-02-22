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
        // Offsets the camera to avoid clipping
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - player.position.z;
    }

   
    void LateUpdate()
    {
        // Moves the camera to the player position using lerp
        // Uses Lerp to create a sense of movement with the camera
        transform.position = Vector3.Lerp(transform.position, player.position + offset, updateSpeed * Time.deltaTime);
    }
}
