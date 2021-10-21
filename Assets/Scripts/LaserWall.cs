using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    public Rigidbody2D laserWallRB;
    public BoxCollider2D laserWallCollider;

    private void OnCollisionEnter(Collision collision)
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
        //Makes the laserwall move down forever
        Debug.Log("Frame");
        laserWallRB.AddForce(new Vector2(0,-10));


        Destroy(gameObject, 2);
    }
}
