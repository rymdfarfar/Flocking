﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Master : MonoBehaviour {
    public static Master instance = null;
    public List<Boids> boids = new List<Boids>();
    public Vector2 mousePosition;
    //public Spawner spawner;

    public Vector2 movePoint;
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

       
    }
    // Use this for initialization
    void Start () {
        //spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        movePoint = mousePosition;
       
    }

    
    // Vector2 Alignment(Boids boid)
    //{
        
    //    //Vector2 velcoity;

    //    //return velcoity;

        
    //}


}