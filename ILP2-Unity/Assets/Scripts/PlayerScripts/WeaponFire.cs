using UnityEngine;

public class WeaponFire : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;
    public float bulletForce = 20f;


    public void Update()
    {
        Fire();    
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject shootBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            shootBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}
