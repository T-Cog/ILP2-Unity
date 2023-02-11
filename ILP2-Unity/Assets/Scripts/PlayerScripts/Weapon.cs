using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]

public class Weapon : MonoBehaviour
{
    public float force;
    private float lifeTime;
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        lifeTime = 100;
    }

    void Start()
    {
        body.AddForce(transform.position * force, ForceMode2D.Impulse);
        body.AddTorque(force, ForceMode2D.Impulse);
    }


    void FixedUpdate()
    {
        lifeTime--;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
