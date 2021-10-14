using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public GameObject laserWall;


    //Creates array for x position
    float[] laserPositionX = new float[2];



    private void OnCollisionEnter(Collision collision)
    {
        //If you collide with the laser wall
        if(collision.gameObject.tag == "Player")
        {
            //The player takes damage
            collision.gameObject.GetComponent<SpaceShip>().Damage();
        }
    }

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
        //Chooses randomly which of the three positions the laser will spawn
        laserWall.transform.position = new Vector2(laserPositionX[Random.Range(0,2)], 10);

        
    }
    //Makes the laser go down
    public void BossLaserGoDown()
    {
        
    }
}
