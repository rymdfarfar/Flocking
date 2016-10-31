using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boids : MonoBehaviour {
    public int neighborsCount = 0;
    //public GameObject obj;
    public List<Boids> neighbors = new List<Boids>();
    public Vector2 velocity;
     public Boids myBoid;

    public Vector2 alignment;
    public Vector2 cohesion;
    public Vector2 seperation;
    // Use this for initialization
    void Start () {
        //obj = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        velocity = GetComponentInChildren<Rigidbody2D>().velocity;
        alignment = Alignment();
        cohesion = Cohesion();
        seperation = Separation();

        velocity = Master.instance.movePoint + alignment + cohesion + seperation;
        velocity.Normalize();

        GetComponent<Rigidbody2D>().velocity = velocity * 2;
        
    }
    Vector2 Alignment()
    { float distanceBetween;
        foreach (Boids boid in Master.instance.boids)
        {
            if (boid != myBoid)
            {
                distanceBetween = Vector2.Distance(myBoid.transform.position, boid.transform.position);
                if (distanceBetween < 300)
                {
                    velocity += boid.velocity;
                    ++neighborsCount;
                }

            }
        }
        if (neighborsCount == 0)
            return velocity;

        velocity = velocity / neighborsCount;
        velocity.Normalize();

        return velocity;
    }


    Vector2 Cohesion()
    {
        float distanceBetween;
        foreach (Boids boid in Master.instance.boids)
        {
            if (boid != myBoid)
            {
                distanceBetween = Vector2.Distance(myBoid.transform.position, boid.transform.position);
                if (distanceBetween < 300)
                {
                    velocity.x += boid.transform.position.x;
                    velocity.y += boid.transform.position.y;
                    ++neighborsCount;
                }

            }
        }
        if (neighborsCount == 0)
            return velocity;

        velocity = velocity / neighborsCount;
        velocity = new Vector2(velocity.x - myBoid.transform.position.x, velocity.y - myBoid.transform.position.y);
        velocity.Normalize();

        return velocity;
    }

    Vector2 Separation()
    {
        float distanceBetween;
        foreach (Boids boid in Master.instance.boids)
        {
            if (boid != myBoid)
            {
                distanceBetween = Vector2.Distance(myBoid.transform.position, boid.transform.position);
                if (distanceBetween < 300)
                {
                    velocity.x += boid.transform.position.x - myBoid.transform.position.x;
                    velocity.y += boid.transform.position.y - myBoid.transform.position.y;

                   
                    ++neighborsCount;
                }

            }
        }
        if (neighborsCount == 0)
            return velocity;

        velocity = velocity / neighborsCount;
        velocity *= -1;
        velocity.Normalize();

        return velocity;
    }







}
