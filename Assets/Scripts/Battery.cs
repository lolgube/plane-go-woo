using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    // if collide, give player health and then go away
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            SpaceShip.health++;
            Destroy(gameObject);
        }
    }
}
