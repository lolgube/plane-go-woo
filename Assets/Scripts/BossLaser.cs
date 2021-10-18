using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public GameObject laserWall;


    //Creates array for x position
    public int[] laserPositionX;



    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For testing
        if (Input.GetKeyDown(KeyCode.A))
        {
            BossLazerAttack();
        }
    }

    //Method for the laser attack
    public void BossLazerAttack()
    {
        //Spans laserwallattack randomly in one of three positions
        Instantiate(laserWall, new Vector2(laserPositionX[Random.Range(0, 3)], 20), Quaternion.identity);
    }

}
