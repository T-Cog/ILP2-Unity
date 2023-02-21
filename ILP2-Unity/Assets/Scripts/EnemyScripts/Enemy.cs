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
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        body.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool killPlayer = true;
        float playerCheck = 1f;

        int playerMask = LayerMask.GetMask("Player");
        RaycastHit2D hitPlayer = Physics2D.Raycast(transform.position, playerDirection, playerCheck, playerMask);

        Debug.DrawRay(transform.position, playerDirection, Color.green);

        if (hitPlayer)
        {
            player.SendMessage("PlayerDead", killPlayer);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        int bulletMask = LayerMask.GetMask("Bullet");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
