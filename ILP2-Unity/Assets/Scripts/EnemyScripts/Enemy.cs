using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Transform playerPosition;

    private Rigidbody2D body;

    private Vector2 movement;
    private Vector3 playerDirection;
    public float speed = 5f;
 
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        playerPosition = player.transform;
    }


    void Update()
    {
        //Sets the direction between the player and enemy position
        playerDirection = playerPosition.position - transform.position;
        //Calculates the angle for enemy rotation
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

        //Rotates the enemy to face towards the player
        body.rotation = angle;
        playerDirection.Normalize();
        movement = playerDirection;  
    }

    private void FixedUpdate()
    {
        // Passes the movement variable to define the direction the enemy moves
        moveEnemy(movement);
    }

    //Moves the enemy towards the players position
    void moveEnemy(Vector2 direction)
    {
        body.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the enemy is hit by a bullet and then destroys itself if it is
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
        }

        // Checks if the enemy collides with the player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            bool killPlayer = true;
            float playerCheck = 1f;

            // Checks if the player is directly in front of the enemy with a short raycast
            int playerMask = LayerMask.GetMask("Player");
            RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, playerDirection, playerCheck, playerMask);

            // If the player is in front of the enemy when they make contact,
            // sends a message to the KillPlayer script to trigger game over
            if (hitPlayer)
            {
                player.SendMessage("PlayerDead", killPlayer);
            }
        }
    }
}
