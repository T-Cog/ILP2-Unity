using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;

    private float spawnTimer;
    private float setSpawnTimer;
    public float minSpawnTime;
    public float maxSpawnTime;


    void Start()
    {
        spawnTimer = setSpawnTimer;
    }

    void FixedUpdate()
    {
        //Sets the setSpawnTimer to a random range between the two floats to allow for tweaking
        setSpawnTimer = Random.Range(minSpawnTime, maxSpawnTime);

        //Reduces the spawn timer in seconds as long as it is above 0
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }

        //Spawns a zombie (declared in editor) once the spawn timer hits 0 and resets the spawn timer
        if (spawnTimer <= 0)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            spawnTimer = setSpawnTimer;
        }
    }
}
