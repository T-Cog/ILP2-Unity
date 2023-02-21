using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public float force;
    public float maxDistanceToEnemy;

    private float lifeTime;
    public float speed;

    public LayerMask layersToHit;
    public RaycastHit2D hitEnemy;
    
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        lifeTime = 2f;
    }

    void Start()
    {
        body.AddForce(transform.position * force, ForceMode2D.Impulse);
    }

    private void Update()
    {
        MoveToEnemy();
    }

    void FixedUpdate()
    {
        Destroy(gameObject, lifeTime);
    }

    void MoveToEnemy()
    {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = (new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0) - transform.position).normalized;

        //int enemyLayerMask = LayerMask.GetMask("Enemy");

        RaycastHit2D hitEnemy = Physics2D.Raycast(player.transform.position, directionToMouse, maxDistanceToEnemy, layersToHit);
        Debug.DrawRay(transform.position, directionToMouse, Color.green);

        if (hitEnemy)
        {
            Debug.Log("Smak");
        }
        
    }
}
