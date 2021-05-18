using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    // a and b stand for the places where we instantiate the bullets (cannons)
    public GameObject a,b;
    float delay = 0;
    public GameObject bullet;
    Rigidbody2D rb;
    public float speed;
    public static int health= 8;

    private void Awake() {
        // gets our rb
        rb = GetComponent<Rigidbody2D>();

        // finds the location of our cannons (bullet spawnpoints)
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }

    void Start() {
        
    }

    void Update() {
        //movement times our speed variable
        // this solution gives us the classic problem of two input buttons at once being pressed
        // doubbling the movement speed, worth fixing?
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")* speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")* speed));

        // this solution below seems to work, direction.normalize seems to be what's fixing the issue.
        // speed values are different, but that'll be fixed manually
        // update, the code below actaully fucks with the movement pretty hard.
        // gives a bit of a delay when you stop pressing a button, not good.
        // yeah, i guess i'll just use the original solution. a shame.
        
        /*Vector2 direction = new Vector2(0,0);
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
        rb.AddForce(direction*speed); */

        // lemme try this - okay this gave the absolute worst result i've seen yet. nice
        //rb.velocity = rb.velocity.normalized * speed;

        // when you press space, shoot (if delay is more than X)
        if(Input.GetKey(KeyCode.Space)&&delay > .05){
            Shoot();
        }

        // adds time since last shot every frame
        // am very aware that this is dependant on FPS and will not end up the same on all computers
        // fuck. 
        //delay++;
        // update 1: okay, this made the calculation a bit different but it should end up being the same
        // maybe i'll have to test this, will i bother tho?
        // update 2: it messed with a few things but i patched those up, this should make the shoot speed independent
        // from fps
        delay += 1f * Time.deltaTime;

        //print(delay);
        //print(health);
        if(Input.GetKeyDown(KeyCode.H)){
            health++;
        }
    }

    // this acts as the player death function
    public void Damage(){
        health--;
            if(health == 0){
                // die
                Destroy(gameObject);
                // play particle effect
                // maybe play a sound?
                // show some fail thing for a few seconds
                // bring up a menu that'll let me restart the scene or go back to the main menu
            }
    }
    void Shoot(){
        // resets our delay AKA time since last shot.
        delay = 0;

        //play a sound here

        // spawn bullet at location A and b
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);


    }
}
