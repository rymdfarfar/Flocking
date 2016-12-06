using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class serialization : MonoBehaviour {

    string fileName = "load";
    
    public Boids boid;
    bool loaded;
    public List<Vector3> pos = new List<Vector3>();
    public List<Vector3> rot = new List<Vector3>();
    public List<string> boidInfo = new List<string>();
    

    // Use this for initialization
    void Start () {
        loaded = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SaveBoids()
    {
        //if (File.Exists(fileName))
        //{
        //    var sr = File.CreateText(fileName);
        //    foreach (Boids boid in Master.instance.boids)
        //    {
        //        sr.WriteLine(boid.transform.position);
        //        sr.WriteLine(boid.transform.rotation);
        //    }
        //}

        //else
        //{
        //    var sr = File.CreateText(fileName);
        //    foreach (Boids boid in Master.instance.boids)
        //    {
        //        sr.WriteLine(boid.transform.position);
        //        sr.WriteLine(boid.transform.rotation);
        //    }
        //}
        var sr = File.CreateText(fileName);
        foreach (Boids boid in Master.instance.boids)
        {
            sr.WriteLine(boid.transform.position);
            sr.WriteLine(boid.transform.rotation);
        }

        sr.Close();
    }

    public void LoadBoids()
    {
   
        if (!loaded)
        {
            loaded = true;
            StreamReader read = new StreamReader(fileName);
            Debug.Log("load1");
         

            for (int index = 0; index < Master.instance.boidsToSpawn *2; ++index)
            {

                string temp = read.ReadLine();
                Debug.Log(temp);
                boidInfo.Add(temp);

               





            }

            for (int addIndex = 0; addIndex < boidInfo.Count; ++addIndex)
            {

                Debug.Log(boidInfo.Count);
                Debug.Log("pos");
                if (!IsEven(addIndex))
                {

                    rot.Add(StringToVector3(boidInfo[addIndex]));
                   
                }
                else
                {

                      pos.Add( StringToVector3(boidInfo[addIndex]));
                  


                  
                }
            
            }


            for (int spawnIndex = 0; spawnIndex < Master.instance.boidsToSpawn; ++spawnIndex)
            {
                Debug.Log("spawm");
                Boids temp = (Boids)Instantiate(boid);
                Master.instance.boids.Add(temp);
                temp.transform.position = pos[spawnIndex];
                temp.transform.rotation = Quaternion.Euler(rot[spawnIndex]);
            }




        }


    }
    public static bool IsEven(int value)
    {
        return value % 2 == 0;
    }
    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
