using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
   
    public Boids boid;
    public int boidsToSpawn;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public Vector3 spawnPoint;
    private float randomX = 0;
    private float randomY = 0;
    public bool spawning = true;
    // Use this for initialization
    void Start()
    {
      
    }

	
	// Update is called once per frame
	void Update () {

        
        if (spawning)
        {
            for (int i = 0; i < boidsToSpawn; ++i)
            {
                Boids tempboid;
                randomX = Random.Range(spawnPoint1.transform.position.x, spawnPoint2.transform.position.x);
                randomY = Random.Range(spawnPoint1.transform.position.y, spawnPoint2.transform.position.y);
                spawnPoint = new Vector3(randomX, randomY, 0);

                tempboid = (Boids)Instantiate(boid, spawnPoint, Quaternion.identity);
                Master.instance.boids.Add(tempboid);

                if ((i + 2) > boidsToSpawn)
                    spawning = false;
            }
        }

    }
}
