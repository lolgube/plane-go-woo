using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;

    public float xSpeed;
    public float ySpeed;

    public bool canShoot;
    public float fireRate;
    public float health;

    public Color bulletColor;

    // shot position
    public GameObject c;

    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        // destroys the enemy after a certain amount of itme
        Destroy(gameObject,12);

        // if we can't shoot, piss off
        if(!canShoot) return;
            //finds our shooting location
            c = transform.Find("C").gameObject;

            // randomizes the firerate to either shoot half as slow or half as fast
            fireRate=fireRate+(Random.Range(fireRate/-2,fireRate/2));
            // will repeat the funciton called Shoot for firerate seconds every firerate
            InvokeRepeating("Shoot",fireRate,fireRate);
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

    // spawns a bullet at our c location and flips the direction from the bullet script. 
    void Shoot(){
        GameObject temp = (GameObject) Instantiate(bullet,c.transform.position,Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();

        // lets us change our instantiated bullets color
        // fyi you need to change the alpha to be able to see the bullets, unity ain't smart enough 
        // to do that on its own.
        temp.GetComponent<Bullet>().ChangeColor(bulletColor);
    }
}
