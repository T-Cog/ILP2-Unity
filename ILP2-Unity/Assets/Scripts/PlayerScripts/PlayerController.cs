using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject weapon;

    void Update()
    {
        // get the position of the mouse in world space
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // get the direction to the mouse from the arrow
        Vector3 directionToMouse = (new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0) - transform.position).normalized;

        Debug.DrawLine(transform.position, transform.position + directionToMouse, Color.red);

        // using Mathf.Atan2, calculate the angle of the direction vector
        float angleInRadians = Mathf.Atan2(directionToMouse.y, directionToMouse.x);
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // set the rotation of the arrow to the angle to the mouse
        // note that sprites need to be pointing to the right or you will have to include an offset
        transform.eulerAngles = new Vector3(0, 0, angleInDegrees);


        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePositionInWorld, speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(weapon, transform.position, Quaternion.identity);
        }

    }
}