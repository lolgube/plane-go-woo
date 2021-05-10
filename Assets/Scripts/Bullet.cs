using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rb;
    // for some reason unity does not give a single fuck about this value
    // it just decides on it's own whatever the fuck this is going to be
    public float bulletTimeLeftAlive = 1.25f;

    // to keep track if our bullet is going up or down
    int dir = 1;

    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // if we ever need to make it go down
    public void ChangeDirection() {
        dir*=-1;
    }

    // makes our bullet move (*dir means direction, moves down if it's negative)
    void Update() {
        rb.velocity = new Vector2(0,10*dir); 

        // destroys our bullet after a while
        bulletTimeLeftAlive -= Time.deltaTime;
        if(bulletTimeLeftAlive < 0f){
            Destroy(gameObject);
        }
        //print(bulletTimeLeftAlive);
    }

    // have to define if this is enemy or player bullet
    // this is where the bullet collision stuff is
    void OnTriggerEnter2D(Collider2D col){
        
        // if bullets hit enemy
        if(dir==1){
            if(col.gameObject.tag=="Enemy"){
                col.gameObject.GetComponent<Enemy>().Damage();
            
                // add sound or particle effect (or something) here

                Destroy(gameObject);
            }
            // if bullets are going down & hit player
        }else{
            if(col.gameObject.tag=="Player"){
                col.gameObject.GetComponent<SpaceShip>().Damage();
            
                // add sound or particle effect (or something) here

                Destroy(gameObject); 
            }
        }
    }
}