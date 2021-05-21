using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    public float scrollingSpeed = 4f;
    private Vector3 StartPos;

    void Start()
    {
        // our start position is where the image starts, wow!
        StartPos = transform.position;
    }

    void FixedUpdate()
    {
        // this moves our background downwards. i.e moving down times deltatime times our scroll variable. 
        transform.Translate(Vector3.down*scrollingSpeed*Time.deltaTime);

        // once the image moves past this y value, move it back to the top of the screen.
        if(transform.position.y < -29.11997){
            transform.position = StartPos;
        }
    }
}