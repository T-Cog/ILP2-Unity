using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        // Sets the bullet to be destroyed after being fired
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {    
        // Destroys the bullet on collision with any object
        Destroy(gameObject);
    }
}
