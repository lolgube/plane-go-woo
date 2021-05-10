using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;

    public bool canShoot;
    public float fireRate;
    public float health;

    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        
    }
    
    void Update() {
        // y speed needs to be negative (since it's going down)
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
    }

    // if collission with player
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Player"){

            // enemy collides with player ship, get player collider, 
            // ...get player gameobject, get spaceship script, take damage.
            col.gameObject.GetComponent<SpaceShip>().Damage();
            Die();
        }
    }
    
    void Die(){
            // die
            Destroy(gameObject);

            // play particle effect
            // maybe play a sound?
    }

    // if they take damage, reduce health, if health at 0, die function. 
    public void Damage(){
        health--;
        if(health == 0){
            Die();
        }
    }
}
