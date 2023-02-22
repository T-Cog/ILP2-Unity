using System.Xml.Serialization;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class BirdAI : MonoBehaviour
{
    private Rigidbody2D body;

    public float speed = 1;
    public float decayTimeInSeconds = 3;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") || 
            collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            Destroy(gameObject, decayTimeInSeconds);
            Debug.Log("birb ded");
        }
    }
}
