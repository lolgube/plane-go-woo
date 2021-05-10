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
    int health=4;


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
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")* speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")* speed));

        // when you press space, shoot (if delay is more than 5)
        if(Input.GetKey(KeyCode.Space)&&delay > .04){
            Shoot();
        }

        // adds time since last shot every frame
        // am very aware that this is dependant on FPS and will not end up the same on all computers
        // fuck. 
        //delay++;

        //okay, this made the calculation a bit different but it should end up being the same
        // maybe i'll have to test this, will i bother tho?
        delay += 1f * Time.deltaTime;

        //print(delay);
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
