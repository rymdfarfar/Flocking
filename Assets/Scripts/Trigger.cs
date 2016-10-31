using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
    public Boids boid;
    public int kina;

	// Use this for initialization
	void Start () {
        boid = GetComponentInParent<Boids>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject != this.gameObject)
        {
            boid.neighbors.Add(other.gameObject.GetComponent<Boids>());
            boid.neighborsCount++;
        }
           
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
          if(other.gameObject != this.gameObject)
        {
            boid.neighbors.Remove(other.gameObject.GetComponent<Boids>());
            boid.neighborsCount--;
        }
       

    }
}
