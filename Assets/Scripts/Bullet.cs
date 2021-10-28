using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rb;
    // for some reason unity does not give a single fuck about this value
    // it just decides on it's own whatever the fuck this is going to be
    // not like it affects me, i guess.
    public float bulletTimeLeftAlive = 1.25f;

    // to keep track of if our bullet is going up or down
    int dir = 1;

    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // if we ever need to make it go down
    public void ChangeDirection() {
        dir*=-1;
    }

    // gets our sprite renderer for bullet colors
    public void ChangeColor(Color col){
        GetComponent<SpriteRenderer>().color=col;
    }

    // makes our bullet move (*dir means direction, moves down if it's negative)
    void Update()
    {
        //om skottet åker neråt(fienden som skuter) så åker den helften så snabbt- Alfred
        if (dir <=0)
        {
            rb.velocity = new Vector2(0, 5 * dir);
        }
        else if (dir >= 0)//om skottet åker uppåt(spelaren som skuter) så åker den i normal hastighet- Alfred
        {
            rb.velocity = new Vector2(0, 10 * dir);
        }
        
        // destroys our bullet after a while
        bulletTimeLeftAlive -= Time.deltaTime;
        if(bulletTimeLeftAlive < 0f){
            Destroy(gameObject);
        }
        //print(bulletTimeLeftAlive);
    }

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
            else
            {
                if (col.gameObject.tag == "BossEnemy")
                {
                    col.gameObject.GetComponent<BossEnemy>().Damage();

                    // add sound or particle effect (or something) here

                    Destroy(gameObject);
                }
            }
        }
    }
}