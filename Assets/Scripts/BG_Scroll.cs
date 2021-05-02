using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -- made by mohammed

public class BG_Scroll : MonoBehaviour
{
    
    public float scrollingSpeed = 4f;
    private Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
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