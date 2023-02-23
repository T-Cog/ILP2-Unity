using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public AnimationCurve movementCurve;    
    
    public float speed;
    private float time;

    void Update()
    {
        // Gets the position of the mouse in world space
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Gets the direction to the mouse from the player
        Vector3 directionToMouse = (new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0) - transform.position).normalized;

        // Calculates the angle of the direction vector
        float angleInRadians = Mathf.Atan2(directionToMouse.y, directionToMouse.x);
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // Sets the rotation of the player to the angle to the mouse
        transform.eulerAngles = new Vector3(0, 0, angleInDegrees);


        
        if (Input.GetMouseButton(0))
        {
            // Adds time while left click is pressed and matches the speed to the value of the animation curve
            time += Time.deltaTime;
            speed = movementCurve.Evaluate(time);

            // Moves the player to the direction of the mouse the rate of the speed variable
            transform.position = Vector3.MoveTowards(transform.position, mousePositionInWorld, speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Resets the time variable to 0 when left click is released
            time = 0;
        }
    }


}
