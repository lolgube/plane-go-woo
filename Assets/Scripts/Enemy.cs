using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet,explosion,battery;
    public Color bulletColor;
    // shooting position
    public GameObject c;

    // sets our x and y speed
    public float xSpeed, ySpeed;
    public bool canShoot;
    // sets our firerate and health
    public float fireRate, health;
    // how much score our enemies are worth
    public int score;
    
    



    // gets our rb
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        // destroys the enemy after a certain amount of itme
        Destroy(gameObject,16);

        // if we can't shoot, piss off
        if(!canShoot) return;{
            //finds our shooting location
            c = transform.Find("C").gameObject;

            // randomizes the firerate to either shoot twice as slow or half as fast
            // i realize now that "half as slow" and "half as fast" don't make much sense.
            // this is confusing. 
            // what would you even go about calling /-2..
            // negative half as fast?
            fireRate=fireRate+(Random.Range(fireRate/-2,fireRate/2));
            // will repeat the function called Shoot for firerate seconds every firerate
            InvokeRepeating("Shoot",fireRate,fireRate);
            }
        

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
            // also kill the enemy (they suck)
            Die();
        }
    }
    
    void Die(){
            if((int)Random.Range(0,5)==0){
                Instantiate(battery,transform.position,Quaternion.identity);
                // one in six chance to spawn battery
            }
        //transform.localScale += scaleChange;
        Squish();

        // plays our explosion particle effect
        Instantiate(explosion,transform.position,Quaternion.identity);
            // die
            Destroy(gameObject);
            // adds score onto our score variable using playerprefs
            // playerprefs is handy cause it saves it onto the computer and not just the current session
            // actually this is dumb and useless, but it works.
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score);

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
        // fyi you need to change the alpha to be able to see the bullets,  
        // unity ain't smart enough to do that on its own.
        temp.GetComponent<Bullet>().ChangeColor(bulletColor);
    }
    void Squish()
    {

    }
}
