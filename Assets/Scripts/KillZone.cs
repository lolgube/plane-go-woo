using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // if you collide with the killzone.
    // ya die
    void OnTriggerEnter2D(Collider2D col) {
        Destroy(col.gameObject);
    }
}
