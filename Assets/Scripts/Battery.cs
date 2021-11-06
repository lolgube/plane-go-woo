using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    AudioManager aM;
    Rigidbody2D rb;
    // sets our y speed
    public float ySpeed;


    private void Start() {
        aM = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,50);
    }
    // makes the thing fall slowly
    private void Update() {
        rb.velocity = new Vector2(0,ySpeed*-1);
    }

    // if collide, give player health and then go away
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            FindObjectOfType<AudioManager>().Play("Health pickup");
            SpaceShip.health++;
            Destroy(gameObject);
        }
    }
}