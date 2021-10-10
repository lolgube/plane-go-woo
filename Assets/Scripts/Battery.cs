using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    AudioManager aM;
    private void Start()
    {
        aM = FindObjectOfType<AudioManager>();
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
