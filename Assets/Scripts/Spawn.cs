using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public float rate;
    public GameObject[] enemies;
    public int waves = 1;

    void Start() {
        //invokeRepeating basically starts a desired function after x time, 
        //and then runs that function again every x time
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    // a lot of code in a single line.
    // spawns an enemy random enemy from the array, from the left to the right side of the screen above it, 
    // making sure they're facing the right direction
    // instantiate works by gameobject - position - direction/rotation
    // for loop decides how many times we're running this code, the higher the number the larger the "wave"
    void SpawnEnemy() {  
        for(int i=0; i<waves;i++)
            Instantiate(enemies[(int)Random.Range(0,enemies.Length)], new Vector3(Random.Range(-8f,8f),7,0), Quaternion.identity);
    }
}