using UnityEngine;
[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))] 

public class BirdAI : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    
    public float speed = 1;
    private float decayTimeInSeconds = 1.5f;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Sets the bird's flight to the right on spawn
        body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the bird collides with a bullet or map boundary, then triggers the death animation and destroys the object
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") || 
            collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            anim.SetTrigger("DeadTrigger");
            Destroy(gameObject, decayTimeInSeconds);
            Debug.Log("birb ded");
        }
    }
}
