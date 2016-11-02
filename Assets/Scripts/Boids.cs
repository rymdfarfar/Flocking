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

        Vector2 corner1 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 corner2 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 pos = transform.position;

        if (this.transform.position.x < corner1.x)
        {
            pos.x += corner2.x - corner1.x;
        }

        if (transform.position.x > corner2.x)
        {
            pos.x -= corner2.x - corner1.x;
        }


        if (this.transform.position.y < corner1.y)
        {
            pos.y += corner2.y - corner1.y;
        }

        if (transform.position.y > corner2.y)
        {
            pos.y -= corner2.y - corner1.y;
        }

        transform.position = pos;

            myBoid = this.gameObject.GetComponent<Boids>();
        velocity = GetComponentInChildren<Rigidbody2D>().velocity;
        if(Master.instance.alignmentOn)
        alignment = Alignment();

        if(Master.instance.cohesionOn)
        cohesion = Cohesion();

        if(Master.instance.seperationOn)
        seperation = Separation();

        velocity = Master.instance.movePoint + (alignment * Master.instance.alignmentValue) + (cohesion * Master.instance.cohesionValue) + (seperation * Master.instance.seperationValue);
        velocity.Normalize();

        GetComponent<Rigidbody2D>().velocity = velocity * Master.instance.speed;
        
    }
    Vector2 Alignment()
    {
        neighborsCount = 0;
        float distanceBetween;
        foreach (Boids boid in Master.instance.boids)
        {
            if (boid != myBoid)
            {
                distanceBetween = Vector2.Distance(this.transform.position, boid.transform.position);
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
        neighborsCount = 0;
        float distanceBetween;
        foreach (Boids boid in Master.instance.boids)
        {
            if (boid != myBoid)
            {
                distanceBetween = Vector2.Distance(this.transform.position, boid.transform.position);
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
        velocity = new Vector2(velocity.x - this.transform.position.x, velocity.y - this.transform.position.y);
        velocity.Normalize();

        return velocity;
    }

    Vector2 Separation()
    {
        neighborsCount = 0;
        float distanceBetween;
        foreach (Boids boid in Master.instance.boids)
        {
            if (boid != myBoid)
            {
                distanceBetween = Vector2.Distance(this.transform.position, boid.transform.position);
                if (distanceBetween < 300)
                {
                    velocity.x += boid.transform.position.x - this.gameObject.transform.position.x;
                    velocity.y += boid.transform.position.y - this.gameObject.transform.position.y;

                   
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
