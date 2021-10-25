using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    // these gameobjects stand for the places where we instantiate the bullets
    // see link https://i.imgur.com/wcJhsWM.png for context
    // level 1 and 3 is middle thingie
    // 2&3&4 A - B are the outer most shoot canons. 4A and 4B are the two middle-outer-canons. 
    // i'm sorry for being so shit at naming stuff. - mohammed
    // fyi to stop the header from appearing under every single gameobject we're splitting them up like that.
    [Header("These are all the gun-spawn-places")]
    public GameObject level1and3;
    public GameObject level2and3and4A,level2and3and4B,level4A, level4B;

    float delay = 0;
    [Header("Here's the rest of our stuff.")]
    public GameObject bullet; 
    public GameObject spaceShipExplosion;
    Rigidbody2D rb;
    public float speed;
    AudioManager aM;


    // this variable is supposed to be set at the main menu (or a scene before it)
    public static int health = 4, startHealth;

    // p-score testing
    public static int PScore = 0;
    //cameraShake script -ALfred
    public cameraShake cameraShake;

    private void Awake() {
        // gets our rb
        rb = GetComponent<Rigidbody2D>();

        // finds the location of our cannons (bullet spawnpoints)
        // fuck me for naming these level instead of power - mohammed
        // this code just finds the children for player_ship. again, shitty names
        level1and3 = transform.Find("level1&3").gameObject;
        level2and3and4A = transform.Find("level2&3&4A").gameObject;
        level2and3and4B = transform.Find("level2&3&4B").gameObject;
        level4A = transform.Find("level4A").gameObject;
        level4B = transform.Find("level4B").gameObject;
    }

    void Start() {
        aM = FindObjectOfType<AudioManager>();

        // resets our score
        // has to be in this script because the spaceship is there from the start, otherwise it'll be wrong
        // until an enemy spawns  ^(and not in enenemy.cs)
        PlayerPrefs.SetInt("Score", 0);

        // just so we can keep an eye on what the value originally was for the score menu
        startHealth = health;
    }

    void Update() {
        // movement times our speed variable
        // this solution gives us the classic problem of two input buttons at once being pressed
        // doubbling the movement speed, worth fixing?
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")* speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")* speed));

        // this solution below seems to solve that, direction.normalize seems to be what's fixing the issue.
        // speed values are different, but that'll be fixed manually
        // update, the code below actaully fucks with the movement pretty hard.
        // gives a bit of a delay when you stop pressing a button, not good.
        // yeah, i guess i'll just use the original solution. a shame.
        
        /*Vector2 direction = new Vector2(0,0);
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        direction.Normalize();
        rb.AddForce(direction*speed); */

        // lemme try this maybe - okay this gave the absolute worst result i've seen yet. nice
        //rb.velocity = rb.velocity.normalized * speed;
        // i give up. not worth the hassle

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
        // update 2: it messed with a few things but i patched those up, this should make the
        // shoot speed independent from fps
        delay += 1f * Time.deltaTime;

        //print(delay);
        //print(health);
        // debug, might keep it in for luls
        if(Input.GetKeyDown(KeyCode.H)){
            health++;
        }
        // also debug, keeping it in for the moment
        if(Input.GetKeyDown(KeyCode.J)){
            PScore += 5;
            PScore = Mathf.Clamp(SpaceShip.PScore, 0, 100);
        }
        

        //print("starthealth = " + startHealth);
        //print("health = " + health);
    }

    // this acts as the player death function
    public void Damage(){
        health--;
        // ow (turns em red on hit)
        StartCoroutine(Blink());
            if(health == 0)
        {
                // boom
                Instantiate(spaceShipExplosion,transform.position,Quaternion.identity);
                // add sound here typ
                // die
                Destroy(gameObject);
                
                // maybe play a sound?
                // show some fail thing for a few seconds
                // bring up a menu that'll let me restart the scene or go back to the main menu

                //yield return new WaitForSeconds(4);
                //health = 4;
            }
        //funktion för att få kameran att skaka 0,2 sekunder -Alfred
        cameraShake.Shake(0.2f);
    }
    IEnumerator Blink(){
        // makes our spaceship red (r,g,b)
        GetComponent<SpriteRenderer>().color=new Color(1,0,0);
        // waits 0.2f
        yield return new WaitForSeconds(0.2f);
        // returns em to normal
        GetComponent<SpriteRenderer>().color=new Color(1,1,1);
    }

    void Shoot(){
        //play a sound here
        FindObjectOfType<AudioManager>().Play("Skjut");

        // resets our delay AKA time since last shot.
        delay = 0;

        // how i want the bullet system to work
        // see image, https://i.imgur.com/fuXgFn4.png
        // actually adding one more lazer to 100 since it's going to be annoying otherwise
        // if pewpew is full, shoot bambam (something special, otherwise just 4 lasers cause i'm lazy lmao)
        if (PScore >= 100) {
            Instantiate(bullet, level2and3and4A.transform.position, Quaternion.identity);
            Instantiate(bullet, level2and3and4B.transform.position, Quaternion.identity);
            Instantiate(bullet, level4A.transform.position, Quaternion.identity);
            Instantiate(bullet, level4B.transform.position, Quaternion.identity);
            // maybe remove this one later
            Instantiate(bullet, level1and3.transform.position, Quaternion.identity);
        }
        // if pscore is more than or equal to 50, shoot three pewpew
        else if (PScore >= 50) {
            Instantiate(bullet, level1and3.transform.position, Quaternion.identity);
            Instantiate(bullet, level2and3and4A.transform.position, Quaternion.identity);
            Instantiate(bullet, level2and3and4B.transform.position, Quaternion.identity);
        }
        // if pscore is more than or equal 25, shoot two pewpew
        else if (PScore >= 25) {
            Instantiate(bullet, level2and3and4A.transform.position, Quaternion.identity);
            Instantiate(bullet, level2and3and4B.transform.position, Quaternion.identity);
        }
        // if pscore is less than 25, shoot one pewpew
        if (PScore < 25) {
            Instantiate(bullet, level1and3.transform.position, Quaternion.identity);
        }

       

        

    }
}