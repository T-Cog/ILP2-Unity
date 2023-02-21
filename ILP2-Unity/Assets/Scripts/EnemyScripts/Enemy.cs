using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    public Transform player;

    private Rigidbody2D body;

    private Vector2 movement;
    private Vector3 direction;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the direction between the player and enemy position
        direction = player.position - transform.position;
        //Calculates the angle for enemy rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Rotates the enemy to face towards the player
        body.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        body.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int playerMask = LayerMask.GetMask("Player");
        RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, (Vector2) direction) 

        if (playerMask)
        {

        }
    }
}
