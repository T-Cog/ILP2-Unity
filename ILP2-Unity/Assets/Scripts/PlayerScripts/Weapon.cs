using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]

public class Weapon : MonoBehaviour
{
    public float force;
    public float maxDistanceToEnemy;

    private float lifeTime;

    public float speed;

    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        lifeTime = 2f;
    }

    void Start()
    {
        body.AddForce(transform.position * force, ForceMode2D.Impulse);
        body.AddTorque(force, ForceMode2D.Impulse);
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        Destroy(gameObject, lifeTime);
    }

    void MoveToEnemy()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = (new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0) - transform.position).normalized;

       // Physics2D.Raycast(transform.position, directionToMouse, maxDistanceToEnemy, layerMask);
        //Vector3.MoveTowards(transform.position, )
    }
}
