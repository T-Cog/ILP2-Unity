using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // Gets the position of the mouse in world space
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Gets the direction to the mouse from the player
        Vector3 directionToMouse = (new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0) - transform.position).normalized;

        Debug.DrawLine(transform.position, transform.position + directionToMouse, Color.red);

        // Calculates the angle of the direction vector
        float angleInRadians = Mathf.Atan2(directionToMouse.y, directionToMouse.x);
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // Sets the rotation of the player to the angle to the mouse
        transform.eulerAngles = new Vector3(0, 0, angleInDegrees);


        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePositionInWorld, speed * Time.deltaTime);
        }

    }
}
