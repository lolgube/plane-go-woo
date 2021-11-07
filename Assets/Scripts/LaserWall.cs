using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    public Rigidbody2D laserWallRB;
    public BoxCollider2D laserWallCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If you collide with the laser wall
        if (collision.gameObject.tag == "Player")
        {
            //The player takes damage
            collision.gameObject.GetComponent<SpaceShip>().Damage();
            laserWallCollider.enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laserWallRB == true)
        {
        //Makes the laserwall move down forever
        laserWallRB.AddForce(new Vector2(0,-10));
        }


        //Destroys laserwall after two seconds
        Destroy(gameObject, 2);
    }
}
