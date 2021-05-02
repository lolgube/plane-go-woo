using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    // gets our rb
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        
    }

    //movement times speed
    void Update() {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")* speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")* speed));
    }
}
