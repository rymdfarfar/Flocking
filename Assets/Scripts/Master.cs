using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Master : MonoBehaviour {
    public static Master instance = null;
    public List<Boids> boids = new List<Boids>();
    public Vector2 mousePosition;
    public float speed;
     public int boidsToSpawn;

    public int xBorder;
    public int yBorder;

    [Range(0,3)]
    public float seperationValue;

    [Range(0, 3)]
    public float alignmentValue;


    [Range(0, 3)]
    public float cohesionValue;

    public bool seperationOn;
    public bool alignmentOn;
    public bool cohesionOn;

    

    //public Spawner spawner;

    public Vector2 movePoint;
    void Awake()
    {
        boidsToSpawn = GameObject.FindObjectOfType<Spawner>().boidsToSpawn;
       
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of this class.
            Destroy(gameObject);

       
    }
    // Use this for initialization
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        movePoint = mousePosition;

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Time.timeScale = 0.0f;
        }
    }

    
    // Vector2 Alignment(Boids boid)
    //{
        
    //    //Vector2 velcoity;

    //    //return velcoity;

        
    //}


}
